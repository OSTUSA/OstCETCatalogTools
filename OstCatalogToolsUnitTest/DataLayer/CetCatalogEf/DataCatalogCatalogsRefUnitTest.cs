using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OstCatalogToolsUnitTest.DataLayer.CetCatalogEf
{
    public class DataCatalogCatalogsRefUnitTest : CatalogBaseUnitTest
    {
        [Fact]
        public async Task Any_Void_IsTrue()
        {
            var any = await CetCatalogContext.DataCatalogCatalogsRefs.AnyAsync();
            Assert.True(any);
        }

        [Fact]
        public async Task ToListAsync_Void_NotEmpty()
        {
            var catalogsRef = await CetCatalogContext.DataCatalogCatalogsRefs.ToListAsync();
            Assert.NotEmpty(catalogsRef);
        }

        [Fact]
        public async Task IncludeChildrenAsync_Void_NotNull()
        {
            var catalogsRef = await CetCatalogContext.DataCatalogCatalogsRefs.Include(dccr => dccr.Child).Include(dccr => dccr.Owner).ToListAsync();
            Assert.NotNull(catalogsRef[0].Owner);
            Assert.NotNull(catalogsRef[0].Child);
        }
    }
}
