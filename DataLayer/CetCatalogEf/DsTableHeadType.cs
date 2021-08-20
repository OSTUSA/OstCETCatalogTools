using System;
using System.Collections.Generic;

#nullable disable

namespace OstToolsDataLayer.CetCatalogEf
{
    public partial class DsTableHeadType
    {
        public long Id { get; set; }
        public string Code { get; set; }

        public List<DsTableHeadTypeNamesRef> NamesRefs { get; set; }

        public List<DsTableTypeHeadsRef> TableTypeHeadsRefs { get; set; }
    }
}
