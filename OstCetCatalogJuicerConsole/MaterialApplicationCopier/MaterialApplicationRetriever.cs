using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using OstToolsBc.CetCatalogBc;
using OstToolsDataLayer.CetCatalog;
using OstToolsModels.CetCatalog;

namespace OstCetCatalogJuicerConsole.MaterialApplicationCopier
{
    internal class MaterialApplicationRetriever
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly string _dbConnectionString;

        public MaterialApplicationRetriever(string dbConnectionString)
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
            services.AddSingleton(new CetApplicationAreaTypeTable(_dbConnectionString));
            services.AddSingleton(new CetApplicationAreaTypeSurfaceIdsReferenceTable(_dbConnectionString));

            services.AddSingleton<ICetCrudCatalogBc<CetApplicationAreaTypeModel>, CetApplicationAreaTypeBc>();
            services
                .AddSingleton<ICetCrudReferenceBc<CetApplicationAreaTypeSurfaceIdsReferenceModel>,
                    CetApplicationsAreaTypeSurfaceIdsReferenceBc>();

            return services.BuildServiceProvider();
        }

        /// <summary>
        /// Get Application Area type BC
        /// </summary>
        /// <returns>Injected Application Area type BC</returns>
        public ICetCrudCatalogBc<CetApplicationAreaTypeModel> GetApplicationBc() =>
            _serviceProvider.GetService<ICetCrudCatalogBc<CetApplicationAreaTypeModel>>();

        /// <summary>
        /// Get Application Area Type Surface ID Reference BC
        /// </summary>
        /// <returns>Injected Application Area Type Surface ID reference BC</returns>
        public ICetCrudReferenceBc<CetApplicationAreaTypeSurfaceIdsReferenceModel> GetApplicationReferenceBc() =>
            _serviceProvider.GetService<ICetCrudReferenceBc<CetApplicationAreaTypeSurfaceIdsReferenceModel>>();

        /// <summary>
        /// Get All Application Areas
        /// </summary>
        /// <returns>All application area types in table</returns>
        public Task<IEnumerable<CetApplicationAreaTypeModel>> GetApplicationAreas() => GetApplicationBc().ReadAllAsync();

        /// <summary>
        /// Get All Application References
        /// </summary>
        /// <returns>All application references in table</returns>
        public Task<IEnumerable<CetApplicationAreaTypeSurfaceIdsReferenceModel>> GetApplicationReferences() =>
            GetApplicationReferenceBc().ReadAllAsync();
    }
}
