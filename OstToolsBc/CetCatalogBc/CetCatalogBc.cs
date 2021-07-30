using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstToolsBc.CetCatalogBc
{
    public abstract class CetCatalogBc
    {
        protected readonly string DbConnectionString;

        protected CetCatalogBc(string dbConnectionString)
        {
            DbConnectionString = dbConnectionString;
        }
    }
}
