using System;
using System.Collections.Generic;

#nullable disable

namespace OstToolsDataLayer.CetCatalogEf
{
    public partial class DsTableRowType
    {
        public long Id { get; set; }
        public string Code { get; set; }

        public List<DsTableRowTypeCellsRef> Cells { get; set; }
    }
}
