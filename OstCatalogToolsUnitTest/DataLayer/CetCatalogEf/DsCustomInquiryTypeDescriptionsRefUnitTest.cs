using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OstCatalogToolsUnitTest.DataLayer.CetCatalogEf
{
    public class DsCustomInquiryTypeDescriptionsRefUnitTest : CatalogBaseUnitTest
    {
        [Fact]
        public async Task ToListAsync_Void_NotEmpty()
        {
            var list = await CetCatalogContext.DsCustomInquiryTypeDescriptionsRefs.ToListAsync();
            Assert.NotEmpty(list);
        }

        [Fact]
        public async Task IncludeChildren_Void_NotNull()
        {
            var first = await CetCatalogContext.DsCustomInquiryTypeDescriptionsRefs
                .Include(f => f.Owner)
                .FirstOrDefaultAsync();
            Assert.NotNull(first);
            Assert.NotNull(first.Owner);
        }
    }
}
