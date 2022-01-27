using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voloCatalog.Add_Alternative_Aluminum_Graphics_to_Doors
{
    internal class AddSwingExternalRefKeyToExternalRef
    {
        //Execute the contents of this file
        public void run()
        {
            var dataHelper = new Add_Alternative_Aluminum_Graphics_to_Doors.DataHelper();
            using var context = dataHelper.GetContext(); //Get te code Representation of the CET Catalog


            makeTheChanges(dataHelper, context);
            //viewDbEntries(dataHelper, context, extRefs.ToList());

        }

        //Here we actually make the changes that get committed to the catalog .db3
        public void makeTheChanges(DataHelper dataHelper, CetCatalogContext context)
        {
            using var transaction = context.Database.BeginTransaction();
            var extRefs = from extRef in context.PrdExternalRefTypes
                          where extRef.Url.EndsWith("4410.cmsym") || extRef.Url.EndsWith("L.cmsym") || extRef.Url.EndsWith("R.cmsym")
                          select extRef;

            foreach (var extRef in extRefs)
            {
                Console.WriteLine(extRef.Url);
                var valueId = 0;

                if (extRef.Url.EndsWith("4410.cmsym"))
                {
                    valueId = 4;
                }
                else if (extRef.Url.EndsWith("L.cmsym") || extRef.Url.EndsWith("R.cmsym"))
                {
                    valueId = 3;
                }

                var refe = new PrdExternalRefTypeExternalRefKeysRef();
                refe.OwnerKey = extRef.Id; //long?
                refe.ValueKey = valueId; //long?
                refe.TypeKey = "DsExternalRefKeyType"; //string
                context.PrdExternalRefTypeExternalRefKeysRefs.Add(refe);
                context.SaveChanges();

            }
            transaction.Commit();
        }

    }
}
