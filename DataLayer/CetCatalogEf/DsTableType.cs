using System;
using System.Collections.Generic;

#nullable disable

namespace OstToolsDataLayer.CetCatalogEf
{
    public partial class DsTableType
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string TableType { get; set; }

        public List<DsTableTypeHeadsRef> TableTypeHeadsRefs { get; set; }

        public List<DsVendorTypeTablesRef> VendorTypeTablesRefs { get; set; }
    }
}
