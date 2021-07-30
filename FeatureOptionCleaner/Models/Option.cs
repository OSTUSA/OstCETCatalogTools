using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureOptionCleaner.Models
{
    public record Option : CatalogDataType
    {
        public string VariantsTableRef { get; set; }
        public string Vendor { get; set; }
        public string CodeRange { get; set; }
        public string CodeRangeStep { get; set; }
        public string Range { get; set; }
        public string UndefinedSelection { get; set; }
        public string CustomOptionRef { get; set; }
        public string NumericSku { get; set; }
        public string MirrorOptionRef { get; set; }
    }
}
