using System;
using System.Collections.Generic;

#nullable disable

namespace OstToolsDataLayer.CetCatalogEf
{
    public partial class DsCustomOptionType
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Vendor { get; set; }

        public List<DataCatalogCustomOptionsRef> DataCatalogCustomOptionsRefs { get; set; }

        public List<DsCustomOptionTypeInquiriesRef> InquiriesRefs { get; set; }
    }
}
