using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OstToolsDataLayer.CetCatalog;
using OstToolsModels.CetCatalog;

namespace OstToolsBc.CetCatalogBc
{
    public class CetSMaterialExternalReferenceBc : CetCrudCatalogReferenceBc<CetSMaterialExternalReferenceModel>
    {
        private readonly CetSMaterialExternalReferenceTable _table;

        public CetSMaterialExternalReferenceBc(CetSMaterialExternalReferenceTable table)
        {
            _table = table;
        }

        /// <inheritdoc />
        public override Task<int> CreateModelAsync(CetSMaterialExternalReferenceModel model)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<int> CreateModelAsync(IEnumerable<CetSMaterialExternalReferenceModel> models)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<CetSMaterialExternalReferenceModel> ReadModelByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<int> UpdateModelAsync(CetSMaterialExternalReferenceModel model)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<int> UpdateModelAsync(IEnumerable<CetSMaterialExternalReferenceModel> models)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<int> DeleteModelAsync(CetSMaterialExternalReferenceModel model)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<int> DeleteModelAsync(int id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<int> DeleteModelsAsync(IEnumerable<CetSMaterialExternalReferenceModel> models)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<int> DeleteModelsAsync(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<IEnumerable<CetSMaterialExternalReferenceModel>> ReadAllAsync() => _table.ReadAll();

        /// <inheritdoc />
        public override Task<IEnumerable<CetSMaterialExternalReferenceModel>> ReadByOwnerKeyAsync(int ownerKey)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<IEnumerable<CetSMaterialExternalReferenceModel>> ReadByOwnerKeysAsync(IEnumerable<int> ownerKeys)
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
