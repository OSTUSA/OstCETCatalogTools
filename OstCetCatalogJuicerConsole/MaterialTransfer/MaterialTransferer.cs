using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using OstToolsBc.CetCatalogBc;
using OstToolsDataLayer.CetCatalog;
using OstToolsModels.CetCatalog;

namespace OstCetCatalogJuicerConsole.MaterialTransfer
{
    public class MaterialTransferer
    {
        private readonly List<string> _copyFrom;
        private readonly string _copyTo;

        private readonly IServiceProvider _serviceProvider;



        public MaterialTransferer(IEnumerable<string> copyFrom, string copyTo)
        {
            _copyTo = copyTo;
            _copyFrom = copyFrom.ToList();
            _serviceProvider = ConfigureServices();
        }

        /// <summary>
        /// Configure Services
        /// </summary>
        /// <returns>Service Provider</returns>
        private IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            // Add Tables
            services.AddSingleton(new CetExternalReferenceTypeTable(_copyTo));

            // Add BC's
            services.AddSingleton<ICetCrudCatalogBc<CetExternalReferenceTypeModel>, CetExternalReferenceTypeBc>();

            return services.BuildServiceProvider();
        }

        /// <summary>
        /// Transfer material references over to new DB
        /// </summary>
        /// <returns></returns>
        public async Task TransferMaterialReferences()
        {
            var pairs = await GetCopyPairs();
            var pairDictionary = GetCodeToUrlDictionary(pairs);
            var externals = await GetCopyToExternals();
            var toUpdate = SetUrlsOnModel(externals, pairDictionary).ToList();
            var externalBc = GetExternalReferenceTypeBc();
            foreach (var model in toUpdate)
            {
                await externalBc.UpdateModelAsync(model);
            }

        }

        /// <summary>
        /// Get External reference type BC
        /// </summary>
        /// <returns>Injected External Reference Type BC</returns>
        private ICetCrudCatalogBc<CetExternalReferenceTypeModel> GetExternalReferenceTypeBc() =>
            _serviceProvider.GetService<ICetCrudCatalogBc<CetExternalReferenceTypeModel>>();

        /// <summary>
        /// Get All CetSmaterial Models and CetExternal Reference Type Models.
        /// Once found, pair them up with their match.
        /// </summary>
        /// <returns>Paired Material and external reference</returns>
        private async Task<IEnumerable<KeyValuePair<CetSMaterialModel, CetExternalReferenceTypeModel>>> GetCopyPairs()
        {
            var codeToUrl = new Dictionary<string, string>();
            var pairs = new List<KeyValuePair<CetSMaterialModel, CetExternalReferenceTypeModel>>();
            foreach (var dbConnectionString in _copyFrom)
            {
                var retriever = new MaterialRetriever(dbConnectionString);
                var materials = await retriever.GetAllMaterials();
                var references = await retriever.GetAllMaterialExternalReference();
                var externals = await retriever.GetAllExternalReferenceTypes();
                pairs.AddRange(PairModels(materials, references, externals));
            }

            return pairs;
        }

        /// <summary>
        /// Get Copy to externals
        /// </summary>
        /// <returns>Collection of external references that are needed to be updated</returns>
        private Task<IEnumerable<CetExternalReferenceTypeModel>> GetCopyToExternals()
        {
            var retriever = new MaterialRetriever(_copyTo);
            return retriever.GetAllExternalReferenceTypes();
        }

        /// <summary>
        /// Pair External Reference with it SMaterial
        /// </summary>
        /// <param name="models">SMaterials</param>
        /// <param name="references">SMaterialReferences</param>
        /// <param name="externals">ExternalReferences</param>
        /// <returns>Paired External Reference and SMaterials</returns>
        private IEnumerable<KeyValuePair<CetSMaterialModel, CetExternalReferenceTypeModel>> PairModels(
            IEnumerable<CetSMaterialModel> models, IEnumerable<CetSMaterialExternalReferenceModel> references,
            IEnumerable<CetExternalReferenceTypeModel> externals)
        {
            var keyValuePairs = new List<KeyValuePair<CetSMaterialModel, CetExternalReferenceTypeModel>>();
            var referenceList = references.ToList();
            var externalList = externals.ToList();

            foreach (var model in models)
            {
                var externalId = referenceList.FirstOrDefault(reference => reference.OwnerKey == model.Id)?.ValueKey ?? 0;
                if (externalId == 0) continue;
                var external = externalList.FirstOrDefault(ext => ext.Id == externalId);
                if (external != null) keyValuePairs.Add(new KeyValuePair<CetSMaterialModel, CetExternalReferenceTypeModel>(model, external));
            }

            return keyValuePairs;
        }

        /// <summary>
        /// Get a Code to URL dictionary
        /// </summary>
        /// <param name="keyValuePairs">Models to grab code and Url from</param>
        /// <returns></returns>
        private static IDictionary<string, string> GetCodeToUrlDictionary(
            IEnumerable<KeyValuePair<CetSMaterialModel, CetExternalReferenceTypeModel>> keyValuePairs)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var keyValuePair in keyValuePairs)
            {
                if (string.Equals(keyValuePair.Key.Code, Path.GetFileNameWithoutExtension(keyValuePair.Value.Url), StringComparison.CurrentCultureIgnoreCase)) continue;
                dictionary.TryAdd(keyValuePair.Key.Code, keyValuePair.Value.Url);
            }

            return dictionary;
        }

        /// <summary>
        /// Change the outdated url on external models to updated version.
        /// </summary>
        /// <param name="models">External References</param>
        /// <param name="dictionary">Code to Url dictionary</param>
        /// <returns>Updated models</returns>
        private static IEnumerable<CetExternalReferenceTypeModel> SetUrlsOnModel(
            IEnumerable<CetExternalReferenceTypeModel> models, IDictionary<string, string> dictionary)
        {
            var toUpdate = new List<CetExternalReferenceTypeModel>();
            foreach (var model in models)
            {
                var code = Path.GetFileNameWithoutExtension(model.Url) ?? string.Empty;
                var found = dictionary.TryGetValue(code, out var value);
                if (!found) continue;

                model.Url = value;
                toUpdate.Add(model);
            }

            return toUpdate;
        }


    }
}
