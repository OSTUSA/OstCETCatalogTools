using System.Collections.Generic;
using System.Threading.Tasks;

namespace OstToolsBc.CetCatalogBc
{
    /// <summary>
    /// CET CRUD Catalog Reference BC base.
    /// </summary>
    /// <typeparam name="TModel">Catalog Model reference type</typeparam>
    public abstract class CetCrudCatalogReferenceBc<TModel> : CetCrudCatalogBc<TModel>, ICetCrudReferenceBc<TModel>
    {
        /// <inheritdoc />
        public abstract Task<IEnumerable<TModel>> ReadByOwnerKeyAsync(int ownerKey);

        /// <inheritdoc />
        public virtual IEnumerable<TModel> ReadByOwnerKey(int ownerKey) => ReadByOwnerKeyAsync(ownerKey).Result;

        /// <inheritdoc />
        public abstract Task<IEnumerable<TModel>> ReadByOwnerKeysAsync(IEnumerable<int> ownerKeys);

        /// <inheritdoc />
        public virtual IEnumerable<TModel> ReadByOwnerKeys(IEnumerable<int> ownerKeys) =>
            ReadByOwnerKeysAsync(ownerKeys).Result;

        /// <inheritdoc />
        public abstract Task<int> DeleteByOwnerKeyAsync(int ownerKey);

        /// <inheritdoc />
        public virtual int DeleteByOwnerKey(int ownerKey) => DeleteByOwnerKeyAsync(ownerKey).Result;

        /// <inheritdoc />
        public abstract Task<int> DeleteByOwnerKeysAsync(IEnumerable<int> ownerKeys);

        /// <inheritdoc />
        public virtual int DeleteByOwnerKeys(IEnumerable<int> ownerKeys) =>
            DeleteByOwnerKeysAsync(ownerKeys).Result;
    }
}