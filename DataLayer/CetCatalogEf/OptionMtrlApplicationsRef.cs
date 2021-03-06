using System;
using System.Collections.Generic;

#nullable disable

namespace OstToolsDataLayer.CetCatalogEf
{
    public partial class OptionMtrlApplicationsRef
    {
        public long Id { get; set; }
        public long? OwnerKey { get; set; }
        public long? ValueKey { get; set; }
        public string TypeKey { get; set; }

        public Option Owner { get; set; }

        public MtrlApplication Child { get; set; }
    }
}
