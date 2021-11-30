using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OstCatalogToolsUnitTest.DataLayer.CetCatalogEf
{
    public class ProductExternalRefTypeExternalRefKeysRefUnitTest : CatalogBaseUnitTest
    {
        [Fact]
        public async Task ToListAsync_void_NotEmpty()
        {
            var list = await CetCatalogContext.PrdExternalRefTypeExternalRefKeysRefs.ToListAsync();
            Assert.NotNull(list);
        }

        [Fact]
        public async Task IncludeChildrenAsync_Void_NotNull()
        {
            var first = await CetCatalogContext.PrdExternalRefTypeExternalRefKeysRefs
                .Include(p => p.Child)
                .Include(p => p.Owner)
                .FirstOrDefaultAsync();

            Assert.NotNull(first);
            Assert.NotNull(first.Child);
            Assert.NotNull(first.Owner);
        }
    }
}
