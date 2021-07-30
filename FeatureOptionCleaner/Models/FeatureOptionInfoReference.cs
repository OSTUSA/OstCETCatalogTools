using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureOptionCleaner.Models
{
    public record FeatureOptionInfoReference
    {
        public int Id { get; set; }
        public int OwnerKey { get; set; }
        public string LookupKey { get; set; }
        public int ValueKey { get; set; }
        public string TypeKey { get; set; }
    }
}
