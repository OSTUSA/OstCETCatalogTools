using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Constants;

namespace OstToolsDataLayer.Constants.CetCatalog
{
    internal static class CetSMaterialExternalReferenceConstants
    {
        public static string TableName = "SMaterial_externalREF";

        /// <summary>
        /// Id
        /// </summary>
        public static string IdColumnName = "id";
        public static int IdColumnIndex = 0;
        public static string IdColumnType = SqLiteConstants.IntegerType;

        /// <summary>
        /// SMaterial Key
        /// </summary>
        public static string OwnerKeyColumnName = "ownerKey";
        public static int OwnerKeyColumnIndex = 1;
        public static string OwnerKeyColumnType = SqLiteConstants.IntegerType;

        /// <summary>
        /// External Reference Key
        /// </summary>
        public static string ValueKeyColumnName = "valueKey";
        public static int ValueKeyColumnIndex = 2;
        public static string ValueKeyColumnType = SqLiteConstants.IntegerType;

        /// <summary>
        /// External reference type key
        /// </summary>
        public static string TypeKeyColumnName = "typeKey";
        public static int TypeKeyColumnIndex = 3;
        public static string TypeKeyColumnType = SqLiteConstants.TextType;
    }
}
