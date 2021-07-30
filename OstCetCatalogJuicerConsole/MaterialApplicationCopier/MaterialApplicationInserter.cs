using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using OstToolsBc.CetCatalogBc;
using OstToolsDataLayer.CetCatalog;
using OstToolsModels.CetCatalog;

namespace OstCetCatalogJuicerConsole.MaterialApplicationCopier
{
    public class MaterialApplicationInserter
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly string _dbConnectionString;

        public MaterialApplicationInserter(string dbConnectionString)
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
        /// Insert the application types to the table
        /// </summary>
        /// <param name="applications">Cet Application Area Type Models</param>
        /// <param name="references">Cet Application Area Type Surface Ids Reference Model</param>
        /// <returns>Insertion Task</returns>
        public async Task InsertApplications(IEnumerable<CetApplicationAreaTypeModel> applications,
            IEnumerable<CetApplicationAreaTypeSurfaceIdsReferenceModel> references)
        {
            var applicationBc = GetApplicationBc();
            var referenceBc = GetApplicationReferenceBc();

            await CreateTablesAndIndices();

            // await GetApplicationBc().CreateModelAsync(applications);
            await GetApplicationReferenceBc().CreateModelAsync(references);
        }

        private async Task CreateTablesAndIndices()
        {
            var applicationBc = GetApplicationBc();
            var referenceBc = GetApplicationReferenceBc();

            await applicationBc.CreateTableAsync();
            await referenceBc.CreateTableAsync();

            await applicationBc.CreateIndices();
        }


    }
}
