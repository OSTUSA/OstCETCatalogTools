using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureOptionCleaner.Models
{
    public record Feature : CatalogDataType
    {
        public string DefaultOptionRef { get; set; }
        public string MultipleSelection { get; set; }
        public string OptionalSelection { get; set; }
        public string FunctionalSelection { get; set; }
        public string UnitMeasure { get; set; }
        public string GroupCode { get; set; }
        public string DataType { get; set; }
        public string DecimalPlaces { get; set; }
        public string HasMtrl { get; set; }
        public string HasGraphic { get; set; }
        public string HasRange { get; set; }
        public string VariantsTableRef { get; set; }
        public string Vendor { get; set; }
    }
}
