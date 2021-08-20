using System;
using System.Collections.Generic;

#nullable disable

namespace OstToolsDataLayer.CetCatalogEf
{
    public partial class DsCustomInquiryType
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string OtherOrderMapping { get; set; }
        public string Expression { get; set; }
        public double? CodeMin { get; set; }
        public double? CodeMax { get; set; }
        public double? CodeIncr { get; set; }

        public List<DsCustomInquiryTypeDescriptionsRef> DescriptionsRefs { get; set; }
    }
}
