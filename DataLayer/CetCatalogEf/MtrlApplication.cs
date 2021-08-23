using System;
using System.Collections.Generic;

#nullable disable

namespace OstToolsDataLayer.CetCatalogEf
{
    public partial class MtrlApplication
    {
        public long Id { get; set; }
        public string MtrlRef { get; set; }
        public string Placement { get; set; }
        public string UniqueKey { get; set; }

        public List<DsProductTypeMtrlApplicationsRef> ProductTypeMtrlApplicationsRefs { get; set; }

        public List<MtrlApplicationareaRefRef> MtrlApplicationareaRefs { get; set; }

        public List<OptionMtrlApplicationsRef> OptionMtrlApplicationsRefs { get; set; }

        public List<SfeatureMtrlApplicationsRef> SfeatureMtrlApplicationsRefs { get; set; }
    }
}
