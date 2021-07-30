using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.CetCatalog;
using Microsoft.Extensions.DependencyInjection;
using OstToolsBc.CetCatalogBc;
using OstToolsDataLayer.CetCatalog;
using OstToolsDataLayer.Constants.CetCatalog;
using OstToolsModels.CetCatalog;
using XrfParser;

namespace OstCetCatalogJuicerConsole.ProductMatcher
{
    public class ProductMatcher
    {
        private readonly string _dbConnectionString;
        private readonly string _symbolDirectory;
        private readonly string _xrfPath;
        private readonly ServiceProvider _services;

        public ProductMatcher(string dbConnectionString, string symbolDirectory, string xrfPath)
        {
            _dbConnectionString = dbConnectionString;
            _symbolDirectory = symbolDirectory;
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
        /// Match products to their symbol counterpart.
        /// </summary>
        public async Task MatchProducts()
        {
            var symbols = GetSymbols().ToList();
            var products = (await GetDsProductTypeBc().ReadAllAsync()).ToList();
            var dsReferenceTypes = await GetDsProductExternalReferenceBc().ReadAllAsync();
            var xrfModels = GetXrfModels().ToList();

            products = RemoveAlreadyPairedProducts(products, dsReferenceTypes).ToList();
            var externals = InstantiateExternalReferenceTypeModels(xrfModels, products, symbols).ToList();
            Console.WriteLine("Insert External References: " + await InsertExternalReferenceTypeModels(externals));
            externals = (await GetProductExternalReferenceBc().ReadAllAsync())
                .Where(ext => externals.Select(ex => ex.Url).Contains(ext.Url)).ToList();
            var dsExternalReferences = InstantiateDsExternals(products, externals, xrfModels);
            Console.WriteLine("Insert references: " + await InsertDsExternals(dsExternalReferences));
        }

        /// <summary>
        /// Get Symbols
        /// </summary>
        /// <returns>Symbol collection</returns>
        private IEnumerable<string> GetSymbols()
        {
            var filePaths = Directory.GetFiles(_symbolDirectory);
            return filePaths.Select(filePath => Path.GetFileName(filePath));
        }

        /// <summary>
        /// Remove already paired products so we don't overwrite their matches.
        /// </summary>
        /// <param name="products">Products</param>
        /// <param name="references">Product references</param>
        /// <returns></returns>
        private static IEnumerable<CetDsProductTypeModel> RemoveAlreadyPairedProducts(
            IEnumerable<CetDsProductTypeModel> products, IEnumerable<CetDsProductTypeExternalReferenceModel> references)
        {
            return products.Where(product => !references.Select(reference => reference.OwnerKey).Contains(product.Id));
        }

        /// <summary>
        /// Load Xrf Models from Xrf File
        /// </summary>
        /// <returns></returns>
        private IEnumerable<XrfModel> GetXrfModels()
        {
            var xrfParser = new XrfParser.XrfParser(_xrfPath);
            return xrfParser.ParseFile();
        }

        /// <summary>
        /// Create External Reference Type Models
        /// </summary>
        /// <param name="xrfModels">Xrf Models</param>
        /// <param name="productModels">Product Models</param>
        /// <returns>Collection of newly</returns>
        private static IEnumerable<CetProductExternalReferenceTypeModel> InstantiateExternalReferenceTypeModels(IEnumerable<XrfModel> xrfModels, 
            IEnumerable<CetDsProductTypeModel> productModels, IEnumerable<string> symbols)
        {
            var productPartNumber = productModels.Select(product => product.Code).ToList();
            var symbolList = symbols.ToList();
            var xrfList = xrfModels.ToList();
            var externals = new List<CetProductExternalReferenceTypeModel>();

            foreach (var partNumber in productPartNumber)
            {
                var xrf = xrfList.FirstOrDefault(x => string.Equals(x.PartNumber, partNumber, StringComparison.CurrentCultureIgnoreCase));
                if (xrf == null) continue;

                var symbol = symbolList.FirstOrDefault(sym => string.Equals(xrf.Symbol,
                    Path.GetFileNameWithoutExtension(sym), StringComparison.CurrentCultureIgnoreCase));

                if (string.IsNullOrWhiteSpace(symbol)) continue;
                externals.Add(new CetProductExternalReferenceTypeModel
                {
                    Url = symbol,
                    PreviewUrl = "",
                    UsageType = "1",
                    MeasureParameter = "",
                    Code = "",
                    InsertionId = "",
                    Pt = "1"
                });
            }

            return externals;
        }

        /// <summary>
        /// Insert External reference types into table
        /// </summary>
        /// <param name="externalReferenceTypeModels"></param>
        /// <returns></returns>
        private Task<int> InsertExternalReferenceTypeModels(
            IEnumerable<CetProductExternalReferenceTypeModel> externalReferenceTypeModels) =>
            GetProductExternalReferenceBc().CreateModelAsync(externalReferenceTypeModels);


        private static IEnumerable<CetDsProductTypeExternalReferenceModel> InstantiateDsExternals(
            IEnumerable<CetDsProductTypeModel> products, IEnumerable<CetProductExternalReferenceTypeModel> externals,
            IEnumerable<XrfModel> xrfModels)
        {
            var productList = products.ToList();
            var externalList = externals.ToList();
            var xrfList = xrfModels.ToList();

            var dict = new Dictionary<string, int>();
            foreach (var product in productList)
            {
                var sym = xrfList.FirstOrDefault(xrf => xrf.PartNumber == product.Code)?.Symbol;
                if (string.IsNullOrWhiteSpace(sym)) continue;
                dict.TryAdd(sym, product.Id);
            }

            var list = new List<CetDsProductTypeExternalReferenceModel>();
            foreach (var external in externalList)
            {
                var externalUrl = Path.GetFileNameWithoutExtension(external.Url) ?? "";
                dict.TryGetValue(externalUrl, out var productId);
                if (productId <= 0 || external.Id <= 0) continue;

                list.Add(new CetDsProductTypeExternalReferenceModel {OwnerKey = productId, ValueKey = external.Id, TypeKey = ExternalReferenceTypesConstants.ProductExternalReferenceTypeKey});
            }

            return list;
        }

        private Task<int> InsertDsExternals(IEnumerable<CetDsProductTypeExternalReferenceModel> externals) =>
            GetDsProductExternalReferenceBc().CreateModelAsync(externals);
    }
}
