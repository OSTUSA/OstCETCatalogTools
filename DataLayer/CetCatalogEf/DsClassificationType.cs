using System;
using System.Collections.Generic;

#nullable disable

namespace OstToolsDataLayer.CetCatalogEf
{
    public partial class DsClassificationType
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Usage { get; set; }
        public string OtherUsage { get; set; }

        public DataCatalogClassificationsRef DataCatalogClassificationsRef { get; set; }

        public List<DsClassificationRefTypeSubRefsRef> SubRefsRefs { get; set; }

        public List<DsClassificationTypeClassificationsRef> OwnerOfReferences { get; set; }

        public List<DsClassificationTypeClassificationsRef> OwnedByReferences { get; set; }
    }
}
