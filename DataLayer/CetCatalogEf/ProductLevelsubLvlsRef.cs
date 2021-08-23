using System;
using System.Collections.Generic;

#nullable disable

namespace OstToolsDataLayer.CetCatalogEf
{
    public partial class ProductLevelsubLvlsRef
    {
        public long Id { get; set; }
        public long? OwnerKey { get; set; }
        public long? ValueKey { get; set; }
        public string TypeKey { get; set; }

        public ProductLevel Owner { get; set; }

        public ProductLevel ChildProductLevel { get; set; }

        public DsProductRefType ChildDsProductRefType { get; set; }
    }
}
