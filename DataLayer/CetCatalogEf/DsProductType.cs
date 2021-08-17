using System;
using System.Collections.Generic;

#nullable disable

namespace OstToolsDataLayer.CetCatalogEf
{
    public partial class DsProductType
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
    }
}
