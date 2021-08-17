using System;
using System.Collections.Generic;

#nullable disable

namespace OstToolsDataLayer.CetCatalogEf
{
    public partial class DsClassificationType
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Usage { get; set; }
        public string OtherUsage { get; set; }
    }
}
