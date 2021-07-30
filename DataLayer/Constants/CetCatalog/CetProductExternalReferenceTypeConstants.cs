using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Constants;

namespace OstToolsDataLayer.Constants.CetCatalog
{
    public class CetProductExternalReferenceTypeConstants
    {
        /// <summary>
        /// Option Table Name
        /// </summary>
        public static string TableName = "PrdExternalRefType";

        /// <summary>
        /// Id
        /// </summary>
        public static string IdColumnName = "id";
        public static int IdColumnIndex = 0;
        public static string IdColumnType = SqLiteConstants.IntegerType;

        /// <summary>
        /// External Url - Usually symbol path
        /// </summary>
        public static string UrlColumnName = "url";
        public static int UrlColumnIndex = 1;
        public static string UrlColumnType = SqLiteConstants.TextType;

        /// <summary>
        /// Preview Url - Thumbnails
        /// </summary>
        public static string PreviewUrlColumnName = "previewUrl";
        public static int PreviewUrlColumnIndex = 2;
        public static string PreviewUrlColumnType = SqLiteConstants.TextType;

        /// <summary>
        /// Usage Type - Enum value for 3D, Plan View, 3D and Plan View, or undefined.
        /// </summary>
        public static string UsageTypeColumnName = "_usageType";
        public static int UsageTypeColumnIndex = 3;
        public static string UsageTypeColumnType = SqLiteConstants.TextType;

        /// <summary>
        /// Measure Param
        /// </summary>
        public static string MeasureParamColumnName = "_measureParam";
        public static int MeasureParamColumnIndex = 4;
        public static string MeasureParamColumnType = SqLiteConstants.TextType;

        /// <summary>
        /// Code
        /// </summary>
        public static string CodeColumnName = "code";
        public static int CodeColumnIndex = 5;
        public static string CodeColumnType = SqLiteConstants.TextType;

        /// <summary>
        /// Insertion Id
        /// </summary>
        public static string InsertionIdColumnName = "insertionId";
        public static int InsertionIdColumnIndex = 6;
        public static string InsertionIdColumnType = SqLiteConstants.TextType;

        /// <summary>
        /// Pt
        /// </summary>
        public static string PtColumnName = "_pt";
        public static int PtColumnIndex = 7;
        public static string PtColumnType = SqLiteConstants.TextType;
    }
}
