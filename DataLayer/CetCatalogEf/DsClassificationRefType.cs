using System;
using System.Collections.Generic;

#nullable disable

namespace OstToolsDataLayer.CetCatalogEf
{
    public partial class DsClassificationRefType
    {
        public long Id { get; set; }
        public string Code { get; set; }

        public List<DsClassificationRefTypeSubRefsRef> ClassificationRefTypeSubRefsRefs { get; set; }

        public List<DsProductTypeClassificationRefsRef> ProductTypeClassificationRefsRefs { get; set; }
    }
}
