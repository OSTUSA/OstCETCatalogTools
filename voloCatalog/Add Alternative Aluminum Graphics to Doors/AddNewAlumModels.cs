using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voloCatalog.Add_Alternative_Aluminum_Graphics_to_Doors
{
    public class AddNewAlumModels
    {
       
        public void run()
        {
            var dataHelper = new DataHelper();
            using var context = dataHelper.GetContext();

            var products = from prod in context.DsProductTypes
                           where prod.Code.StartsWith("VDSLFA") || prod.Code.StartsWith("VDSLPA") || prod.Code.StartsWith("VDDSLFA")
                           orderby prod.Id
                           select prod.Code;

            var twoTwoFourList = new List<string>();
            var fourFourFourList = new List<string>();

            foreach (var product in products.ToList())
            {
                var twoTwoFourProd = ("3") + product + ("224.cmsym");
                var fourFourFourProd = ("3") + product + ("444.cmsym");

                twoTwoFourList.Add(twoTwoFourProd);
                fourFourFourList.Add(fourFourFourProd);
            }

            twoTwoFourList = twoTwoFourList.Distinct().ToList();
            fourFourFourList = fourFourFourList.Distinct().ToList();

           using var transaction = context.Database.BeginTransaction();
            foreach (var cmsym in twoTwoFourList)
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

            
            foreach (var cmsym in fourFourFourList)
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

            var extRefs = from extRef in context.PrdExternalRefTypes
                          where extRef.Url.StartsWith("3VDSLFA") || extRef.Url.StartsWith("3VDSLPA") || extRef.Url.StartsWith("3VDDSLFA")
                          select extRef.Url;

            foreach (var extRef in extRefs.ToList())
            {

                Console.WriteLine(extRef);
            }


            transaction.Commit();
        }
    }
}
