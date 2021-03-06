using System;
using System.Collections.Generic;

#nullable disable

namespace OstToolsDataLayer.CetCatalogEf
{
    public partial class PriceTypeSeqPriceTypesRef
    {
        public long Id { get; set; }
        public long? OwnerKey { get; set; }
        public long? ValueKey { get; set; }
        public string TypeKey { get; set; }

        public PriceTypeSeq Owner { get; set; }

        public PriceType Child { get; set; }
    }
}
