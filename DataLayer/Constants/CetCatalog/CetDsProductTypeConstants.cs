using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Constants;

namespace OstToolsDataLayer.Constants.CetCatalog
{
    public class CetDsProductTypeConstants
    {
        /// <summary>
        /// Option Table Name
        /// </summary>
        public static string TableName = "DsProductType";

        /// <summary>
        /// Id
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
        /// Variants Table Reference
        /// </summary>
        public static string VariantsTableReferenceColumnName = "_variantsTableRef";
        public static int VariantsTableReferenceColumnIndex = 2;
        public static string VariantsTableReferenceColumnType = SqLiteConstants.TextType;

        /// <summary>
        /// Enterprise
        /// </summary>
        public static string EnterpriseColumnName = "enterprise";
        public static int EnterpriseColumnIndex = 3;
        public static string EnterpriseColumnType = SqLiteConstants.TextType;

        /// <summary>
        /// Vendor
        /// </summary>
        public static string VendorColumnName = "vendor";
        public static int VendorColumnIndex = 4;
        public static string VendorColumnType = SqLiteConstants.TextType;

        /// <summary>
        /// Prices
        /// </summary>
        public static string PricesColumnName = "_prices";
        public static int PricesColumnIndex = 5;
        public static string PricesColumnType = SqLiteConstants.TextType;

        /// <summary>
        /// Omit On Order
        /// </summary>
        public static string OmitOnOrderColumnName = "_omitOnOrder";
        public static int OmitOnOrderColumnIndex = 6;
        public static string OmitOnOrderColumnType = SqLiteConstants.IntegerType;

        /// <summary>
        /// Omit Part Number On Style Nr - IDK what NR stands for.
        /// </summary>
        public static string OmitPartNumberOnStyleNrColumnName = "_omitPNOnStyleNr";
        public static int OmitPartNumberOnStyleNrColumnIndex = 7;
        public static string OmitPartNumberOnStyleNrColumnType = SqLiteConstants.IntegerType;

        /// <summary>
        /// Mirror Product Reference Column Name 
        /// </summary>
        public static string MirrorProductReferenceColumnName = "_mirrPrdRef";
        public static int MirrorProductReferenceColumnIndex = 8;
        public static string MirrorProductReferenceColumnType = SqLiteConstants.TextType;

        /// <summary>
        /// Mirror Angle of Symmetry
        /// </summary>
        public static string MirrorAngleOfSymmetryColumnName = "_mirrAngleOfSymmetry";
        public static int MirrorAngleOfSymmetryColumnIndex = 9;
        public static string MirrorAngleOfSymmetryColumnType = SqLiteConstants.RealType;

        /// <summary>
        /// Package Count
        /// </summary>
        public static string PackageCountColumnName = "_packageCount";
        public static int PackageCountColumnIndex = 10;
        public static string PackageCountColumnType = SqLiteConstants.IntegerType;
    }
}
