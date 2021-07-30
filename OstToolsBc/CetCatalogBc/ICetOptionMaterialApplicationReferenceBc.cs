using System.Collections.Generic;
using System.Threading.Tasks;
using OstToolsModels.CetCatalog;

namespace OstToolsBc.CetCatalogBc
{
    public interface ICetOptionMaterialApplicationReferenceBc
    {
        /// <summary>
        /// Create Material Application Reference
        /// </summary>
        /// <param name="model">Model to create</param>
        /// <returns>Number of effected rows</returns>
        Task<int> CreateModelAsync(CetOptionMaterialApplicationReferenceModel model);
    }
}