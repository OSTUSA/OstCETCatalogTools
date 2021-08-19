using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OstCatalogToolsUnitTest.DataLayer.CetCatalogEf
{
    public class DataCatalogFeaturesRefUnitTest : CatalogBaseUnitTest
    {
        [Fact]
        public async Task AnyAsync_Void_IsTrue()
        {
            var any = await CetCatalogContext.DataCatalogFeaturesRefs.AnyAsync();
            Assert.True(any);
        }

        [Fact]
        public async Task ToListAsync_void_NotEmpty()
        {
            var list = await CetCatalogContext.DataCatalogFeaturesRefs.ToListAsync();
            Assert.NotEmpty(list);
        }

        [Fact]
        public async Task IncludeAllChildren_void_NotNull()
        {
            var first = await CetCatalogContext.DataCatalogFeaturesRefs
                .Include(dcf => dcf.Owner)
                .Include(dcf => dcf.Child)
                .FirstOrDefaultAsync();

            Assert.NotNull(first);
            Assert.NotNull(first.Owner);
            Assert.NotNull(first.Child);
        }
    }
}
