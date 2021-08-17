using System;
using System.Collections.Generic;

#nullable disable

namespace OstToolsDataLayer.CetCatalogEf
{
    public partial class DataCatalog
    {
        public long Id { get; set; }
        public string Enterprise { get; set; }
        public string SymbolsDir { get; set; }
        public string TexturesDir { get; set; }
        public string ThumbsDir { get; set; }
        public string ToolboxDir { get; set; }
        public string AnonymousDir { get; set; }
        public string ExtensionPolicy { get; set; }
        public string PackagePolicy { get; set; }
        public long? DevCid { get; set; }
    }
}
