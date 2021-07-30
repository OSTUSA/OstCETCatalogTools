using System.Collections.Generic;
using System.Threading.Tasks;

namespace OstToolsBc.CetCatalogBc
{
    /// <summary>
    /// CRUD BC from CET catalog.
    /// </summary>
    /// <typeparam name="TModel">Table Model type</typeparam>
    public abstract class CetCrudCatalogBc<TModel> : ICetCrudCatalogBc<TModel>
    {
        /// <inheritdoc />
        public virtual Task CreateTableAsync()
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public virtual Task CreateIndices()
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public abstract Task<int> CreateModelAsync(TModel model);

        /// <inheritdoc />
        public virtual int CreateModel(TModel model) => CreateModelAsync(model).Result;

        /// <inheritdoc />
        public abstract Task<int> CreateModelAsync(IEnumerable<TModel> models);

        /// <inheritdoc />
        public virtual int CreateModels(IEnumerable<TModel> models) => CreateModelAsync(models).Result;

        /// <inheritdoc />
        public abstract Task<TModel> ReadModelByIdAsync(int id);

        /// <inheritdoc />
        public virtual TModel ReadModelById(int id) => ReadModelByIdAsync(id).Result;

        /// <inheritdoc />
        public abstract Task<IEnumerable<TModel>> ReadAllAsync();

        /// <inheritdoc />
        public virtual IEnumerable<TModel> ReadAll() => ReadAllAsync().Result;

        /// <inheritdoc />
        public abstract Task<int> UpdateModelAsync(TModel model);

        /// <inheritdoc />
        public virtual int UpdateModel(TModel model) => UpdateModelAsync(model).Result;

        /// <inheritdoc />
        public abstract Task<int> UpdateModelAsync(IEnumerable<TModel> models);

        /// <inheritdoc />
        public virtual int UpdateModels(IEnumerable<TModel> models) => UpdateModelAsync(models).Result;

        /// <inheritdoc />
        public abstract Task<int> DeleteModelAsync(TModel model);

        /// <inheritdoc />
        public virtual int DeleteModel(TModel model) => DeleteModelAsync(model).Result;

        /// <inheritdoc />
        public abstract Task<int> DeleteModelAsync(int id);

        /// <inheritdoc />
        public virtual int DeleteModel(int id) => DeleteModelAsync(id).Result;

        /// <inheritdoc />
        public abstract Task<int> DeleteModelsAsync(IEnumerable<TModel> models);

        /// <inheritdoc />
        public virtual int DeleteModels(IEnumerable<TModel> models) => DeleteModelsAsync(models).Result;

        /// <inheritdoc />
        public abstract Task<int> DeleteModelsAsync(IEnumerable<int> ids);

        /// <inheritdoc />
        public virtual int DeleteModels(IEnumerable<int> ids) => DeleteModelsAsync(ids).Result;
    }
}