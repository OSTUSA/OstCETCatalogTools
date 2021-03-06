using System;
using System.Collections.Generic;

#nullable disable

namespace OstToolsDataLayer.CetCatalogEf
{
    public partial class DsProductTypeFeatureRefsRef
    {
        public long Id { get; set; }
        public long? OwnerKey { get; set; }
        public long? ValueKey { get; set; }
        public string TypeKey { get; set; }

        public DsProductType Owner { get; set; }

        public DsiFeatureRefType Child { get; set; }
    }
}
