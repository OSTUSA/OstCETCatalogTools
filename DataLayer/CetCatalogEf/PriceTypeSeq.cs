using System;
using System.Collections.Generic;

#nullable disable

namespace OstToolsDataLayer.CetCatalogEf
{
    public partial class PriceTypeSeq
    {
        public long Id { get; set; }
        public string Code { get; set; }

        public List<PriceTypeSeqPriceTypesRef> PriceTypeSeqPriceTypesRefs { get; set; }
    }
}
