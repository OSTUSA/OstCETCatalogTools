using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OstCatalogToolsUnitTest.DataLayer.CetCatalogEf
{
    public class DataCatalogscatalogsRef : CatalogBaseUnitTest
    {
        [Fact]
        public async Task ToListAsync_Void_NotEmpty()
        {
            var list = await CetCatalogContext.DataCatalogscatalogsRefs.ToListAsync();
            Assert.NotEmpty(list);
        }

        [Fact]
        public async Task IncludeChildrenAsync_Void_NotNull()
        {
            var first = await CetCatalogContext.DataCatalogscatalogsRefs
                .Include(dcr => dcr.Owner)
                .Include(dcr => dcr.Child)
                .FirstOrDefaultAsync();

            Assert.NotNull(first);
            Assert.NotNull(first.Owner);
            Assert.NotNull(first.Child);
        }
    }
}
