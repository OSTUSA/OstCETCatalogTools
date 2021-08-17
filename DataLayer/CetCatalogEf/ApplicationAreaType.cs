using System;
using System.Collections.Generic;

#nullable disable

namespace OstToolsDataLayer.CetCatalogEf
{
    public partial class ApplicationAreaType
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string SurfaceId { get; set; }
        public string MtrlRef { get; set; }
    }
}
