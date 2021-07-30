using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Constants;

namespace OstToolsDataLayer.Constants.CetCatalog
{
    public static class CetSMaterialConstants
    {
        public static string TableName = "SMaterial";

        /// <summary>
        /// Id
        /// </summary>
        public static string IdColumnName = "id";
        public static int IdColumnIndex = 0;
        public static string IdColumnType = SqLiteConstants.IntegerType;

        /// <summary>
        /// Material Code
        /// </summary>
        public static string CodeColumnName = "code";
        public static int CodeColumnIndex = 1;
        public static string CodeColumnType = SqLiteConstants.TextType;

        /// <summary>
        /// Variants Table Reference
        /// </summary>
        public static string VariantsTableReferenceColumnName = "_variantsTableRef";
        public static int VariantsTableReferenceColumnIndex = 2;
        public static string VariantsTableReferenceColumnType = SqLiteConstants.TextType;

        /// <summary>
        /// Directional
        /// </summary>
        public static string DirectionalColumnName = "directional";
        public static int DirectionalColumnIndex = 3;
        public static string DirectionalColumnType = SqLiteConstants.IntegerType;
    }
}
