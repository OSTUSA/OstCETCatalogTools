using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Constants;

namespace OstToolsDataLayer.Constants.CetCatalog
{
    public static class CetMaterialApplicationConstants
    {
        /// <summary>
        /// Table Name
        /// </summary>
        public static string TableName = "MtrlApplication";

        /// <summary>
        /// Id 
        /// </summary>
        public static string IdColumnName = "id";
        public static int IdColumnIndex = 0;
        public static string IdColumnType = SqLiteConstants.IntegerType;

        /// <summary>
        /// Material Reference Code
        /// </summary>
        public static string MaterialReferenceColumnName = "mtrlRef";
        public static int MaterialReferenceColumnIndex = 1;
        public static string MaterialReferenceColumnType = SqLiteConstants.TextType;

        /// <summary>
        /// Placement
        /// </summary>
        public static string PlacementColumnName = "placement";
        public static int PlacementColumnIndex = 2;
        public static string PlacementColumnType = SqLiteConstants.TextType;

        /// <summary>
        /// Unique Key
        /// </summary>
        public static string UniqueKeyColumnName = "_uniqueKey";
        public static int UniqueKeyColumnIndex = 3;
        public static string UniqueKeyColumnType = SqLiteConstants.TextType;
    }
}
