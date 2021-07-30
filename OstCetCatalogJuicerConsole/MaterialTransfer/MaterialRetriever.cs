using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using OstToolsBc.CetCatalogBc;
using OstToolsDataLayer.CetCatalog;
using OstToolsModels.CetCatalog;

namespace OstCetCatalogJuicerConsole.MaterialTransfer
{
    public class MaterialRetriever
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly string _dbConnectionString;

        public MaterialRetriever(string dbConnectionString)
        {
            _dbConnectionString = dbConnectionString;
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
            services.AddSingleton(new CetSMaterialTable(_dbConnectionString));
            services.AddSingleton(new CetSMaterialExternalReferenceTable(_dbConnectionString));
            services.AddSingleton(new CetExternalReferenceTypeTable(_dbConnectionString));

            // Add BC's
            services.AddSingleton<ICetCrudCatalogBc<CetSMaterialModel>, CetSMaterialBc>();
            services
                .AddSingleton<ICetCrudReferenceBc<CetSMaterialExternalReferenceModel>, CetSMaterialExternalReferenceBc
                >();
            services.AddSingleton<ICetCrudCatalogBc<CetExternalReferenceTypeModel>, CetExternalReferenceTypeBc>();

            return services.BuildServiceProvider();
        }

        /// <summary>
        /// Get S Material BC
        /// </summary>
        /// <returns>Injected SMaterialBc</returns>
        public ICetCrudCatalogBc<CetSMaterialModel> GetSMaterialBc() =>
            _serviceProvider.GetService<ICetCrudCatalogBc<CetSMaterialModel>>();

        /// <summary>
        /// Get S Material External Reference Bc
        /// </summary>
        /// <returns>Injected S Material External reference Bc</returns>
        public ICetCrudReferenceBc<CetSMaterialExternalReferenceModel> GetSMaterialExtReferenceBc() =>
            _serviceProvider.GetService<ICetCrudReferenceBc<CetSMaterialExternalReferenceModel>>();

        /// <summary>
        /// Get External reference type BC
        /// </summary>
        /// <returns>Injected External Reference Type BC</returns>
        public ICetCrudCatalogBc<CetExternalReferenceTypeModel> GetExternalReferenceTypeBc() =>
            _serviceProvider.GetService<ICetCrudCatalogBc<CetExternalReferenceTypeModel>>();

        /// <summary>
        /// Get All S Materials from provided Database
        /// </summary>
        /// <returns>Materials from provided database</returns>
        public Task<IEnumerable<CetSMaterialModel>> GetAllMaterials() => GetSMaterialBc().ReadAllAsync();

        /// <summary>
        /// Get All Cet S Material External References from provided Database
        /// </summary>
        /// <returns>Material External references from provided DB</returns>
        public Task<IEnumerable<CetSMaterialExternalReferenceModel>> GetAllMaterialExternalReference() =>
            GetSMaterialExtReferenceBc().ReadAllAsync();

        /// <summary>
        /// Get All External Reference types from provided database
        /// </summary>
        /// <returns>External references from provided DB</returns>
        public Task<IEnumerable<CetExternalReferenceTypeModel>> GetAllExternalReferenceTypes() =>
            GetExternalReferenceTypeBc().ReadAllAsync();
    }
}
