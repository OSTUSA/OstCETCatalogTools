using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OstToolsDataLayer.CetCatalog;
using OstToolsModels.CetCatalog;

namespace OstToolsBc.CetCatalogBc
{
    public class CetDsProductTypeExternalReferenceBc : CetCrudCatalogReferenceBc<CetDsProductTypeExternalReferenceModel>
    {
        private readonly CetDsProductTypeExternalReferenceTable _referenceTable;

        public CetDsProductTypeExternalReferenceBc(CetDsProductTypeExternalReferenceTable referenceTable)
        {
            _referenceTable = referenceTable;
        }

        #region Create

        /// <inheritdoc />
        public override Task<int> CreateModelAsync(CetDsProductTypeExternalReferenceModel model) =>
            _referenceTable.CreateModelAsync(model);

        /// <inheritdoc />
        public override Task<int> CreateModelAsync(IEnumerable<CetDsProductTypeExternalReferenceModel> models) =>
            _referenceTable.CreateModelsAsync(models);

        #endregion Create

        #region Read

        /// <inheritdoc />
        public override Task<CetDsProductTypeExternalReferenceModel> ReadModelByIdAsync(int id) =>
            _referenceTable.ReadByIdAsync(id);

        /// <inheritdoc />
        public override Task<IEnumerable<CetDsProductTypeExternalReferenceModel>> ReadAllAsync() => _referenceTable.ReadAllAsync();

        /// <inheritdoc />
        public override Task<IEnumerable<CetDsProductTypeExternalReferenceModel>> ReadByOwnerKeyAsync(int ownerKey) =>
            _referenceTable.ReadByOwnerKeyAsync(ownerKey);

        /// <inheritdoc />
        public override Task<IEnumerable<CetDsProductTypeExternalReferenceModel>>
            ReadByOwnerKeysAsync(IEnumerable<int> ownerKeys) => _referenceTable.ReadByOwnerKeysAsync(ownerKeys);

        #endregion Read

        #region Update

        /// <inheritdoc />
        public override Task<int> UpdateModelAsync(CetDsProductTypeExternalReferenceModel model) => throw new NotImplementedException();

        /// <inheritdoc />
        public override Task<int> UpdateModelAsync(IEnumerable<CetDsProductTypeExternalReferenceModel> models)
        {
            throw new NotImplementedException();
        }

        #endregion Update

        #region Delete

        /// <inheritdoc />
        public override Task<int> DeleteModelAsync(CetDsProductTypeExternalReferenceModel model) =>
            _referenceTable.DeleteByIdAsync(model.Id);

        /// <inheritdoc />
        public override Task<int> DeleteModelAsync(int id) => _referenceTable.DeleteByIdAsync(id);

        /// <inheritdoc />
        public override Task<int> DeleteModelsAsync(IEnumerable<CetDsProductTypeExternalReferenceModel> models) =>
            _referenceTable.DeleteByIdsAsync(models.Select(model => model.Id));

        /// <inheritdoc />
        public override Task<int> DeleteModelsAsync(IEnumerable<int> ids) => _referenceTable.DeleteByIdsAsync(ids);

        /// <inheritdoc />
        public override Task<int> DeleteByOwnerKeyAsync(int ownerKey) =>
            _referenceTable.DeleteByOwnerKeyAsync(ownerKey);

        /// <inheritdoc />
        public override Task<int> DeleteByOwnerKeysAsync(IEnumerable<int> ownerKeys) =>
            _referenceTable.DeleteByOwnerKeysAsync(ownerKeys);

        #endregion Delete
    }
}
