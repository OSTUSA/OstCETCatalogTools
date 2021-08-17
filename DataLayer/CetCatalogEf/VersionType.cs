using System;
using System.Collections.Generic;

#nullable disable

namespace OstToolsDataLayer.CetCatalogEf
{
    public partial class VersionType
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Effectivedate { get; set; }
        public string Expirationdate { get; set; }
    }
}
