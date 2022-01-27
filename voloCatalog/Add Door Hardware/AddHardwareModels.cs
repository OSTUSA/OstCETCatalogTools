using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voloCatalog.Add_Door_Hardware
{
    internal class AddHardwareModels
    {

        //Execute the contents of this file
        public void run()
        {
            var dataHelper = new Add_Door_Hardware.DataHelper();
            using var context = dataHelper.GetContext(); //Get te code Representation of the CET Catalog


            string[] files = Directory.GetFiles(@"C:\Users\nanderle\Long Term Docs\Trendway\Volo\Juicer_Projects\Hardware\hardwareModels");

            using var transaction = context.Database.BeginTransaction();
            foreach (string file in files)
            {
                string cmsym = file.Split('\\').Last();
                Console.WriteLine(cmsym);

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
