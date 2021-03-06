using System;
using System.Collections.Generic;

#nullable disable

namespace OstToolsDataLayer.CetCatalogEf
{
    public partial class ProductCatalogPriceListRefRef
    {
        public long Id { get; set; }
        public long? OwnerKey { get; set; }
        public string LookupKey { get; set; }
        public long? ValueKey { get; set; }
        public string TypeKey { get; set; }

        public ProductCatalog Owner { get; set; }
    }
}
