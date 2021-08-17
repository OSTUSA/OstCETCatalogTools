using System;
using System.Collections.Generic;

#nullable disable

namespace OstToolsDataLayer.CetCatalogEf
{
    public partial class Sfeature
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string VariantsTableRef { get; set; }
        public string Enterprise { get; set; }
        public string Vendor { get; set; }
        public string Prices { get; set; }
        public long? OmitOnOrder { get; set; }
        public long? OmitPnonStyleNr { get; set; }
        public string MirrPrdRef { get; set; }
        public double? MirrAngleOfSymmetry { get; set; }
        public long? PackageCount { get; set; }
        public string DefaultOptionRef { get; set; }
        public long? MultipleSelection { get; set; }
        public long? OptionalSelection { get; set; }
        public long? FunctionalSelection { get; set; }
        public long? SkuSelection { get; set; }
        public string UnitMeasure { get; set; }
        public string GroupCode { get; set; }
        public string DataType { get; set; }
        public long? DecimalPlaces { get; set; }
        public string Delimiter { get; set; }
        public long? HasMtrl { get; set; }
        public long? HasGraphic { get; set; }
        public long? HasRange { get; set; }
    }
}
