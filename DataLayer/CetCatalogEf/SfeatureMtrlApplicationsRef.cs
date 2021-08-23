﻿using System;
using System.Collections.Generic;

#nullable disable

namespace OstToolsDataLayer.CetCatalogEf
{
    public partial class SfeatureMtrlApplicationsRef
    {
        public long Id { get; set; }
        public long? OwnerKey { get; set; }
        public long? ValueKey { get; set; }
        public string TypeKey { get; set; }

        public Sfeature Owner { get; set; }

        public MtrlApplication Child { get; set; }
    }
}
