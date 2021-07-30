using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstToolsModels.CetCatalog
{
    public class CetOptionMaterialApplicationReferenceModel
    {
        public int Id { get; set; }
        public int OwnerKey { get; set; }
        public int ValueKey { get; set; }
        public string TypeKey { get; set; }
    }
}
