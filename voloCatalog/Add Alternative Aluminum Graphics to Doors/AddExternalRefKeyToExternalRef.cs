using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voloCatalog.Add_Alternative_Aluminum_Graphics_to_Doors
{
    internal class AddExternalRefKeyToExternalRef
    {
        //Execute the contents of this file
        public void run()
        {
            var dataHelper = new Add_Alternative_Aluminum_Graphics_to_Doors.DataHelper();
            using var context = dataHelper.GetContext(); //Get te code Representation of the CET Catalog

            var extRefs = from extRef in context.PrdExternalRefTypes
                          where extRef.Url.EndsWith("224.cmsym") || extRef.Url.EndsWith("444.cmsym")
                          select extRef;

            makeTheChanges(dataHelper, context);
            //viewDbEntries(dataHelper, context, extRefs.ToList());

        }

        //Here we actually make the changes that get committed to the catalog .db3
        public void makeTheChanges(DataHelper dataHelper, CetCatalogContext context)
        {
            using var transaction = context.Database.BeginTransaction();
            var extRefs = from extRef in context.PrdExternalRefTypes
                          where extRef.Url.EndsWith("224.cmsym") || extRef.Url.EndsWith("444.cmsym") || extRef.Url.EndsWith("222.cmsym")
                          select extRef;

            foreach (var extRef in extRefs)
            {
                Console.WriteLine(extRef.Url);
                var valueId = 0;

                if (extRef.Url.EndsWith("222.cmsym"))
                {
                    valueId = 1;
                } else if (extRef.Url.EndsWith("224.cmsym"))
                {
                    valueId = 2;
                } else if (extRef.Url.EndsWith("444.cmsym"))
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


            //Print a bunch of the relevant output stuff
            public void viewDbEntries(DataHelper dataHelper, CetCatalogContext context, List<PrdExternalRefType> extRefs)
        {
            foreach (var extRef in extRefs)
            {
                 Console.WriteLine(extRef.Url);



                var extRefKeys = from extRefKey in context.PrdExternalRefTypeExternalRefKeysRefs
                                 where extRefKey.OwnerKey == extRef.Id
                                 select extRefKey;


                foreach (var extRefKey in extRefKeys)
                {
                   
                    Console.WriteLine(extRefKey);
                }
            }

            //var extRefKeys = from extRefKey in context.DsExternalRefKeyTypes    
            //                 select extRefKey;

            //foreach (var extRefKey in extRefKeys)
            //{
            //    Console.WriteLine(extRefKey.Type);
            //}
        }
    }
}
