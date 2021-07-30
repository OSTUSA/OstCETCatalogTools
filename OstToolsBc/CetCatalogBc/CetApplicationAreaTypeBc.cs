using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OstToolsDataLayer.CetCatalog;
using OstToolsModels.CetCatalog;

namespace OstToolsBc.CetCatalogBc
{
    public class CetApplicationAreaTypeBc : CetCrudCatalogBc<CetApplicationAreaTypeModel>
    {
        private readonly CetApplicationAreaTypeTable _table;

        public CetApplicationAreaTypeBc(CetApplicationAreaTypeTable table)
        {
            _table = table;
        }

        /// <inheritdoc />
        public override Task CreateTableAsync() => _table.CreateTable();

        /// <inheritdoc />
        public override async Task CreateIndices()
        {
            await _table.CreateApplicationAreaTypeCodeIndex();
            await _table.CreateApplicationAreaTypeSurfaceIdsReferenceOwnerKeyIndex();
            await _table.CreateApplicationAreaTypeSurfaceIdsReferenceValueKeyIndex();
        }

        /// <inheritdoc />
        public override Task<int> CreateModelAsync(CetApplicationAreaTypeModel model) => _table.CreateAsync(model);

        /// <inheritdoc />
        public override Task<int> CreateModelAsync(IEnumerable<CetApplicationAreaTypeModel> models) =>
            _table.CreateAsync(models);

        /// <inheritdoc />
        public override Task<CetApplicationAreaTypeModel> ReadModelByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<int> UpdateModelAsync(CetApplicationAreaTypeModel model)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<int> UpdateModelAsync(IEnumerable<CetApplicationAreaTypeModel> models)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<int> DeleteModelAsync(CetApplicationAreaTypeModel model)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<int> DeleteModelAsync(int id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<int> DeleteModelsAsync(IEnumerable<CetApplicationAreaTypeModel> models)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<int> DeleteModelsAsync(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<IEnumerable<CetApplicationAreaTypeModel>> ReadAllAsync() => _table.ReadAllAsync();
    }
}
