using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OstCatalogToolsUnitTest.DataLayer.CetCatalogEf
{
    public class ApplicationAreaTypeSurfaceIdsRefUnitTest : CatalogBaseUnitTest
    {
        /// <summary>
        /// Checks to see if application area type includes its applicationSurefaceReferenceTypeIdsRefs
        /// </summary>
        [Fact]
        public async Task ApplicationAreaTypeGetReferences_Void_IsTrue()
        {
            var apps = await CetCatalogContext.ApplicationAreaTypes.Include(a => a.ApplicationSurfaceReference).ToListAsync();
            Assert.NotEmpty(apps[0].ApplicationSurfaceReference);
        }
    }
}
