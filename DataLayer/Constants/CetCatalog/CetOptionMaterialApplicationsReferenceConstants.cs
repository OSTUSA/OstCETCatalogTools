using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Constants.CetCatalog
{
    internal static class CetOptionMaterialApplicationsReferenceConstants
    {
        /// <summary>
        /// Table Name
        /// </summary>
        public static string TableName = "Option_mtrlApplicationsREF";

        /// <summary>
        /// Id
        /// </summary>
        public static string IdColumnName = "id";
        public static int IdColumnIndex = 0;
        public static string IdColumnType = SqLiteConstants.IntegerType;

        /// <summary>
        /// Owner Key - Option Id
        /// </summary>
        public static string OwnerKeyColumnName = "ownerKey";
        public static int OwnerKeyColumnIndex = 1;
        public static string OwnerKeyColumnType = SqLiteConstants.IntegerType;

        /// <summary>
        /// Value Key - Material Application ID
        /// </summary>
        public static string ValueKeyColumnName = "valueKey";
        public static int ValueKeyColumnIndex = 2;
        public static string ValueKeyColumnType = SqLiteConstants.IntegerType;

        /// <summary>
        /// Type Key Column Name
        /// </summary>
        public static string TypeKeyColumnName = "typeKey";
        public static int TypeKeyColumnIndex = 3;
        public static string TypeKeyColumnType = SqLiteConstants.TextType;

    }
}
