using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OstCatalogToolsUnitTest.DataLayer.CetCatalogEf
{
    public class DataCatalogCustomOptionsRefUnitTest : CatalogBaseUnitTest
    {
        [Fact]
        public async Task Any_Void_IsTrue()
        {
            var any = await CetCatalogContext.DataCatalogCustomOptionsRefs.AnyAsync();
            Assert.True(any);
        }

        [Fact]
        public async Task ToListAsync_Void_NotEmpty()
        {
            var list = await CetCatalogContext.DataCatalogCustomOptionsRefs.ToListAsync();
            Assert.NotEmpty(list);
        }

        [Fact]
        public async Task IncludeChildrenAsync_void_NotNull()
        {
            var first = await CetCatalogContext.DataCatalogCustomOptionsRefs
                .Include(dcc => dcc.Child)
                .Include(dcc => dcc.Owner)
                .FirstOrDefaultAsync();

            Assert.NotNull(first);
            Assert.NotNull(first.Child);
            Assert.NotNull(first.Owner);
        }
    }
}
