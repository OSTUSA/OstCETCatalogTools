using System;
using System.Collections.Generic;

#nullable disable

namespace OstToolsDataLayer.CetCatalogEf
{
    public partial class OfdaheaderDatum
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string UnitMeasure { get; set; }
        public string ConstraintsApplyStyle { get; set; }
        public string ConstraintType { get; set; }
    }
}
