using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using OstToolsBc.CetCatalogBc;
using OstToolsDataLayer.CetCatalog;
using OstToolsModels.CetCatalog;
using XrfParser;

namespace OstCetCatalogJuicerConsole.OverwriteProductReferences
{
    // TODO: Change to Entity Framework.
    public class ProductReferenceOverWriter
    {
        /// <summary>
        /// Database Connection String
        /// </summary>
        private readonly string _dbConnectionString;

        /// <summary>
        /// Xrf File Path
        /// </summary>
        private readonly string _xrfPath;

        /// <summary>
        /// Service provider used in dependency injection.
        /// </summary>
        private readonly ServiceProvider _services;

        public ProductReferenceOverWriter(string dbConnectionString, string xrfPath)
        {
            _dbConnectionString = dbConnectionString;
            _xrfPath = xrfPath;
            _services = ConfigureServices();
        }

        /// <summary>
        /// Configure Services for dependency injection
        /// </summary>
        /// <returns>Service Provider for services</returns>
        private ServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            // Add Tables
            services.AddSingleton(new CetDsProductTypeTable(_dbConnectionString));
            services.AddSingleton(new CetDsProductTypeExternalReferenceTable(_dbConnectionString));
            services.AddSingleton(new CetProductExternalReferenceTypeTable(_dbConnectionString));

            // Add BC's
            services.AddSingleton<ICetCrudCatalogBc<CetDsProductTypeModel>, CetDsProductTypeBc>();
            services.AddSingleton<ICetCrudReferenceBc<CetDsProductTypeExternalReferenceModel>,
                CetDsProductTypeExternalReferenceBc>();
            services.AddSingleton<ICetCrudCatalogBc<CetProductExternalReferenceTypeModel>,
                CetProductExternalReferenceTypeBc>();

            // Build
            return services.BuildServiceProvider();
        }

        /// <summary>
        /// Get Ds Product Type Bc
        /// </summary>
        /// <returns>Injected ICetCrudCatalogBc</returns>
        public ICetCrudCatalogBc<CetDsProductTypeModel> GetDsProductTypeBc() =>
            _services.GetService<ICetCrudCatalogBc<CetDsProductTypeModel>>();

        /// <summary>
        /// Get Ds Product External Reference Type Bc
        /// </summary>
        /// <returns>Injected ICetCrudReferenceBc</returns>
        public ICetCrudReferenceBc<CetDsProductTypeExternalReferenceModel> GetDsProductExternalReferenceBc() =>
            _services.GetService<ICetCrudReferenceBc<CetDsProductTypeExternalReferenceModel>>();

        /// <summary>
        /// Get Cet Product External Reference Type Bc
        /// </summary>
        /// <returns>Injected ICetCrudCatalogBc</returns>
        public ICetCrudCatalogBc<CetProductExternalReferenceTypeModel> GetProductExternalReferenceBc() =>
            _services.GetService<ICetCrudCatalogBc<CetProductExternalReferenceTypeModel>>();

        /// <summary>
        /// Overwrite old Product external reference urls
        /// </summary>
        /// <returns>Overwrite task</returns>
        public async Task OverwriteProductReferences()
        {
            var xrfModels = GetXrfModels();
            var products = (await GetDsProductTypeBc().ReadAllAsync()).ToList();
            var productReferences = (await GetDsProductExternalReferenceBc().ReadAllAsync()).ToList();
            var externalProductReferences = (await GetProductExternalReferenceBc().ReadAllAsync()).ToList();
            var toUpdate =
                GetToUpdateExternalReferences(xrfModels, products, productReferences, externalProductReferences);
            await UpdateExternalReferences(toUpdate);
        }

        /// <summary>
        /// Load Xrf Models from Xrf File
        /// </summary>
        /// <returns>Found Xrf Models</returns>
        private IEnumerable<XrfModel> GetXrfModels()
        {
            var xrfParser = new XrfParser.XrfParser(_xrfPath);
            return xrfParser.ParseFile();
        }

        /// <summary>
        /// Get all external references with their updated URL values
        /// </summary>
        /// <param name="xrfModelEnumerable">XRF Model collection</param>
        /// <param name="cetProductTypeEnumerable">Products</param>
        /// <param name="cetDsProductTypeExternalReferenceEnumerable">Product references between External and product</param>
        /// <param name="productExternalEnumerable">External Product references.</param>
        /// <returns>External Product refences with URL updated. Need to update in Database still.</returns>
        private IEnumerable<CetProductExternalReferenceTypeModel> GetToUpdateExternalReferences(
            IEnumerable<XrfModel> xrfModelEnumerable,
            IEnumerable<CetDsProductTypeModel> cetProductTypeEnumerable,
            IEnumerable<CetDsProductTypeExternalReferenceModel> cetDsProductTypeExternalReferenceEnumerable,
            IEnumerable<CetProductExternalReferenceTypeModel> productExternalEnumerable)
        {
            var xrfModels = xrfModelEnumerable.ToList();
            var cetProductModels = cetProductTypeEnumerable.ToList();
            var cetDsProductReferences = cetDsProductTypeExternalReferenceEnumerable.ToList();
            var cetExternalReferences = productExternalEnumerable.ToList();
            var found = new List<CetProductExternalReferenceTypeModel>();

            foreach (var product in cetProductModels)
            {
                var xrfModel = xrfModels.FirstOrDefault(xrf =>
                    string.Equals(product.Code, xrf.PartNumber, StringComparison.CurrentCultureIgnoreCase));
                if (xrfModel == null) continue;

                var dsProductReferences = cetDsProductReferences.Where(prdRef => product.Id == prdRef.OwnerKey);
                var referenceIds = dsProductReferences.Select(prdRef => prdRef.ValueKey).ToList();

                var externalReferences =
                    cetExternalReferences.Where(extRef => referenceIds.Contains(extRef.Id));

                var externalReference = externalReferences.FirstOrDefault(extRef => extRef.Url.EndsWith(".cmsym"));
                if (externalReference == null) continue;

                var newSymbol = xrfModel.Symbol + ".cmsym";
                if (string.Equals(newSymbol, externalReference.Url, StringComparison.CurrentCultureIgnoreCase)) continue;
                externalReference.Url = newSymbol;
                found.Add(externalReference);
            }

            return found;
        }

        /// <summary>
        /// Update the external reference table with the new values
        /// </summary>
        /// <param name="externalReferenceEnumerable">External Reference models</param>
        /// <returns>Update task. </returns>
        private async Task UpdateExternalReferences(
            IEnumerable<CetProductExternalReferenceTypeModel> externalReferenceEnumerable)
        {
            var bc = GetProductExternalReferenceBc();
            foreach (var model in externalReferenceEnumerable)
            {
                await bc.UpdateModelAsync(model);
            }
        }
    }
}
