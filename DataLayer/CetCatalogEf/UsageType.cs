using System;
using System.Collections.Generic;

#nullable disable

namespace OstToolsDataLayer.CetCatalogEf
{
    public partial class UsageType
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public string OtherType { get; set; }
        public string Quality { get; set; }
        public string OtherQuality { get; set; }
    }
}
