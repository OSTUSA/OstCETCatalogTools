using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OstToolsDataLayer.CetCatalog;
using OstToolsModels.CetCatalog;

namespace OstToolsBc.CetCatalogBc
{
    public class CetProductExternalReferenceTypeBc : CetCrudCatalogBc<CetProductExternalReferenceTypeModel>
    {
        private readonly CetProductExternalReferenceTypeTable _externalTable;

        public CetProductExternalReferenceTypeBc(CetProductExternalReferenceTypeTable externalTable)
        {
            _externalTable = externalTable;
        }

        #region Create

        /// <inheritdoc />
        public override Task<int> CreateModelAsync(CetProductExternalReferenceTypeModel model) =>
            _externalTable.CreateModelAsync(model);

        /// <inheritdoc />
        public override Task<int> CreateModelAsync(IEnumerable<CetProductExternalReferenceTypeModel> models) =>
            _externalTable.CreateModelsAsync(models);

        #endregion Create

        #region Read

        /// <inheritdoc />
        public override Task<CetProductExternalReferenceTypeModel> ReadModelByIdAsync(int id) =>
            _externalTable.ReadByIdAsync(id);

        /// <inheritdoc />
        public override Task<IEnumerable<CetProductExternalReferenceTypeModel>> ReadAllAsync() =>
            _externalTable.ReadAllAsync();

        #endregion Read

        #region Update

        /// <inheritdoc />
        public override Task<int> UpdateModelAsync(CetProductExternalReferenceTypeModel model) =>
            _externalTable.Update(model);

        /// <inheritdoc />
        public override Task<int> UpdateModelAsync(IEnumerable<CetProductExternalReferenceTypeModel> models)
        {
            throw new NotImplementedException();
        }

        #endregion Update

        #region Delete

        /// <inheritdoc />
        public override Task<int> DeleteModelAsync(CetProductExternalReferenceTypeModel model) =>
            _externalTable.DeleteByIdAsync(model.Id);

        /// <inheritdoc />
        public override Task<int> DeleteModelAsync(int id) => _externalTable.DeleteByIdAsync(id);

        /// <inheritdoc />
        public override Task<int> DeleteModelsAsync(IEnumerable<CetProductExternalReferenceTypeModel> models) =>
            _externalTable.DeleteByIdsAsync(models.Select(model => model.Id));

        /// <inheritdoc />
        public override Task<int> DeleteModelsAsync(IEnumerable<int> ids) => _externalTable.DeleteByIdsAsync(ids);

        #endregion Delete
    }
}
