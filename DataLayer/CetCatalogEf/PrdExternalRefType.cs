using System;
using System.Collections.Generic;

#nullable disable

namespace OstToolsDataLayer.CetCatalogEf
{
    public partial class PrdExternalRefType
    {
        public long Id { get; set; }
        public string Url { get; set; }
        public string PreviewUrl { get; set; }
        public string UsageType { get; set; }
        public string MeasureParam { get; set; }
        public string Code { get; set; }
        public string InsertionId { get; set; }
        public string Pt { get; set; }

        public List<DsProductTypeExternalRef> ProductTypeExternalRefs { get; set; }
    }
}
