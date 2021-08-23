using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OstCatalogToolsUnitTest.DataLayer.CetCatalogEf
{
    public class PriceTypeSeqPriceTypesRefUnitTest : CatalogBaseUnitTest
    {
        [Fact]
        public async Task ToListAsync_Void_NotEmpty()
        {
            var list = await CetCatalogContext.PriceTypeSeqPriceTypesRefs.ToListAsync();
            Assert.NotEmpty(list);
        }

        [Fact]
        public async Task IncludeChildrenAsync_Void_NotNull()
        {
            var fisrt = await CetCatalogContext.PriceTypeSeqPriceTypesRefs
                .Include(r => r.Owner)
                .Include(r => r.Child)
                .FirstOrDefaultAsync();

            Assert.NotNull(fisrt);
            Assert.NotNull(fisrt.Owner);
            Assert.NotNull(fisrt.Child);
        }
    }
}
