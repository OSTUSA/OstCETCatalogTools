using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OstToolsDataLayer.CetCatalog;
using OstToolsModels.CetCatalog;

namespace OstToolsBc.CetCatalogBc
{
    public class CetDsProductTypeBc : CetCrudCatalogBc<CetDsProductTypeModel>
    {
        private readonly CetDsProductTypeTable _productTable;

        public CetDsProductTypeBc(CetDsProductTypeTable productTable)
        {
            _productTable = productTable;
        }

        #region Create

        public override Task<int> CreateModelAsync(CetDsProductTypeModel model)
        {
            throw new NotImplementedException();
        }

        public override Task<int> CreateModelAsync(IEnumerable<CetDsProductTypeModel> models)
        {
            throw new NotImplementedException();
        }

        #endregion Create

        #region Read

        public override Task<CetDsProductTypeModel> ReadModelByIdAsync(int id) => _productTable.FindByIdAsync(id);

        public override Task<IEnumerable<CetDsProductTypeModel>> ReadAllAsync() => _productTable.GetAllAsync();

        #endregion Read

        #region Update

        public override Task<int> UpdateModelAsync(CetDsProductTypeModel model)
        {
            throw new NotImplementedException();
        }

        public override Task<int> UpdateModelAsync(IEnumerable<CetDsProductTypeModel> models)
        {
            throw new NotImplementedException();
        }

        #endregion Update

        #region Delete

        public override Task<int> DeleteModelAsync(CetDsProductTypeModel model)
        {
            throw new NotImplementedException();
        }

        public override Task<int> DeleteModelAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<int> DeleteModelsAsync(IEnumerable<CetDsProductTypeModel> models)
        {
            throw new NotImplementedException();
        }

        public override Task<int> DeleteModelsAsync(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        #endregion Delete


    }
}
