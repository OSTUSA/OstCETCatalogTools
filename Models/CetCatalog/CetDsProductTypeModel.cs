using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstToolsModels.CetCatalog
{
    public class CetDsProductTypeModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string VariantsTableReference { get; set; }
        public string Enterprise { get; set; }
        public string Vendor { get; set; }
        public string Prices { get; set; }
        public int OmitOnOrder { get; set; }
        public int OmitPartNumberOnStyleNr { get; set; }
        public string MirrorProductReference { get; set; }
        public float MirrorAngleOfSymmetry { get; set; }
        public int PackageCount { get; set; }
    }
}
