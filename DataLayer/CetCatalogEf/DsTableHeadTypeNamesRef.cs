using System;
using System.Collections.Generic;

#nullable disable

namespace OstToolsDataLayer.CetCatalogEf
{
    public partial class DsTableHeadTypeNamesRef
    {
        public long Id { get; set; }
        public long? OwnerKey { get; set; }
        public string ValueKey { get; set; }
        public string TypeKey { get; set; }

        public DsTableHeadType Owner { get; set; }
    }
}
