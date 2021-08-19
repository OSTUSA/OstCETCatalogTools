using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OstCatalogToolsUnitTest.DataLayer.CetCatalogEf
{
    public class DataCatalogUnitTest : CatalogBaseUnitTest
    {
        /// <summary>
        /// Data catalog is not empty
        /// </summary>
        [Fact]
        public async Task DataCatalogAny_Void_NotEmpty()
        {
            var catalogs = await CetCatalogContext.DataCatalog.ToListAsync();
            Assert.NotEmpty(catalogs);
        }

        [Fact]
        public async Task DataCatalog_IncludeApplicationAreas_NotEmpty()
        {
            var dataCatalog = await CetCatalogContext.DataCatalog.Include(dc => dc.ApplicationAreasRefs).ThenInclude(aRef => aRef.Child).ToListAsync();
            Assert.NotEmpty(dataCatalog);
        }

        [Fact]
        public async Task LoadImmediateChildren_void_NotEmpty()
        {
            // I've disabled the product refs because there are so many in this
            // test catalog. 
            // TODO: Re-enable it when changing the catalog out for a smaller one.
            var dataCatalog = await CetCatalogContext.DataCatalog
                .Include(dc => dc.ApplicationAreasRefs)
                .Include(dc => dc.CatalogsRefs)
                .Include(dc => dc.ClassificationsRefs)
                .Include(dc => dc.CustomOptionsRefs)
                .Include(dc => dc.FeaturesRefs)
                // .Include(dc => dc.ProductsRefs)
                .FirstOrDefaultAsync();

            Assert.NotEmpty(dataCatalog.ApplicationAreasRefs);
            Assert.NotEmpty(dataCatalog.CatalogsRefs);
            Assert.NotEmpty(dataCatalog.ClassificationsRefs);
            Assert.NotEmpty(dataCatalog.CustomOptionsRefs);
            Assert.NotEmpty(dataCatalog.FeaturesRefs);
            // Assert.NotEmpty(dataCatalog.ProductsRefs);
        }
    }
}
