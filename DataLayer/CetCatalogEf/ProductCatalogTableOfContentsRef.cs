using System;
using System.Collections.Generic;

#nullable disable

namespace OstToolsDataLayer.CetCatalogEf
{
    public partial class ProductCatalogTableOfContentsRef
    {
        public long Id { get; set; }
        public long? OwnerKey { get; set; }
        public long? ValueKey { get; set; }
        public string TypeKey { get; set; }

        public ProductCatalog Owner { get; set; }

        public ProductLevel Child { get; set; }
    }
}
