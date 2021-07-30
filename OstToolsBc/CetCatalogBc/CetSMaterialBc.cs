using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OstToolsDataLayer.CetCatalog;
using OstToolsModels.CetCatalog;

namespace OstToolsBc.CetCatalogBc
{
    public class CetSMaterialBc : CetCrudCatalogBc<CetSMaterialModel>
    {
        private readonly CetSMaterialTable _table;

        public CetSMaterialBc(CetSMaterialTable table)
        {
            _table = table;
        }

        /// <inheritdoc />
        public override Task<int> CreateModelAsync(CetSMaterialModel model)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<int> CreateModelAsync(IEnumerable<CetSMaterialModel> models)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<CetSMaterialModel> ReadModelByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<int> UpdateModelAsync(CetSMaterialModel model)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<int> UpdateModelAsync(IEnumerable<CetSMaterialModel> models)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<int> DeleteModelAsync(CetSMaterialModel model)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<int> DeleteModelAsync(int id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<int> DeleteModelsAsync(IEnumerable<CetSMaterialModel> models)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<int> DeleteModelsAsync(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<IEnumerable<CetSMaterialModel>> ReadAllAsync() => _table.ReadAllAsync();
    }
}
