using System;
using System.Collections.Generic;

#nullable disable

namespace OstToolsDataLayer.CetCatalogEf
{
    public partial class DataCatalogs
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public double? DbVersion { get; set; }
    }
}
