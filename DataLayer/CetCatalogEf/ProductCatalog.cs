using System;
using System.Collections.Generic;

#nullable disable

namespace OstToolsDataLayer.CetCatalogEf
{
    public partial class ProductCatalog
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Versions { get; set; }
        public string LeadTimeProgramRef { get; set; }

        public DataCatalogCatalogsRef CatalogCatalogsRef { get; set; }

        public List<ProductCatalogDescriptionsRef> DescriptionsRefs { get; set; }

        public List<ProductCatalogEnterpriseRefRef> EnterpriseRefRefs { get; set; }

        public List<ProductCatalogNamesRef> NamesRefs { get; set; }

        public List<ProductCatalogPriceListRefRef> PriceListRefRefs { get; set; }

        public List<ProductCatalogTableOfContentsRef> TableOfContentsRefs { get; set; }
    }
}
