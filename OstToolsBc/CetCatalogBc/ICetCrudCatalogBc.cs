using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstToolsBc.CetCatalogBc
{
    public interface ICetCrudCatalogBc<TModel>
    {
        /// <summary>
        /// Create Table if it does not already exist
        /// </summary>
        /// <returns>Table Creation Task</returns>
        Task CreateTableAsync();

        /// <summary>
        /// Create Table Indices for faster search
        /// </summary>
        /// <returns>Table Indices creation Task</returns>
        Task CreateIndices();

        #region Create

        /// <summary>
        /// Create Model Asynchronously.
        /// </summary>
        /// <param name="model">Model to create</param>
        /// <returns>Number of effected rows</returns>
        Task<int> CreateModelAsync(TModel model);

        /// <summary>
        /// Create Model.
        /// </summary>
        /// <param name="model">Model to create</param>
        /// <returns>Number of effected rows</returns>
        int CreateModel(TModel model);

        /// <summary>
        /// Create multiple models asynchronously.
        /// </summary>
        /// <param name="models">Models to create</param>
        /// <returns>Number of effected rows</returns>
        Task<int> CreateModelAsync(IEnumerable<TModel> models);

        /// <summary>
        /// Create multiple models asynchronously.
        /// </summary>
        /// <param name="models">Models to create</param>
        /// <returns>Number of effected rows</returns>
        int CreateModels(IEnumerable<TModel> models);

        #endregion Create

        #region Read

        /// <summary>
        /// Read model from data set asynchronously.
        /// </summary>
        /// <param name="id">Id of model</param>
        /// <returns>Found Model</returns>
        Task<TModel> ReadModelByIdAsync(int id);

        /// <summary>
        /// Read models by ID.
        /// </summary>
        /// <param name="id">ID of model to find</param>
        /// <returns>Found Model</returns>
        TModel ReadModelById(int id);

        #endregion

        #region Update

        /// <summary>
        /// Update model asynchronously.
        /// </summary>
        /// <param name="model">Updated Model</param>
        /// <returns>Number of effected rows</returns>
        Task<int> UpdateModelAsync(TModel model);

        /// <summary>
        /// Update Model
        /// </summary>
        /// <param name="model">Updated model</param>
        /// <returns></returns>
        int UpdateModel(TModel model);

        /// <summary>
        /// Update Model collection asynchronously
        /// </summary>
        /// <param name="models">Models to update</param>
        /// <returns>Number of effected rows</returns>
        Task<int> UpdateModelAsync(IEnumerable<TModel> models);

        /// <summary>
        /// Update model collection.
        /// </summary>
        /// <param name="models">Models to update</param>
        /// <returns>Number of effected rows</returns>
        int UpdateModels(IEnumerable<TModel> models);

        #endregion

        #region Delete

        /// <summary>
        /// Delete model asynchronously.
        /// </summary>
        /// <param name="model">Model to delete</param>
        /// <returns>Number of effected rows</returns>
        Task<int> DeleteModelAsync(TModel model);

        /// <summary>
        /// Delete Model
        /// </summary>
        /// <param name="model">Model to delete</param>
        /// <returns></returns>
        int DeleteModel(TModel model);

        /// <summary>
        /// Delete Model with matching ID asynchronously
        /// </summary>
        /// <param name="id">Id of model to delete</param>
        /// <returns>Number of effected rows</returns>
        Task<int> DeleteModelAsync(int id);

        /// <summary>
        /// Delete Model with matching ID
        /// </summary>
        /// <param name="id">Id of model to delete</param>
        /// <returns>Number of effected rows</returns>
        int DeleteModel(int id);

        /// <summary>
        /// Delete all provided models asynchronously.
        /// </summary>
        /// <param name="models">Models to delete</param>
        /// <returns>Number of effected rows</returns>
        Task<int> DeleteModelsAsync(IEnumerable<TModel> models);

        /// <summary>
        /// Delete all provided models.
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        int DeleteModels(IEnumerable<TModel> models);

        /// <summary>
        /// Delete models with matching ids asynchronously.
        /// </summary>
        /// <param name="ids">Ids of models to delete</param>
        /// <returns>Number of effected rows</returns>
        Task<int> DeleteModelsAsync(IEnumerable<int> ids);

        /// <summary>
        /// Delete models with matching ids.
        /// </summary>
        /// <param name="ids">Ids of models to delete</param>
        /// <returns>Number of effected rows.</returns>
        int DeleteModels(IEnumerable<int> ids);

        #endregion

        /// <inheritdoc />
        Task<IEnumerable<TModel>> ReadAllAsync();

        /// <inheritdoc />
        IEnumerable<TModel> ReadAll();
    }
}
