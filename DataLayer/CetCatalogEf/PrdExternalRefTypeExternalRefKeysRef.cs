using System;
using System.Collections.Generic;

#nullable disable

namespace OstToolsDataLayer.CetCatalogEf
{
    public partial class PrdExternalRefTypeExternalRefKeysRef
    {
        public long Id { get; set; }
        public long? OwnerKey { get; set; }
        public long? ValueKey { get; set; }
        public string TypeKey { get; set; }

        public PrdExternalRefType Owner { get; set; }

        public DsExternalRefKeyType Child { get; set; }
    }
}
