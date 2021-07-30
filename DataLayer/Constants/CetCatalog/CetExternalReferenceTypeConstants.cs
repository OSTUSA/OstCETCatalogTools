using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Constants;

namespace OstToolsDataLayer.Constants.CetCatalog
{
    public static class CetExternalReferenceTypeConstants
    {
        public static string TableName = "ExternalRefType";

        /// <summary>
        /// ID
        /// </summary>
        public static string IdColumnName = "id";
        public static int IdColumnIndex = 0;
        public static string IdColumnType = SqLiteConstants.IntegerType;

        /// <summary>
        /// Url to external file
        /// </summary>
        public static string UrlColumnName = "url";
        public static int UrlColumnIndex = 1;
        public static string UrlColumnType = SqLiteConstants.TextType;

        /// <summary>
        /// Preview Url
        /// </summary>
        public static string PreviewUrlColumnName = "previewUrl";
        public static int PreviewUrlColumnIndex = 2;
        public static string PreviewUrlColumnType = SqLiteConstants.TextType;

        /// <summary>
        /// Usage Type
        /// </summary>
        public static string UsageTypeColumnName = "_usageType";
        public static int UsageTypeColumnIndex = 3;
        public static string UsageTypeColumnType = SqLiteConstants.TextType;

        /// <summary>
        /// Measure Parameter
        /// </summary>
        public static string MeasureParameterColumnName = "_measureParam";
        public static int MeasureParameterColumnIndex = 4;
        public static string MeasureParameterColumnType = SqLiteConstants.TextType;
    }
}
