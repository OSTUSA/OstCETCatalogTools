using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OstToolsDataLayer.CetCatalogEf;

namespace OstToolsBc.CetCatalogEfBc
{
    public class OptionBc
    {
        private readonly CetCatalogContext _catalog;

        public OptionBc(CetCatalogContext catalog)
        {
            _catalog = catalog;
        }

        public async Task MatchMaterialsToOptions()
        {
            var materials = await _catalog.MtrlApplications.ToListAsync();
            var options = await _catalog.Options.ToListAsync();
            var optionMaterialRefs = await _catalog.OptionMtrlApplicationsRefs.ToListAsync();
        }

        private IEnumerable<Option> JoinOptionToOptionMaterialRefs(IEnumerable<MtrlApplication> mtrlApplications,
            IEnumerable<Option> options,
            IEnumerable<OptionMtrlApplicationsRef> optionMtrlApplicationsRefs)
        {
            return null;
        }

        private void JoinOptionToOptionMtrlApplicationRefs(IEnumerable<Option> optionEnumerable,
            IEnumerable<OptionMtrlApplicationsRef> optionMtrlApplicationsRefsEnumerable)
        {
            // var options =
            //     from option in optionEnumerable
            //     join mtrlApp in optionMtrlApplicationsRefsEnumerable
            //         on option.Id equals mtrlApp.OwnerKey
            //         select (mtrlApp.
        }

    }
}
