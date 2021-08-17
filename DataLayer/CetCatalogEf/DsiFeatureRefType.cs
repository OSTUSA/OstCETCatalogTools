using System;
using System.Collections.Generic;

#nullable disable

namespace OstToolsDataLayer.CetCatalogEf
{
    public partial class DsiFeatureRefType
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string DefaultOptionRef { get; set; }
        public string SelectedOptionRef { get; set; }
    }
}
