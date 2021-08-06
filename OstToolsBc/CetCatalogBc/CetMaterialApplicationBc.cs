using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OstToolsDataLayer.CetCatalog;
using OstToolsModels.CetCatalog;

namespace OstToolsBc.CetCatalogBc
{
    public class CetMaterialApplicationBc : CetCrudCatalogBc<CetMaterialApplicationModel>
    {
        private readonly CetMaterialApplicationTable _table;

        public CetMaterialApplicationBc(CetMaterialApplicationTable table)
        {
            _table = table;
        }

        /// <inheritdoc />
        public override Task<int> CreateModelAsync(CetMaterialApplicationModel model)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<int> CreateModelAsync(IEnumerable<CetMaterialApplicationModel> models)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<CetMaterialApplicationModel> ReadModelByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<int> UpdateModelAsync(CetMaterialApplicationModel model)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<int> UpdateModelAsync(IEnumerable<CetMaterialApplicationModel> models)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<int> DeleteModelAsync(CetMaterialApplicationModel model)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<int> DeleteModelAsync(int id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<int> DeleteModelsAsync(IEnumerable<CetMaterialApplicationModel> models)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<int> DeleteModelsAsync(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<IEnumerable<CetMaterialApplicationModel>> ReadAllAsync() => _table.ReadAll();
    }
}
