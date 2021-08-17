using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OstToolsDataLayer.CetCatalogEf;
using Xunit;

namespace OstCatalogToolsUnitTest.DataLayer.CetCatalogEf
{
    public class CetCatalogUnitTests
    {
        private readonly string _dbConnectionString = "Data Source=" + Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty, @"DataLayer/CetCatalogEf/TML.db3");

        [Fact]
        public void CanConnect_Void_IsTrue()
        {
            var cetCatalog = GetContext();

            Assert.True(cetCatalog.Database.CanConnect());
        }

        [Fact]
        public void ApplicationAreaTypeExists_Void_IsTrue()
        {
            var cetCatalog = GetContext();
            var exists = cetCatalog.ApplicationAreaTypes.Any();
            Assert.True(exists);
        }



        private CetCatalogContext GetContext()
        {
            return new CetCatalogContext(BuildContext());
        }

        private DbContextOptions<CetCatalogContext> BuildContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<CetCatalogContext>();
            optionsBuilder.UseSqlite(_dbConnectionString);
            return optionsBuilder.Options;
        }
    }
}
