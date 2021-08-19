using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Xunit;

namespace OstCatalogToolsUnitTest.DataLayer.CetCatalogEf
{
    public class DataCatalogApplicationAreasRefUnitTest : CatalogBaseUnitTest
    {
        [Fact]
        public async Task ToListAsync_Void_NotEmpty()
        {
            var catAppAreaRefs = await CetCatalogContext.DataCatalogApplicationAreasRefs.ToListAsync();
            Assert.NotEmpty(catAppAreaRefs);
        }
    }
}
