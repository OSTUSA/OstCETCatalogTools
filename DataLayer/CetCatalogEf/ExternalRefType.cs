using System;
using System.Collections.Generic;

#nullable disable

namespace OstToolsDataLayer.CetCatalogEf
{
    public partial class ExternalRefType
    {
        public long Id { get; set; }
        public string Url { get; set; }
        public string PreviewUrl { get; set; }
        public string UsageType { get; set; }
        public string MeasureParam { get; set; }
    }
}
