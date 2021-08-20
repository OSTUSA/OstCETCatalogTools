using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OstCatalogToolsUnitTest.DataLayer.CetCatalogEf
{
    public class DsProductTypeExternalRefUnitTest : CatalogBaseUnitTest
    {
        [Fact]
        public async Task ToListAsync_void_NotEmpty()
        {
            var list = await CetCatalogContext.DsProductTypeExternalRefs.ToListAsync();
            Assert.NotEmpty(list);
        }

        [Fact]
        public async Task IncludeChildrenAsync_Void_NotNull()
        {
            var first = await CetCatalogContext.DsProductTypeExternalRefs
                .Include(r => r.Owner)
                .Include(r => r.Child)
                .FirstOrDefaultAsync();

            Assert.NotNull(first);
            Assert.NotNull(first.Owner);
            Assert.NotNull(first.Child);
        }
    }
}
