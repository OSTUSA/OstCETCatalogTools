using System;
using System.Collections.Generic;

#nullable disable

namespace OstToolsDataLayer.CetCatalogEf
{
    public partial class DsCustomOptionTypeInquiriesRef
    {
        public long Id { get; set; }
        public long? OwnerKey { get; set; }
        public long? ValueKey { get; set; }
        public string TypeKey { get; set; }

        public DsCustomOptionType Owner { get; set; }

        public DsCustomInquiryType Child { get; set; }
    }
}
