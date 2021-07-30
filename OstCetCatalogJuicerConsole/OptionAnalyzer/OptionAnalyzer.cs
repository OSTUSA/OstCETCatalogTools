using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.CetCatalog;
using Microsoft.Extensions.DependencyInjection;
using OstToolsBc.CetCatalogBc;
using OstToolsDataLayer.CetCatalog;
using OstToolsModels.CetCatalog;

namespace OstCetCatalogJuicerConsole.OptionAnalyzer
{
    public class OptionAnalyzer
    {
        private readonly string _dbConnectionString;
        private readonly string _exportDirectory;
        private readonly ServiceProvider _services;

        public OptionAnalyzer(string dbConnectionString, string exportDirectory)
        {
            _dbConnectionString = dbConnectionString;
            _exportDirectory = exportDirectory;
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
            services.AddSingleton(new CetOptionTable(_dbConnectionString));
            services.AddSingleton(new CetOptionDescriptionReferenceTable(_dbConnectionString));
            services.AddSingleton(new CetOptionMaterialApplicationReferenceTable(_dbConnectionString));

            // Add BC's
            services.AddSingleton<ICetCrudCatalogBc<CetOptionModel>, CetOptionBc>();
            services.AddSingleton<ICetCrudReferenceBc<CetOptionDescriptionReferenceModel>, 
                CetOptionDescriptionReferenceBc>();
            services.AddSingleton<ICetCrudReferenceBc<CetOptionMaterialApplicationReferenceModel>, 
                CetOptionMaterialApplicationReferenceBc>();

            // Build
            return services.BuildServiceProvider();
        }

        /// <summary>
        /// Get Option BC
        /// </summary>
        /// <returns>OptionBc</returns>
        public ICetCrudCatalogBc<CetOptionModel> OptionBc() => _services.GetService<ICetCrudCatalogBc<CetOptionModel>>();

        /// <summary>
        /// Get Option Description BC
        /// </summary>
        /// <returns>OptionDescriptionBc</returns>
        public ICetCrudReferenceBc<CetOptionDescriptionReferenceModel> OptionDescriptionBc() =>
            _services.GetService<ICetCrudReferenceBc<CetOptionDescriptionReferenceModel>>();

        /// <summary>
        /// Get Option Material Application BC
        /// </summary>
        /// <returns>OptionMaterialApplicationBc</returns>
        public ICetCrudReferenceBc<CetOptionMaterialApplicationReferenceModel> OptionMaterialApplicationBc() =>
            _services.GetService<ICetCrudReferenceBc<CetOptionMaterialApplicationReferenceModel>>();

        /// <summary>
        /// Sort options into good, unknown and bad.
        /// </summary>
        /// <param name="goodMaterialCodes">Good material code csv</param>
        /// <param name="badMaterialCodes">Bad Material Code csv</param>
        /// <param name="unknownMaterialCodes">Unknown Material Code csv</param>
        /// <returns>Sorting Option Task.</returns>
        public async Task SortOptions(string goodMaterialCodes = "", string badMaterialCodes = "", string unknownMaterialCodes = "")
        {
            var optionBc = OptionBc();
            var options = (await optionBc.ReadAllAsync()).ToList();
            options = RemoveOptions(options, goodMaterialCodes).ToList();
            var deletedMaterialCount = await DeleteBadMaterials(options, badMaterialCodes);
            options = RemoveOptions(options, badMaterialCodes).ToList();
            var chooser = new OptionRater(goodMaterialCodes, badMaterialCodes, unknownMaterialCodes, RemoveDuplicateCodes(options).ToList());
            chooser.PickAndChoose();
            deletedMaterialCount += await DeleteBadMaterials(options, chooser.BadList);
            await CreateCsvFiles(chooser.GoodList, chooser.BadList, chooser.UnknownList);

            Console.Clear();
            Console.WriteLine($"Deleted Count: {deletedMaterialCount}");
            Console.WriteLine();
            Console.WriteLine();
        }

        /// <summary>
        /// Remove duplicate codes from provided options collection.
        /// </summary>
        /// <param name="options">Options to remove duplicate codes from</param>
        /// <returns>Distinct by Code collection</returns>
        private static IEnumerable<CetOptionModel> RemoveDuplicateCodes(IEnumerable<CetOptionModel> options)
        {
            var optionList = new List<CetOptionModel>();
            var hashSet = new HashSet<string>();
            foreach (var option in options)
            {
                if (hashSet.Contains(option.Code)) continue;
                hashSet.Add(option.Code);
                optionList.Add(option);
            }

            return optionList;
        }

        /// <summary>
        /// Remove already found options from collection
        /// </summary>
        /// <param name="options">Original list to remove from</param>
        /// <param name="codes">Codes to identify options by</param>
        private static IEnumerable<CetOptionModel> RemoveOptions(IEnumerable<CetOptionModel> options, string codes)
        {
            var optionList = options.ToList();
            var optionCodes = codes.Split(';');
            optionList.RemoveAll(option => optionCodes.Contains(option.Code));
            return optionList;
        }

        /// <summary>
        /// Delete Bad Materials from table
        /// </summary>
        /// <param name="options">Option collection</param>
        /// <param name="badOptionCodes">Option codes to delete</param>
        /// <returns>Number of deleted rows</returns>
        private Task<int> DeleteBadMaterials(IEnumerable<CetOptionModel> options, string badOptionCodes)
        {
            var badMaterialCodes = badOptionCodes.Split(';');
            var badOptions = options.Where(option => badMaterialCodes.Contains(option.Code));
            var badMaterialReferences = badOptions.Select(option => option.MaterialApplicationReference);
            var materialBc = OptionMaterialApplicationBc();
            return materialBc.DeleteModelsAsync(badMaterialReferences);
        }

        /// <summary>
        /// Create CSV files for all code types
        /// </summary>
        /// <param name="goodCodes">Good Option Codes</param>
        /// <param name="badCodes">Bad Option Codes</param>
        /// <param name="unKnownCodes">Unknown Option Codes</param>
        /// <returns>Csv Creation Task</returns>
        private async Task CreateCsvFiles(string goodCodes, string badCodes, string unKnownCodes)
        {
            await File.WriteAllTextAsync(Path.Join(_exportDirectory, "GoodCodes.txt"), goodCodes);
            await File.WriteAllTextAsync(Path.Join(_exportDirectory, "BadCodes.txt"), badCodes);
            await File.WriteAllTextAsync(Path.Join(_exportDirectory, "UnknownCodes.txt"), unKnownCodes);
        }
    }
}
