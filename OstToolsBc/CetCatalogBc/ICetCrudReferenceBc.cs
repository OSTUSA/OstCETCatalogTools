using System.Collections.Generic;
using System.Threading.Tasks;
using OstToolsModels.CetCatalog;

namespace OstToolsBc.CetCatalogBc
{
    public interface ICetCrudReferenceBc<TModel> : ICetCrudCatalogBc<TModel>
    {
        #region Read

        /// <summary>
        /// Read Models by Owner Key. Owner key is a N:1
        /// </summary>
        /// <param name="ownerKey">Id of owner</param>
        /// <returns>Models with matching owner key</returns>
        Task<IEnumerable<TModel>> ReadByOwnerKeyAsync(int ownerKey);

        /// <summary>
        /// Read Models by owner key. Owner Key is a N:1
        /// </summary>
        /// <param name="ownerKey">Id of owner</param>
        /// <returns>Models with matching owner Key</returns>
        IEnumerable<TModel> ReadByOwnerKey(int ownerKey);

        /// <summary>
        /// Read models by owner keys asynchronously. Owner key is a N:1
        /// </summary>
        /// <param name="ownerKeys">Collection of owner keys</param>
        /// <returns>Models that have an owner key in the provided collection</returns>
        Task<IEnumerable<TModel>> ReadByOwnerKeysAsync(IEnumerable<int> ownerKeys);

        /// <summary>
        /// Read models by owner keys. Owner key is a N:1
        /// </summary>
        /// <param name="ownerKeys">Collection of owner keys</param>
        /// <returns>Models that have an owner key in the provided collection</returns>
        IEnumerable<TModel> ReadByOwnerKeys(IEnumerable<int> ownerKeys);

        #endregion

        #region Delete

        /// <summary>
        /// Delete Models by Owner Key. Owner key is a N:1
        /// </summary>
        /// <param name="ownerKey">Id of owner</param>
        /// <returns>Number of effected rows</returns>
        Task<int> DeleteByOwnerKeyAsync(int ownerKey);

        /// <summary>
        /// Delete Models by owner key. Owner Key is a N:1
        /// </summary>
        /// <param name="ownerKey">Id of owner</param>
        /// <returns>Number of effected rows</returns>
        int DeleteByOwnerKey(int ownerKey);

        /// <summary>
        /// Delete models by owner keys asynchronously. Owner key is a N:1
        /// </summary>
        /// <param name="ownerKeys">Collection of owner keys</param>
        /// <returns>Number of effected rows</returns>
        Task<int> DeleteByOwnerKeysAsync(IEnumerable<int> ownerKeys);

        /// <summary>
        /// Delete models by owner keys. Owner key is a N:1
        /// </summary>
        /// <param name="ownerKeys">Collection of owner keys</param>
        /// <returns>Number of effected rows</returns>
        int DeleteByOwnerKeys(IEnumerable<int> ownerKeys);

        #endregion
    }
}