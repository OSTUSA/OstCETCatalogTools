using System;
using System.Collections.Generic;

#nullable disable

namespace OstToolsDataLayer.CetCatalogEf
{
    public partial class MtrlApplication
    {
        public long Id { get; set; }
        public string MtrlRef { get; set; }
        public string Placement { get; set; }
        public string UniqueKey { get; set; }
    }
}
