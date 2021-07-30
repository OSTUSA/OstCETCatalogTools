using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using FeatureOptionCleaner.Cleaners;
using FeatureOptionCleaner.Models;

namespace FeatureOptionCleaner
{
    public class CatalogClient
    {
        private readonly FeatureCleaner _featureCleaner;
        private readonly OptionCleaner _optionCleaner;

        public CatalogClient(string dbConnectionString)
        {
            _featureCleaner = new FeatureCleaner(dbConnectionString);
            _optionCleaner = new OptionCleaner(dbConnectionString);
        }

        public Feature GetFeatureById(int id) => _featureCleaner.FindFeatureById(id);

        public IEnumerable<Feature> GetFeatureByCode(string featureCode) => _featureCleaner.FindFeatureByCode(featureCode);

        public IEnumerable<Option> GetAllOptionsFromFeature(int featureId)
        {
            var featureOptionInfos = _featureCleaner.FindFeatureOptionInfoReferenceByOwnerKey(featureId);
            return featureOptionInfos.Select(featureOptionInfo => _optionCleaner.FindOptionById(featureOptionInfo.ValueKey));
        }

        public IEnumerable<Option> GetAllOptionsByCodeFromFeatureId(int featureId)
        {
            var featureOptionInfos = _featureCleaner.FindFeatureOptionInfoReferenceByOwnerKey(featureId);
            var options = featureOptionInfos.Select(featureOptionInfo =>
                _optionCleaner.FindOptionById(featureOptionInfo.ValueKey)).ToList();
            var optionCodes = options.Select(op => op.Code);
            var optionsWithMatchingCodes = new List<Option>();
            foreach (var optionCode in optionCodes)
            {
                optionsWithMatchingCodes.AddRange(_optionCleaner.FindOptionsByCode(optionCode));
            }

            return optionsWithMatchingCodes;
        }

        public IEnumerable<OptionMaterialApplicationsRef> GetMaterialApplicationsRefsFromOwningOptionId(int optionId) =>
            _optionCleaner.GetMaterialApplicationsRefsByOwnerKey(optionId);

        public int DeleteOptionMaterialReferenceDryRun(int id) => _optionCleaner.DeleteMaterialReferenceDryRun(id);

        public int DeleteOptionMaterialReference(int id) => _optionCleaner.DeleteMaterialReference(id);

        public IEnumerable<Option> GetOptionsFromCode(string code) => _optionCleaner.FindOptionsByCode(code);

        public IEnumerable<Feature> GetFeaturesFromMultiFeatureCodes(IEnumerable<string> featureCodes) =>
            _featureCleaner.FindFeaturesByMultiCodes(featureCodes).Distinct();

        public IEnumerable<FeatureOptionInfoReference>
            FindFeatureOptionInfoReferencesByOwnerIds(IEnumerable<int> ids) =>
            _featureCleaner.FindFeatureOptionInfoReferencesByOwnerKeys(ids);

        public IEnumerable<Option> GetOptionsByIds(IEnumerable<int> ids) => _optionCleaner.GetOptionsByIds(ids);

        public IEnumerable<Option> GetOptionsByCodes(IEnumerable<string> codes) =>
            _optionCleaner.GetOptionsByCodes(codes);

        public IEnumerable<OptionMaterialApplicationsRef>
            GetMaterialApplicationsRefsByOwnerKeys(IEnumerable<int> ids) =>
            _optionCleaner.GetMaterialApplicationsRefsByOwnerKeys(ids);

        public int DeleteMaterialReferencesDryRun(IEnumerable<int> ids) =>
            _optionCleaner.DeleteMaterialReferencesDryRun(ids);

        public int DeleteMaterialReferences(IEnumerable<int> ids) => _optionCleaner.DeleteMaterialReferences(ids);
    }
}
