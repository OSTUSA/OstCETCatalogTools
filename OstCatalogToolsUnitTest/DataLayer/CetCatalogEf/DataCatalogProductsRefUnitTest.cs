using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OstCatalogToolsUnitTest.DataLayer.CetCatalogEf
{
    public class DataCatalogProductsRefUnitTest : CatalogBaseUnitTest
    {
        [Fact]
        public async Task AnyAsync_Void_True()
        {
            var any = await CetCatalogContext.DataCatalogProductsRefs.AnyAsync();
            Assert.True(any);
        }

        [Fact]
        public async Task ToListAsync_Void_NotEmpty()
        {
            var list = await CetCatalogContext.DataCatalogProductsRefs.ToListAsync();
            Assert.NotEmpty(list);
        }

        [Fact]
        public async Task IncludeChildrenAsync_Void_NotNull()
        {
            var first = await CetCatalogContext.DataCatalogProductsRefs
                .Include(dcp => dcp.Owner)
                .Include(dcp => dcp.Child)
                .FirstOrDefaultAsync();

            Assert.NotNull(first);
            Assert.NotNull(first.Owner);
            Assert.NotNull(first.Child);
        }
    }
}
