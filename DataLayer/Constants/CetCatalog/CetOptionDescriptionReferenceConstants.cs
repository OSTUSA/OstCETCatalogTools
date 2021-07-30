using DataLayer.Constants;

namespace OstToolsDataLayer.Constants.CetCatalog
{
    internal static class CetOptionDescriptionReferenceConstants
    {
        /// <summary>
        /// Table Name
        /// </summary>
        public static string TableName = "Option_descriptionsREF";

        /// <summary>
        /// Id
        /// </summary>
        public static string IdColumnName = "id";
        public static int IdColumnIndex = 0;
        public static string IdColumnType = SqLiteConstants.IntegerType;

        /// <summary>
        /// Owner Key
        /// </summary>
        public static string OwnerKeyColumnName = "ownerKey";
        public static int OwnerKeyColumnIndex = 1;
        public static string OwnerKeyColumnType = SqLiteConstants.IntegerType;

        /// <summary>
        /// Lookup Key
        /// </summary>
        public static string LookupKeyColumnName = "lookupKey";
        public static int LookupKeyColumnIndex = 2;
        public static string LookupKeyColumnType = SqLiteConstants.TextType;

        /// <summary>
        /// Value Key
        /// </summary>
        public static string ValueKeyColumnName = "valueKey";
        public static int ValueKeyColumnIndex = 3;
        public static string ValueKeyColumnType = SqLiteConstants.TextType;

        /// <summary>
        /// Type Key Column Name
        /// </summary>
        public static string TypeKeyColumnName = "typeKey";
        public static int TypeKeyColumnIndex = 4;
        public static string TypeKeyColumnType = SqLiteConstants.TextType;
    }
}
