using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstToolsModels.CetCatalog
{
    public class CetSMaterialModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string VariantsTableReference { get; set; }
        public int Directional { get; set; }
    }
}
