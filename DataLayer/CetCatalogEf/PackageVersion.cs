using System;
using System.Collections.Generic;

#nullable disable

namespace OstToolsDataLayer.CetCatalogEf
{
    public partial class PackageVersion
    {
        public long Id { get; set; }
        public string Package { get; set; }
        public string Version { get; set; }
    }
}
