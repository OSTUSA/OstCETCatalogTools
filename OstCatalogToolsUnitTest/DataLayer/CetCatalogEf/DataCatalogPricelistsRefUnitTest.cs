using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OstCatalogToolsUnitTest.DataLayer.CetCatalogEf
{
    public class DataCatalogPricelistsRefUnitTest : CatalogBaseUnitTest
    {
        [Fact]
        public async Task AnyAsync_Void_True()
        {
            var any = await CetCatalogContext.DataCatalogPricelistsRefs.AnyAsync();
            Assert.True(any);
        }

        [Fact]
        public async Task ToListAsync_Void_NotEmpty()
        {
            var list = await CetCatalogContext.DataCatalogPricelistsRefs.ToListAsync();
            Assert.NotEmpty(list);
        }

        [Fact]
        public async Task IncludeChildrenAsync_Void_NotNull()
        {
            var first = await CetCatalogContext.DataCatalogPricelistsRefs
                .Include(dcp => dcp.Owner)
                .Include(dcp => dcp.Child)
                .FirstOrDefaultAsync();

            Assert.NotNull(first);
            Assert.NotNull(first.Owner);
            Assert.NotNull(first.Child);
        }
    }
}
