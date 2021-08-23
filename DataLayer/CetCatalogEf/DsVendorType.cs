using System;
using System.Collections.Generic;

#nullable disable

namespace OstToolsDataLayer.CetCatalogEf
{
    public partial class DsVendorType
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string UnitMeasure { get; set; }
        public string ConstraintsApplyStyle { get; set; }
        public string ConstraintType { get; set; }

        public List<DataCatalogVendorsRef> CatalogVendorsRefs { get; set; }

        public List<DsVendorTypeTablesRef> VendorTypeTablesRefs { get; set; }
    }
}
