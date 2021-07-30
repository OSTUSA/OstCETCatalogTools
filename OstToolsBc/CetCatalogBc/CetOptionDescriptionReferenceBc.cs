using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.CetCatalog;
using OstToolsDataLayer.CetCatalog;
using OstToolsModels.CetCatalog;

namespace OstToolsBc.CetCatalogBc
{
    public class CetOptionDescriptionReferenceBc : CetCrudCatalogReferenceBc<CetOptionDescriptionReferenceModel>
    {
        private readonly CetOptionDescriptionReferenceTable _descriptionTable;

        public CetOptionDescriptionReferenceBc(CetOptionDescriptionReferenceTable descriptionTable)
        {
            _descriptionTable = descriptionTable;
        }

        #region Create

        public override Task<int> CreateModelAsync(CetOptionDescriptionReferenceModel model)
        {
            throw new NotImplementedException();
        }

        public override Task<int> CreateModelAsync(IEnumerable<CetOptionDescriptionReferenceModel> models)
        {
            throw new NotImplementedException();
        }

        #endregion Create

        #region Read

        public override Task<CetOptionDescriptionReferenceModel> ReadModelByIdAsync(int id) =>
            _descriptionTable.ReadByIdAsync(id);

        public override Task<IEnumerable<CetOptionDescriptionReferenceModel>> ReadAllAsync() =>
            _descriptionTable.ReadAllAsync();

        public override Task<IEnumerable<CetOptionDescriptionReferenceModel>> ReadByOwnerKeyAsync(int ownerKey) =>
            _descriptionTable.ReadByOwnerKeyAsync(ownerKey);

        public override Task<IEnumerable<CetOptionDescriptionReferenceModel>>
            ReadByOwnerKeysAsync(IEnumerable<int> ownerKeys) => _descriptionTable.ReadByOwnerKeysAsync(ownerKeys);

        #endregion Read

        #region Update

        public override Task<int> UpdateModelAsync(CetOptionDescriptionReferenceModel model)
        {
            throw new NotImplementedException();
        }

        public override Task<int> UpdateModelAsync(IEnumerable<CetOptionDescriptionReferenceModel> models)
        {
            throw new NotImplementedException();
        }

        #endregion Update

        #region Delete

        public override Task<int> DeleteModelAsync(CetOptionDescriptionReferenceModel model) =>
            _descriptionTable.DeleteByIdAsync(model.Id);

        public override Task<int> DeleteModelAsync(int id) => _descriptionTable.DeleteByIdAsync(id);

        public override Task<int> DeleteModelsAsync(IEnumerable<CetOptionDescriptionReferenceModel> models) =>
            _descriptionTable.DeleteByIdsAsync(models.Select(model => model.Id));

        public override Task<int> DeleteModelsAsync(IEnumerable<int> ids) => _descriptionTable.DeleteByIdsAsync(ids);

        public override Task<int> DeleteByOwnerKeyAsync(int ownerKey) =>
            _descriptionTable.DeleteByOwnerKeyAsync(ownerKey);

        public override Task<int> DeleteByOwnerKeysAsync(IEnumerable<int> ownerKeys) =>
            _descriptionTable.DeleteByOwnerKeysAsync(ownerKeys);

        #endregion Delete
    }
}