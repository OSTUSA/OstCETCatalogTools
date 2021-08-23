using System;
using System.Collections.Generic;

#nullable disable

namespace OstToolsDataLayer.CetCatalogEf
{
    public partial class PricelistType
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string PriceId { get; set; }
        public string Currency { get; set; }
        public double? CurrencyRate { get; set; }
        public long? CurrencyRoundingRule { get; set; }
        public string Effectivedate { get; set; }
        public string Expirationdate { get; set; }

        public List<DataCatalogPricelistsRef> DataCatalogPricelistRef { get; set; }
        
        public List<PricelistTypeDescriptionsRef> PricelistTypeDescriptionsRefs { get; set; }
    }
}
