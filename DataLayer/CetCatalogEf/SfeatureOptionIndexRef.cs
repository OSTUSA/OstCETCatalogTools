using System;
using System.Collections.Generic;

#nullable disable

namespace OstToolsDataLayer.CetCatalogEf
{
    public partial class SfeatureOptionIndexRef
    {
        public long Id { get; set; }
        public long? OwnerKey { get; set; }
        public long? LookupKey { get; set; }
        public string ValueKey { get; set; }
        public string TypeKey { get; set; }

        public Sfeature Owner { get; set; }
    }
}
