using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OstCatalogToolsUnitTest.DataLayer.CetCatalogEf
{
    public class DsClassifactionTypeClassificationRefUnitTests : CatalogBaseUnitTest
    {
        [Fact]
        public async Task ToListAsync_Void_NotEmpty()
        {
            var list = await CetCatalogContext.DsClassificationTypeClassificationsRefs.ToListAsync();
            Assert.NotEmpty(list);
        }

        [Fact]
        public async Task IncludeChildrenAsync_Void_NotNull()
        {
            var first = await CetCatalogContext.DsClassificationTypeClassificationsRefs
                .Include(d => d.Owner)
                .Include(d => d.Child)
                .FirstOrDefaultAsync();
            Assert.NotNull(first);
            Assert.NotNull(first.Owner);
            Assert.NotNull(first.Child);
        }
    }
}
