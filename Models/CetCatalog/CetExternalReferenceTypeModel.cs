using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstToolsModels.CetCatalog
{
    public class CetExternalReferenceTypeModel
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string PreviewUrl { get; set; }
        public string UsageType { get; set; }
        public string MeasureParameter { get; set; }
    }
}
