using System;
using System.Collections.Generic;

#nullable disable

namespace OstToolsDataLayer.CetCatalogEf
{
    public partial class DsClassificationRefTypeSubRefsRef
    {
        public long Id { get; set; }
        public long? OwnerKey { get; set; }
        public long? ValueKey { get; set; }
        public string TypeKey { get; set; }

        public DsClassificationType Owner { get; set; }

        public DsClassificationRefType Child { get; set; }
    }
}
