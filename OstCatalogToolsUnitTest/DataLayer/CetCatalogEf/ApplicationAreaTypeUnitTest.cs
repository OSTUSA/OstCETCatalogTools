using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OstToolsDataLayer.CetCatalogEf;
using Xunit;

namespace OstCatalogToolsUnitTest.DataLayer.CetCatalogEf
{
    public class ApplicationAreaTypeUnitTest : CatalogBaseUnitTest
    {
        /// <summary>
        /// Application Area Type Exists
        /// </summary>
        [Fact]
        public async Task ApplicationAreaTypeExists_Void_IsTrue()
        {
            var cetCatalog = GetContext();
            var exists = await cetCatalog.ApplicationAreaTypes.AnyAsync();
            Assert.True(exists);
        }

        [Fact]
        public async Task NotEmpty_Void_NotEmpty()
        {
            var applications = await CetCatalogContext.ApplicationAreaTypes.ToListAsync();
            Assert.NotEmpty(applications);
        }
    }
}
