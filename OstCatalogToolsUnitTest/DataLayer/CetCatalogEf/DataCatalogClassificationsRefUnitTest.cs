using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OstCatalogToolsUnitTest.DataLayer.CetCatalogEf
{
    public class DataCatalogClassificationsRefUnitTest : CatalogBaseUnitTest
    {
        [Fact]
        public async Task AnyAsync_void_IsTrue()
        {
            var any = await CetCatalogContext.DataCatalogClassificationsRefs.AnyAsync();
            Assert.True(any);
        }

        [Fact]
        public async Task ToListAsync_void_NotEmpty()
        {
            var list = await CetCatalogContext.DataCatalogClassificationsRefs.ToListAsync();
            Assert.NotEmpty(list);
        }

        [Fact]
        public async Task IncludeChildren_void_NotNull()
        {
            var first = await CetCatalogContext.DataCatalogClassificationsRefs
                .Include(dcr => dcr.Owner)
                .Include(dcr => dcr.Child)
                .FirstOrDefaultAsync();

            Assert.NotNull(first);
            Assert.NotNull(first.Owner);
            Assert.NotNull(first.Child);
        }
    }
}
