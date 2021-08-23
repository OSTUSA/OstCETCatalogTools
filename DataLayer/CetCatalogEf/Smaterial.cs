using System;
using System.Collections.Generic;

#nullable disable

namespace OstToolsDataLayer.CetCatalogEf
{
    public partial class Smaterial
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string VariantsTableRef { get; set; }
        public long? Directional { get; set; }

        public List<DataCatalogMaterialsRef> CatalogMaterialsRefs { get; set; }

        public List<SmaterialDescriptionsRef> DescriptionsRefs { get; set; }

        public List<SmaterialExternalRef> ExternalRefs { get; set; }
    }
}
