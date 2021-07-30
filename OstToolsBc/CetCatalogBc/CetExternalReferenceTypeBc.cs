using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OstToolsDataLayer.CetCatalog;
using OstToolsModels.CetCatalog;

namespace OstToolsBc.CetCatalogBc
{
    public class CetExternalReferenceTypeBc : CetCrudCatalogBc<CetExternalReferenceTypeModel>
    {
        private readonly CetExternalReferenceTypeTable _table;

        public CetExternalReferenceTypeBc(CetExternalReferenceTypeTable table)
        {
            _table = table;
        }

        /// <inheritdoc />
        public override Task<int> CreateModelAsync(CetExternalReferenceTypeModel model)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<int> CreateModelAsync(IEnumerable<CetExternalReferenceTypeModel> models)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<CetExternalReferenceTypeModel> ReadModelByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<int> UpdateModelAsync(CetExternalReferenceTypeModel model) => _table.Update(model);

        /// <inheritdoc />
        public override Task<int> UpdateModelAsync(IEnumerable<CetExternalReferenceTypeModel> models)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<int> DeleteModelAsync(CetExternalReferenceTypeModel model)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<int> DeleteModelAsync(int id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<int> DeleteModelsAsync(IEnumerable<CetExternalReferenceTypeModel> models)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<int> DeleteModelsAsync(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<IEnumerable<CetExternalReferenceTypeModel>> ReadAllAsync() => _table.ReadAll();
    }
}
