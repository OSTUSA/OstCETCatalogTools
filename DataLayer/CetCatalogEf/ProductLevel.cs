using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace OstToolsDataLayer.CetCatalogEf
{
    public partial class ProductLevel
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string VariantsTableRef { get; set; }
        public string UiLvl { get; set; }
        public double? PriceFactor { get; set; }
        public long? PriceRoundingRule { get; set; }

        public List<ProductCatalogTableOfContentsRef> TableOfContentsRefs { get; set; }

        public List<ProductLevelDescriptionsRef> DescriptionsRefs { get; set; }

        [NotMapped]
        public List<ProductLevelsubLvlsRef> OwnerOfSubLevelRefs { get; set; }

        [NotMapped]
        public List<ProductLevelsubLvlsRef> OwnedBySubLevelRefs { get; set; }
    }
}
