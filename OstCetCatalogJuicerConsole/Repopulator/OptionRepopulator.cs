using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.CetCatalog;
using Microsoft.Extensions.DependencyInjection;
using OstToolsBc.CetCatalogBc;
using OstToolsDataLayer.CetCatalog;
using OstToolsModels.CetCatalog;

namespace OstCetCatalogJuicerConsole.Repopulator
{
    public class OptionRepopulator
    {
        private readonly string _dbConnectionString;
        private readonly List<string> _optionCodeList;
        private readonly IServiceProvider _serviceProvider;

        public OptionRepopulator(string dbConnectionString, string optionCodeCsv)
        {
            _dbConnectionString = dbConnectionString;
            _optionCodeList = optionCodeCsv.Split(';').Distinct().ToList();
            _serviceProvider = ConfigureServices();
        }

        /// <summary>
        /// Configure Services for dependency injection
        /// </summary>
        /// <returns>Service Provider for services</returns>
        private ServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            // Add Tables
            services.AddSingleton(new CetOptionTable(_dbConnectionString));
            services.AddSingleton(new CetOptionMaterialApplicationReferenceTable(_dbConnectionString));
            services.AddSingleton(new CetMaterialApplicationTable(_dbConnectionString));
            services.AddSingleton(new CetOptionDescriptionReferenceTable(_dbConnectionString));

            // Add BC's
            services.AddSingleton<ICetCrudCatalogBc<CetOptionModel>, CetOptionBc>();
            services.AddSingleton<ICetCrudReferenceBc<CetOptionMaterialApplicationReferenceModel>,
                CetOptionMaterialApplicationReferenceBc>();
            services.AddSingleton<ICetCrudCatalogBc<CetMaterialApplicationModel>, CetMaterialApplicationBc>();
            services
                .AddSingleton<ICetCrudReferenceBc<CetOptionDescriptionReferenceModel>, CetOptionDescriptionReferenceBc
                >();


            // Build
            return services.BuildServiceProvider();
        }

        /// <summary>
        /// Bind Materials to Options
        /// </summary>
        /// <returns>Binding Task</returns>
        public async Task BindMaterialsToOptions()
        {
            var options = (await GetOptionBc().ReadAllAsync()).ToList();
            options = FilterDownOptions(options).ToList();
            options = (await RemoveAlreadyPairedOptions(options)).ToList();
            var references = (await BuildReferences(options)).ToList();
            await CreateReferences(references);
            Console.WriteLine($"Number of created References: {references.Count}");
        }

        /// <summary>
        /// Get Option Bc
        /// </summary>
        /// <returns>Injected Option Bc</returns>
        private ICetCrudCatalogBc<CetOptionModel> GetOptionBc() =>
            _serviceProvider.GetService<ICetCrudCatalogBc<CetOptionModel>>();

        /// <summary>
        /// Get Material Application Reference Bc
        /// </summary>
        /// <returns>Injected Material Application Reference Bc</returns>
        private ICetCrudReferenceBc<CetOptionMaterialApplicationReferenceModel> GetMaterialReferenceBc() =>
            _serviceProvider.GetService<ICetCrudReferenceBc<CetOptionMaterialApplicationReferenceModel>>();

        /// <summary>
        /// Get material Application Bc
        /// </summary>
        /// <returns>Injected Material Application Bc</returns>
        private ICetCrudCatalogBc<CetMaterialApplicationModel> GetMaterialApplicationBc() =>
            _serviceProvider.GetService<ICetCrudCatalogBc<CetMaterialApplicationModel>>();

        /// <summary>
        /// Filter down Options to options with code in provided list.
        /// </summary>
        /// <param name="options">Options to filter down.</param>
        /// <returns>Filtered list</returns>
        private IEnumerable<CetOptionModel> FilterDownOptions(IEnumerable<CetOptionModel> options)
        {
            var optionList = new List<CetOptionModel>();
            foreach (var option in options)
            {
                foreach (var code in _optionCodeList)
                {
                    if (!string.Equals(code.Trim(), option.Code.Trim(), StringComparison.CurrentCultureIgnoreCase)) continue;
                    optionList.Add(option);
                    break;
                }
            }

            return optionList;
        }

        /// <summary>
        /// Filter down options that are already paired. 
        /// </summary>
        /// <param name="options">Current options</param>
        /// <returns></returns>
        private async Task<IEnumerable<CetOptionModel>> RemoveAlreadyPairedOptions(
            IEnumerable<CetOptionModel> options)
        {
            return options.Where(option => option.MaterialApplicationReference == null);
        }

        /// <summary>
        /// Build material application references for options
        /// </summary>
        /// <param name="options">Options to build reference for</param>
        /// <returns>References that have not yet been added to the table.</returns>
        private async Task<IEnumerable<CetOptionMaterialApplicationReferenceModel>> BuildReferences(
            IEnumerable<CetOptionModel> options)
        {
            var materials = (await GetMaterialApplicationBc().ReadAllAsync()).ToList();
            materials = materials.Where(material => _optionCodeList.Contains(material.MaterialReference)).ToList();
            var references = new List<CetOptionMaterialApplicationReferenceModel>();
            foreach (var option in options)
            {
                var material = materials.FirstOrDefault(mat => mat.MaterialReference == option.Code);
                if (material == null) continue;
                references.Add(new CetOptionMaterialApplicationReferenceModel
                {
                    OwnerKey = option.Id,
                    ValueKey = material.Id,
                    TypeKey = "MtrlApplication"
                });
            }

            return references;
        }

        /// <summary>
        /// Add the references to the table
        /// </summary>
        /// <param name="references">Option to material references</param>
        /// <returns>Creation Task</returns>
        private Task CreateReferences(IEnumerable<CetOptionMaterialApplicationReferenceModel> references)
        {
            var refs = references.ToList();
            return !refs.Any() ? Task.CompletedTask : GetMaterialReferenceBc().CreateModelAsync(refs);
        }
    }
}
