using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Constants;

namespace OstToolsDataLayer.Constants.CetCatalog
{
    internal static class CetApplicationAreaTypeConstants
    {
        /// <summary>
        /// Table Name
        /// </summary>
        public static string TableName = "ApplicationAreaType";

        /// <summary>
        /// Id Column
        /// </summary>
        public static string IdColumnName = "id";
        public static int IdColumnIndex = 0;
        public static string IdColumnType = SqLiteConstants.IntegerType;

        /// <summary>
        /// Code 
        /// </summary>
        public static string CodeColumnName = "code";
        public static int CodeColumnIndex = 1;
        public static string CodeColumnType = SqLiteConstants.TextType;

        /// <summary>
        /// Surface Id 
        /// </summary>
        public static string SurfaceIdColumnName = "_surfaceId";
        public static int SurfaceIdColumnIndex = 2;
        public static string SurfaceIdColumnType = SqLiteConstants.TextType;

        /// <summary>
        /// Material Reference
        /// </summary>
        public static string MaterialReferenceColumnName = "_mtrlRef";
        public static int MaterialReferenceColumnIndex = 3;
        public static string MaterialReferenceColumnType = SqLiteConstants.TextType;
    }
}
