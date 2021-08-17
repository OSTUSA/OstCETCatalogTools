using System;
using System.Collections.Generic;

#nullable disable

namespace OstToolsDataLayer.CetCatalogEf
{
    public partial class DsProductRefType
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string VariantsTableRef { get; set; }
        public string UiLvl { get; set; }
        public double? PriceFactor { get; set; }
        public long? PriceRoundingRule { get; set; }
        public string Enterprise { get; set; }
        public string Vendor { get; set; }
        public string PrdCatKey { get; set; }
    }
}
