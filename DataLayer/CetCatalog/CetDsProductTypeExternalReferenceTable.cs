using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.CatalogDb3;
using Microsoft.Data.Sqlite;
using OstToolsDataLayer.Constants.CetCatalog;
using OstToolsModels.CetCatalog;

namespace OstToolsDataLayer.CetCatalog
{
    public class CetDsProductTypeExternalReferenceTable : CetCatalog<CetDsProductTypeExternalReferenceModel>
    {
        public CetDsProductTypeExternalReferenceTable(string connectionString) : base(connectionString)
        {
        }

        /// <summary>
        /// Get All Option Model References
        /// </summary>
        /// <returns>All Option Model references</returns>
        public Task<IEnumerable<CetDsProductTypeExternalReferenceModel>> ReadAllAsync()
        {
            var commandText = $"SELECT * FROM {CetDsProductTypeExternalReferenceConstants.TableName}";
            return QueryAsync(commandText, new List<KeyValuePair<string, string>>());
        }

        #region Read By ID

        /// <summary>
        /// Read Option Model Reference By Id
        /// </summary>
        /// <param name="id">Unique Option Model reference ID</param>
        /// <returns>Option Model reference with matching Id</returns>
        public async Task<CetDsProductTypeExternalReferenceModel> ReadByIdAsync(int id)
        {
            var commandText = $"SELECT * FROM {CetDsProductTypeExternalReferenceConstants.TableName} WHERE id = $optionCode";
            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("$optionCode", id.ToString())
            };
            var response = await QueryAsync(commandText, parameters);
            return response.FirstOrDefault();
        }

        /// <summary>
        /// Read all options description references with provided ID's
        /// </summary>
        /// <param name="ids">ID's of Options description references to Read</param>
        /// <returns>All options description references with provided ID's</returns>
        public Task<IEnumerable<CetDsProductTypeExternalReferenceModel>> ReadByIdsAsync(IEnumerable<int> ids)
        {
            var commandText = $"SELECT * FROM {CetDsProductTypeExternalReferenceConstants.TableName} WHERE id IN ({string.Join(',', ids)})";
            var parameters = new List<KeyValuePair<string, string>>();
            return QueryAsync(commandText, parameters);
        }

        #endregion Read By ID

        #region Read By Owner Key

        /// <summary>
        /// Read all options with provided ID's
        /// </summary>
        /// <param name="ownerKey">Owner codes of Option Model references</param>
        /// <returns>All options with provided ID's</returns>
        public async Task<IEnumerable<CetDsProductTypeExternalReferenceModel>> ReadByOwnerKeyAsync(int ownerKey)
        {
            var commandText = $"SELECT * FROM {CetDsProductTypeExternalReferenceConstants.TableName} WHERE {CetDsProductTypeExternalReferenceConstants.OwnerKeyColumnName} = $optionCode";
            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("$optionCode", ownerKey.ToString())
            };
            var response = await QueryAsync(commandText, parameters);
            return response;
        }

        /// <summary>
        /// Read all options with provided ID's
        /// </summary>
        /// <param name="ownerKey">Owner codes of Option Model references</param>
        /// <returns>All options with provided ID's</returns>
        public Task<IEnumerable<CetDsProductTypeExternalReferenceModel>> ReadByOwnerKeysAsync(IEnumerable<int> ownerKey)
        {
            var commandText = $"SELECT * FROM {CetDsProductTypeExternalReferenceConstants.TableName} WHERE {CetDsProductTypeExternalReferenceConstants.OwnerKeyColumnName} IN ({string.Join(',', ownerKey)})";
            var parameters = new List<KeyValuePair<string, string>>();
            return QueryAsync(commandText, parameters);
        }

        #endregion Read By Owner Key

        #region Add New Model

        /// <summary>
        /// Add New Option Model Reference to table.
        /// </summary>
        /// <param name="ownerKey">ID of option that this description belongs to</param>
        /// <param name="valueKey">Model</param>
        /// <param name="typeKey">Model Type - Usually 'Str'</param>
        /// <returns>Number of rows created</returns>
        public Task<int> CreateModelAsync(int ownerKey, int valueKey, string typeKey)
        {
            var commandText =
                $"INSERT INTO {CetDsProductTypeExternalReferenceConstants.TableName} ({CetDsProductTypeExternalReferenceConstants.OwnerKeyColumnName}, {CetDsProductTypeExternalReferenceConstants.ValueKeyColumnName}, {CetDsProductTypeExternalReferenceConstants.TypeKeyColumnName}) VALUES {CreateValuesPartialStatement(ownerKey, valueKey, typeKey)}";
            return ExecuteNonQueryAsync(commandText, new List<KeyValuePair<string, string>>());
        }

        /// <summary>
        /// Add New Option Model Reference to table.
        /// </summary>
        /// <returns>Number of rows created</returns>
        public Task<int> CreateModelAsync(CetDsProductTypeExternalReferenceModel model) => CreateModelAsync(model.OwnerKey, model.ValueKey, model.TypeKey);

        /// <summary>
        /// Add New Option Model References to table.
        /// </summary>
        /// <returns>Number of rows created</returns>
        public Task<int> CreateModelsAsync(IEnumerable<CetDsProductTypeExternalReferenceModel> models)
        {
            var toInsert = models.Select(model => CreateValuesPartialStatement(model.OwnerKey, model.ValueKey, model.TypeKey)).ToList();
            var commandText =
                $"INSERT INTO {CetDsProductTypeExternalReferenceConstants.TableName} ({CetDsProductTypeExternalReferenceConstants.OwnerKeyColumnName}, {CetDsProductTypeExternalReferenceConstants.ValueKeyColumnName}, {CetDsProductTypeExternalReferenceConstants.TypeKeyColumnName}) VALUES {string.Join(',', toInsert)};";

            return ExecuteNonQueryAsync(commandText, new List<KeyValuePair<string, string>>());
        }

        #endregion Add New Model

        #region Delete Models

        /// <summary>
        /// Delete Reference By Id
        /// </summary>
        /// <param name="id">Id of CetOptionModel</param>
        /// <returns>Number of effected rows</returns>
        public Task<int> DeleteByIdAsync(int id)
        {
            var commandText =
                $"DELETE FROM {CetDsProductTypeExternalReferenceConstants.TableName} WHERE {CetDsProductTypeExternalReferenceConstants.IdColumnName} = {id}";
            return ExecuteNonQueryAsync(commandText, new List<KeyValuePair<string, string>>());
        }

        /// <summary>
        /// Delete Reference
        /// </summary>
        /// <param name="model">Model to remove from table</param>
        /// <returns>number of effected rows.</returns>
        public Task<int> DeleteByIdAsync(CetDsProductTypeExternalReferenceModel model) => DeleteByIdAsync(model.Id);

        /// <summary>
        /// Delete all references with matching Id's
        /// </summary>
        /// <param name="ids">Reference Id collection</param>
        /// <returns>number of effected rows.</returns>
        public Task<int> DeleteByIdsAsync(IEnumerable<int> ids)
        {
            var commandText =
                $"DELETE FROM {CetDsProductTypeExternalReferenceConstants.TableName} WHERE {CetDsProductTypeExternalReferenceConstants.IdColumnName} IN ({string.Join(',', ids.Distinct())});";
            return ExecuteNonQueryAsync(commandText, new List<KeyValuePair<string, string>>());
        }

        /// <summary>
        /// Delete all references provided.
        /// </summary>
        /// <param name="models">Models to remove</param>
        /// <returns>number of effected rows.</returns>
        public Task<int> DeleteByIdsAsync(IEnumerable<CetDsProductTypeExternalReferenceModel> models) =>
            DeleteByIdsAsync(models.Select(model => model.Id));

        /// <summary>
        /// Delete reference by Owner Key value
        /// </summary>
        /// <param name="ownerKey">Owner Id</param>
        /// <returns>number of effected rows</returns>
        public Task<int> DeleteByOwnerKeyAsync(int ownerKey)
        {
            var commandText =
                $"DELETE FROM {CetDsProductTypeExternalReferenceConstants.TableName} WHERE {CetDsProductTypeExternalReferenceConstants.OwnerKeyColumnName} = {ownerKey}";
            return ExecuteNonQueryAsync(commandText, new List<KeyValuePair<string, string>>());
        }

        /// <summary>
        /// Delete all with same owner key (Including self)
        /// </summary>
        /// <param name="model">Reference Model</param>
        /// <returns>number of effected rows</returns>
        public Task<int> DeleteByOwnerKeyAsync(CetDsProductTypeExternalReferenceModel model) => DeleteByOwnerKeyAsync(model.OwnerKey);

        /// <summary>
        /// Delete all with same owner key (Including self)
        /// </summary>
        /// <param name="ownerKeys">All owner keys to remove references of</param>
        /// <returns>number of effected rows</returns>
        public Task<int> DeleteByOwnerKeysAsync(IEnumerable<int> ownerKeys)
        {
            var commandText =
                $"DELETE FROM {CetDsProductTypeExternalReferenceConstants.TableName} WHERE {CetDsProductTypeExternalReferenceConstants.OwnerKeyColumnName} IN ({string.Join(',', ownerKeys.Distinct())});";
            return ExecuteNonQueryAsync(commandText, new List<KeyValuePair<string, string>>());
        }

        /// <summary>
        /// Delete all with same owner key (Including self)
        /// </summary>
        /// <param name="models">All owner keys to remove references of</param>
        /// <returns>number of effected rows</returns>
        public Task<int> DeleteByOwnerKeysAsync(IEnumerable<CetDsProductTypeExternalReferenceModel> models) =>
            DeleteByOwnerKeysAsync(models.Select(model => model.OwnerKey));

        #endregion

        #region Sqlite Helper Methods

        /// <summary>
        /// Creates the Values portion of a create statement.
        /// </summary>
        /// <param name="ownerKey">Owner Option ID</param>
        /// <param name="valueKey">Model</param>
        /// <param name="typeKey">Model Type - Usually 'Str'</param>
        /// <returns>Formatted 'Value' portion of SQL statement.</returns>
        private static string CreateValuesPartialStatement(int ownerKey, int valueKey,
            string typeKey)
        {
            return $"({ownerKey}, '{valueKey}', '{typeKey}')";
        }

        #endregion

        protected override async Task<IEnumerable<CetDsProductTypeExternalReferenceModel>> DeserializeAsync(SqliteDataReader reader)
        {
            var cetProductReferences = new List<CetDsProductTypeExternalReferenceModel>();
            while (await reader.ReadAsync())
            {
                var cetProductReference = new CetDsProductTypeExternalReferenceModel
                {
                    Id = reader.GetInt32(CetDsProductTypeExternalReferenceConstants.IdColumnIndex),
                    OwnerKey = reader.GetInt32(CetDsProductTypeExternalReferenceConstants.OwnerKeyColumnIndex),
                    ValueKey = reader.GetInt32(CetDsProductTypeExternalReferenceConstants.ValueKeyColumnIndex),
                    TypeKey = reader.GetString(CetDsProductTypeExternalReferenceConstants.TypeKeyColumnIndex)
                };
                cetProductReferences.Add(cetProductReference);
            }

            return cetProductReferences;
        }
    }
}
