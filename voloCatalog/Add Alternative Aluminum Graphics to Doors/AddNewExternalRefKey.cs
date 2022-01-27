using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voloCatalog.Add_Alternative_Aluminum_Graphics_to_Doors
{
    internal class AddNewExternalRefKey
    {
        public void run() {
            var dataHelper = new Add_Alternative_Aluminum_Graphics_to_Doors.DataHelper();
            using var context = dataHelper.GetContext(); //Get te code Representation of the CET Catalog

            using var transaction = context.Database.BeginTransaction();

            var ref2 = new DsExternalRefKeyType();
            ref2.Id = 2;
            ref2.Type = "AlumDoor224"; //string
            ref2.Value = "224"; //string
            context.DsExternalRefKeyTypes.Add(ref2);
            context.SaveChanges();
           

            var ref3 = new DsExternalRefKeyType();
            ref3.Id = 3;
            ref3.Type = "AlumDoor444"; //string
            ref3.Value = "444"; //string
            context.DsExternalRefKeyTypes.Add(ref3);
            context.SaveChanges();
           

            var ref4 = new DsExternalRefKeyType();
            ref4.Id = 4;
            ref4.Type = "AlumDoor4410"; //string
            ref4.Value = "4410"; //string
            context.DsExternalRefKeyTypes.Add(ref4);
            context.SaveChanges();

            transaction.Commit();
        } 
    }
}
