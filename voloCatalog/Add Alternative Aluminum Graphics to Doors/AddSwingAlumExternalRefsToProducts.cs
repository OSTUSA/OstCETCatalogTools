using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voloCatalog.Add_Alternative_Aluminum_Graphics_to_Doors
{
    internal class AddSwingAlumExternalRefsToProducts
    {
        //Execute the contents of this file
        public void run()
        {
            var dataHelper = new Add_Alternative_Aluminum_Graphics_to_Doors.DataHelper();

            using var context = dataHelper.GetContext(); //Get te code Representation of the CET Catalog
            var products = from prod in context.DsProductTypes
                           where prod.Code.StartsWith("VDUA") //Grab all the sliding door products
                           orderby prod.Id
                           select prod;

             makeTheChanges(context, products.ToList());
            //viewDbEntries(dataHelper, products.ToList());
        }


        //Print a bunch of the relevant output stuff
        public void viewDbEntries(DataHelper dataHelper, List<DsProductType> products)
        {
            foreach (var product in products)
            {
                Console.WriteLine(product.Code);
                foreach (var thing in dataHelper.GetExternalRefsByOwnerKey(product.Id))
                {
                    foreach (var stuff in dataHelper.GetProductExternalRefsByValueKey(thing.ValueKey))
                    {
                        Console.WriteLine(stuff.Url);
                    }
                }
            }
        }

        //Here we actually make the changes that get committed to the catalog .db3
        public void makeTheChanges(CetCatalogContext context, List<DsProductType> products)
        {
            using var transaction = context.Database.BeginTransaction();
            foreach (var product in products)
            {
                // Console.WriteLine(product.Code);
                var extRefs = from extRef in context.PrdExternalRefTypes
                              where extRef.Url.StartsWith("3" + product.Code) && extRef.Url.EndsWith("4410.cmsym")
                              select extRef;

                foreach (var extRef in extRefs)
                {
                    // Console.WriteLine(extRef.Url);

                    var refe = new DsProductTypeExternalRef();
                    refe.OwnerKey = product.Id; //long?
                    refe.ValueKey = extRef.Id; //long?
                    refe.TypeKey = "PrdExternalRefType"; //string
                    context.DsProductTypeExternalRefs.Add(refe);
                    context.SaveChanges();
                }
            }
            transaction.Commit();
        }
    }
}
