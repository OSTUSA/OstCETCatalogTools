using System;
using System.Collections.Generic;

#nullable disable

namespace OstToolsDataLayer.CetCatalogEf
{
    public partial class OptionPriceType
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string PricelistRef { get; set; }
        public double? Value { get; set; }
    }
}
