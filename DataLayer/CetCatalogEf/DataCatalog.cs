using System;
using System.Collections.Generic;

#nullable disable

namespace OstToolsDataLayer.CetCatalogEf
{
    public partial class DataCatalog
    {
        public long Id { get; set; }
        public string Enterprise { get; set; }
        public string SymbolsDir { get; set; }
        public string TexturesDir { get; set; }
        public string ThumbsDir { get; set; }
        public string ToolboxDir { get; set; }
        public string AnonymousDir { get; set; }
        public string ExtensionPolicy { get; set; }
        public string PackagePolicy { get; set; }
        public long? DevCid { get; set; }

        public List<DataCatalogApplicationAreasRef> ApplicationAreasRefs { get; set; }

        public List<DataCatalogCatalogsRef> CatalogsRefs { get; set; }

        public List<DataCatalogClassificationsRef> ClassificationsRefs { get; set; }

        public List<DataCatalogCustomOptionsRef> CustomOptionsRefs { get; set; } 

        public List<DataCatalogFeaturesRef> FeaturesRefs { get; set; }

        public List<DataCatalogMaterialsRef> MaterialsRefs { get; set; }

        public List<DataCatalogPricelistsRef> PricelistsRefs { get; set; }

        public List<DataCatalogProductsRef> ProductsRefs { get; set; }

        public List<DataCatalogVendorsRef> VendorsRefs { get; set; }

        public List<DataCatalogscatalogsRef> DataCatalogsRef { get; set; }
    }
}
