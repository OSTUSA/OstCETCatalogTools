using System;
using System.Collections.Generic;

#nullable disable

namespace OstToolsDataLayer.CetCatalogEf
{
    public partial class DataCatalogMaterialsRef
    {
        public long Id { get; set; }
        public long? OwnerKey { get; set; }
        public string LookupKey { get; set; }
        public long? ValueKey { get; set; }
        public string TypeKey { get; set; }

        public DataCatalog Owner { get; set; }

        public Smaterial Child { get; set; }
    }
}
