using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstToolsCommon.Parsers.Models
{
    public class KeyModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string PartNumber { get; set; }

        public string PartDescription { get; set; }

        public double PriceOne { get; set; }

        public double PriceTwo { get; set; }

        public double PriceThree { get; set; }

        public double PriceFour { get; set; }

        public double PriceFive { get; set; }

        public double Weight { get; set; }

        public double Volume { get; set; }

        public double Height { get; set; }

        public double Width { get; set; }

        public double Depth { get; set; }


        // G0 aka G# = DsiFeatureRefType Code
        // CT1 aka CT# = DsClassificationRefType CT = Classification Type
    }
}
