using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureOptionCleaner.Models
{
    public record CatalogDataType
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Enterprise { get; set; }
        public string Prices { get; set; }
        public string OmitOnOrder { get; set; }
        public string OmitPNOnStyleNr { get; set; }
        public string MirrPrdRef { get; set; }
        public string MirrAngleOfSymmetry { get; set; }
        public string PackageCount { get; set; }
        public string SkuSelection { get; set; }
        public string Delimiter { get; set; }
    }

}
