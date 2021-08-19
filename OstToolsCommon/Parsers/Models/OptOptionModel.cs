using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstToolsCommon.Parsers.Models
{
    public class OptOptionModel
    {
        /// <summary>
        /// Option Code - ON
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Option Description - OD
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Option Price in price book - O1
        /// </summary>
        public double Price1 { get; set; }

        /// <summary>
        /// Option Price in price book - O2
        /// </summary>
        public double Price2 { get; set; }

        /// <summary>
        /// Option Price in price book - O3
        /// </summary>
        public double Price3 { get; set; }

        /// <summary>
        /// Option Price in price book - O4
        /// </summary>
        public double Price4 { get; set; }

        /// <summary>
        /// Option Price in price book - O5
        /// </summary>
        public double Price5 { get; set; }

        /// <summary>
        /// Sub-feature code - SO
        /// </summary>
        public string SubFeatureCode { get; set; }
    }
}
