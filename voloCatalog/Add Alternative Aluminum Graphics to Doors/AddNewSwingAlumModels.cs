using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voloCatalog.Add_Alternative_Aluminum_Graphics_to_Doors
{
    internal class AddNewSwingAlumModels
    {

        public void run()
        {
            var dataHelper = new Add_Alternative_Aluminum_Graphics_to_Doors.DataHelper();
            using var context = dataHelper.GetContext();

            var products = from prod in context.DsProductTypes
                           where prod.Code.StartsWith("VDUA")
                           orderby prod.Id
                           select prod.Code;

            var fourFourTenList = new List<string>();

            using var transaction = context.Database.BeginTransaction();
            foreach (var product in products.ToList())
            {
                var fourFourTenProd = ("3") + product + ("4410.cmsym");
               
                fourFourTenList.Add(fourFourTenProd);
            }

            fourFourTenList = fourFourTenList.Distinct().ToList();

            
            foreach (var cmsym in fourFourTenList)
            {
                var prod = new PrdExternalRefType();
                prod.Url = cmsym;
                prod.UsageType = "1";
                prod.Pt = "1";
                prod.PreviewUrl = string.Empty;
                prod.MeasureParam = string.Empty;
                prod.Code = string.Empty;
                prod.InsertionId = string.Empty;

                context.PrdExternalRefTypes.Add(prod);
                context.SaveChanges();
            }

            transaction.Commit();
        }
    }
}
