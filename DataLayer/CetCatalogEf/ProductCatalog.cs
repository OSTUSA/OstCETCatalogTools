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
    }
}
