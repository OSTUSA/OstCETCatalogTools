using System;
using System.Collections.Generic;

#nullable disable

namespace OstToolsDataLayer.CetCatalogEf
{
    public partial class PlacementType
    {
        public long Id { get; set; }
        public string Origin { get; set; }
        public string Offset { get; set; }
        public string RotationA { get; set; }
        public string RotationP { get; set; }
        public string Scalar { get; set; }
    }
}
