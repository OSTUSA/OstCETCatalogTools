using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstToolsModels.CetCatalog
{
    public class CetMaterialApplicationModel
    {
        public int Id { get; set; }
        public string MaterialReference { get; set; }
        public string Placement { get; set; }
        public string UniqueKey { get; set; }
    }
}
