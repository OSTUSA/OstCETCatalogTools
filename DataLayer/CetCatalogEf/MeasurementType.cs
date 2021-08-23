using System;
using System.Collections.Generic;

#nullable disable

namespace OstToolsDataLayer.CetCatalogEf
{
    public partial class MeasurementType
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public string Unit { get; set; }
        public string System { get; set; }
        public string Value { get; set; }
        public string MeasureParameter { get; set; }
        public string MParam { get; set; }

        public List<DsProductTypeMeasurementsRef> ProductTypeMeasurementsRefs { get; set; } 
    }
}
