using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FeatureOptionCleaner.Cleaners;
using FeatureOptionCleaner.Models;
using Microsoft.Data.Sqlite;

namespace FeatureOptionCleaner
{
    class Program
    {
        private const string DbConnectionString = "Data Source=C:\\Users\\Johnnie\\Documents\\CET Documents\\Tables\\TBL.db3";

        static void Main(string[] args)
        {
            DeleteFeatureOptionMaterialRefs("HPLAM;13643;ZFPLFT-25;2565;ZEFRDT146;8265;ZFMBC36");
        }

        private static void DeleteFeatureOptionMaterialRefs(string featureCodeCsv, bool dryRun = true)
        {
            var catalogClient = new CatalogClient(DbConnectionString);
            var featureCodes = featureCodeCsv.Split(';').ToList();
            var features = catalogClient.GetFeaturesFromMultiFeatureCodes(featureCodes).ToList();
            var featureOptionInfos =
                catalogClient.FindFeatureOptionInfoReferencesByOwnerIds(features.Select(feature => feature.Id));
            var options = catalogClient.GetOptionsByIds(featureOptionInfos.Select(foi => foi.ValueKey)).Distinct();
            options = catalogClient.GetOptionsByCodes(options.Select(option => option.Code)).Distinct();
            var optionMaterialReferences =
                catalogClient.GetMaterialApplicationsRefsByOwnerKeys(options.Select(option => option.Id)).Distinct();
            var deletedCount =
                catalogClient.DeleteMaterialReferences(optionMaterialReferences.Select(references => references.Id));

            Console.WriteLine($"Number of deleted rows: {deletedCount}");

        }

        private static void DeleteMaterialRefsFromOptions(string optionCodeCsv, bool dryRun = true)
        {
            var catalogClient = new CatalogClient(DbConnectionString);
            var optionCodes = optionCodeCsv.Split(';');
            var options = new List<Option>();
            foreach (var optionCode in optionCodes)
            {
                options.AddRange(catalogClient.GetOptionsFromCode(optionCode));   
            }

            var applicationsRefs = new List<OptionMaterialApplicationsRef>();
            foreach (var option in options)
            {
                applicationsRefs.AddRange(catalogClient.GetMaterialApplicationsRefsFromOwningOptionId(option.Id));
            }

            var deletedCount = 0;
            if (dryRun)
            {
                foreach (var applicationsRef in applicationsRefs)
                {
                    deletedCount += catalogClient.DeleteOptionMaterialReferenceDryRun(applicationsRef.Id);
                }
            }
            else
            {
                foreach (var applicationsRef in applicationsRefs)
                {
                    deletedCount += catalogClient.DeleteOptionMaterialReference(applicationsRef.Id);
                }
            }
            Console.WriteLine($"Number of deleted rows: {deletedCount}");

        }


        private void Other()
        {
            var catalogClient = new CatalogClient(DbConnectionString);
            var features = catalogClient.GetFeatureByCode("TILE12");
            var options = new List<Option>();

            foreach (var feature in features)
            {
                var foundOptions = catalogClient.GetAllOptionsFromFeature(feature.Id);
                foreach (var foundOption in foundOptions)
                {
                    if (!options.Contains(foundOption)) options.Add(foundOption);
                }
            }

            Console.WriteLine(features.Count());

            var optionMaterialReferences = new List<OptionMaterialApplicationsRef>();
            foreach (var option in options)
            {
                var materialRefs = catalogClient.GetMaterialApplicationsRefsFromOwningOptionId(option.Id);
                optionMaterialReferences.AddRange(materialRefs);
            }

            var deletedRowCount = 0;
            foreach (var materialReference in optionMaterialReferences)
            {
                deletedRowCount += catalogClient.DeleteOptionMaterialReferenceDryRun(materialReference.Id);
            }

            Console.WriteLine($"Number of deleted rows: {deletedRowCount}");
        }
    }
}
