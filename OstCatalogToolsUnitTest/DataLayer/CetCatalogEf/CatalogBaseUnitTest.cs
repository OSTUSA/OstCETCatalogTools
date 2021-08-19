using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OstToolsDataLayer.CetCatalogEf;
using Xunit;

namespace OstCatalogToolsUnitTest.DataLayer.CetCatalogEf
{
    public abstract class CatalogBaseUnitTest
    {
        private CetCatalogContext _cetCatalogContext;

        protected CetCatalogContext CetCatalogContext 
        { 
            get 
            { 
                 _cetCatalogContext ??= new CetCatalogContext(BuildContext()); 
                return _cetCatalogContext; 
            } 
        }

        private readonly string _dbConnectionString = "Data Source=" + Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty, @"DataLayer/CetCatalogEf/TML.db3");

        /// <summary>
        /// Get DB Context
        /// </summary>
        /// <returns></returns>
        protected CetCatalogContext GetContext()
        {
            return new CetCatalogContext(BuildContext());
        }

        /// <summary>
        /// Build DB Context Options
        /// </summary>
        /// <returns>Builds DB Context Options with contained DB.</returns>
        private DbContextOptions<CetCatalogContext> BuildContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<CetCatalogContext>();
            optionsBuilder.UseSqlite(_dbConnectionString);
            return optionsBuilder.Options;
        }
    }
}
