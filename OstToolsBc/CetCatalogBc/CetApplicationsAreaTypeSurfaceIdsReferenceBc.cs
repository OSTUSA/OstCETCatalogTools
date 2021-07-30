using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OstToolsDataLayer.CetCatalog;
using OstToolsModels.CetCatalog;

namespace OstToolsBc.CetCatalogBc
{
    public class CetApplicationsAreaTypeSurfaceIdsReferenceBc : CetCrudCatalogReferenceBc<CetApplicationAreaTypeSurfaceIdsReferenceModel>
    {
        private readonly CetApplicationAreaTypeSurfaceIdsReferenceTable _table;

        public CetApplicationsAreaTypeSurfaceIdsReferenceBc(CetApplicationAreaTypeSurfaceIdsReferenceTable table)
        {
            _table = table;
        }

        /// <inheritdoc />
        public override Task CreateTableAsync() => _table.CreateTable();

        /// <inheritdoc />
        public override Task<int> CreateModelAsync(CetApplicationAreaTypeSurfaceIdsReferenceModel model) =>
            _table.CreateAsync(model);

        /// <inheritdoc />
        public override Task<int>
            CreateModelAsync(IEnumerable<CetApplicationAreaTypeSurfaceIdsReferenceModel> models) =>
            _table.CreateAsync(models);

        /// <inheritdoc />
        public override Task<CetApplicationAreaTypeSurfaceIdsReferenceModel> ReadModelByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<int> UpdateModelAsync(CetApplicationAreaTypeSurfaceIdsReferenceModel model)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<int> UpdateModelAsync(IEnumerable<CetApplicationAreaTypeSurfaceIdsReferenceModel> models)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<int> DeleteModelAsync(CetApplicationAreaTypeSurfaceIdsReferenceModel model)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<int> DeleteModelAsync(int id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<int> DeleteModelsAsync(IEnumerable<CetApplicationAreaTypeSurfaceIdsReferenceModel> models)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<int> DeleteModelsAsync(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<IEnumerable<CetApplicationAreaTypeSurfaceIdsReferenceModel>> ReadAllAsync() =>
            _table.ReadAllAsync();

        /// <inheritdoc />
        public override Task<IEnumerable<CetApplicationAreaTypeSurfaceIdsReferenceModel>> ReadByOwnerKeyAsync(int ownerKey)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<IEnumerable<CetApplicationAreaTypeSurfaceIdsReferenceModel>> ReadByOwnerKeysAsync(IEnumerable<int> ownerKeys)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<int> DeleteByOwnerKeyAsync(int ownerKey)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<int> DeleteByOwnerKeysAsync(IEnumerable<int> ownerKeys)
        {
            throw new NotImplementedException();
        }
    }
}
