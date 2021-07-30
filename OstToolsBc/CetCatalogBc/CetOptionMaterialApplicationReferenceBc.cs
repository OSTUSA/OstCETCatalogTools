using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.CetCatalog;
using OstToolsModels.CetCatalog;

namespace OstToolsBc.CetCatalogBc
{
    public class CetOptionMaterialApplicationReferenceBc : CetCrudCatalogReferenceBc<CetOptionMaterialApplicationReferenceModel>
    {
        /// <summary>
        /// Catalog Option Material Application Reference Table
        /// </summary>
        private readonly CetOptionMaterialApplicationReferenceTable _materialApplicationReferenceTable;

        public CetOptionMaterialApplicationReferenceBc(CetOptionMaterialApplicationReferenceTable materialApplicationReferenceTable)
        {
            _materialApplicationReferenceTable = materialApplicationReferenceTable;
        }


        #region Create

        /// <inheritdoc />
        public override Task<int> CreateModelAsync(CetOptionMaterialApplicationReferenceModel model)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<int> CreateModelAsync(IEnumerable<CetOptionMaterialApplicationReferenceModel> models)
        {
            throw new NotImplementedException();
        }

        #endregion Create

        #region Read

        /// <inheritdoc />
        public override Task<CetOptionMaterialApplicationReferenceModel> ReadModelByIdAsync(int id) =>
            _materialApplicationReferenceTable.FindByIdAsync(id);

        /// <inheritdoc />
        public override Task<IEnumerable<CetOptionMaterialApplicationReferenceModel>> ReadAllAsync() =>
            _materialApplicationReferenceTable.GetAllAsync();

        /// <inheritdoc />
        public override Task<IEnumerable<CetOptionMaterialApplicationReferenceModel>>
            ReadByOwnerKeyAsync(int ownerKey) => _materialApplicationReferenceTable.FindByOwnerKeyAsync(ownerKey);

        /// <inheritdoc />
        public override Task<IEnumerable<CetOptionMaterialApplicationReferenceModel>>
            ReadByOwnerKeysAsync(IEnumerable<int> ownerKeys) =>
            _materialApplicationReferenceTable.FindByOwnerKeysAsync(ownerKeys);

        #endregion

        #region Update

        /// <inheritdoc />
        public override Task<int> UpdateModelAsync(CetOptionMaterialApplicationReferenceModel model)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<int> UpdateModelAsync(IEnumerable<CetOptionMaterialApplicationReferenceModel> models)
        {
            throw new NotImplementedException();
        }

        #endregion Update

        #region Delete

        /// <inheritdoc />
        public override Task<int> DeleteModelAsync(CetOptionMaterialApplicationReferenceModel model) =>
            _materialApplicationReferenceTable.DeleteByIdAsync(model.Id);

        /// <inheritdoc />
        public override Task<int> DeleteModelAsync(int id) => _materialApplicationReferenceTable.DeleteByIdAsync(id);

        /// <inheritdoc />
        public override Task<int> DeleteModelsAsync(IEnumerable<CetOptionMaterialApplicationReferenceModel> models) =>
            _materialApplicationReferenceTable.DeleteByIdsAsync(models.Select(model => model.Id));

        /// <inheritdoc />
        public override Task<int> DeleteModelsAsync(IEnumerable<int> ids) =>
            _materialApplicationReferenceTable.DeleteByIdsAsync(ids);

        /// <inheritdoc />
        public override Task<int> DeleteByOwnerKeyAsync(int ownerKey) =>
            _materialApplicationReferenceTable.DeleteByOwnerKeyAsync(ownerKey);

        /// <inheritdoc />
        public override Task<int> DeleteByOwnerKeysAsync(IEnumerable<int> ownerKeys) =>
            _materialApplicationReferenceTable.DeleteByOwnerKeysAsync(ownerKeys);

        #endregion Delete
    }
}
