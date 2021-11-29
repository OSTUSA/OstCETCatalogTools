using System;
using System.Collections.Generic;

#nullable disable

namespace OstToolsDataLayer.CetCatalogEf
{
    public partial class Url
    {
        public long Id { get; set; }
        public string Scheme { get; set; }
        public string FileNameBase { get; set; }
    }
}
