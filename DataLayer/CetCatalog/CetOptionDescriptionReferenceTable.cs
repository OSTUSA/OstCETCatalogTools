using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.CatalogDb3;
using Microsoft.Data.Sqlite;
using OstToolsDataLayer.Constants.CetCatalog;
using OstToolsModels.CetCatalog;

namespace OstToolsDataLayer.CetCatalog
{
    public class CetOptionDescriptionReferenceTable : CetCatalog<CetOptionDescriptionReferenceModel>
    {
        public CetOptionDescriptionReferenceTable(string connectionString) : base(connectionString)
        {
        }

        /// <summary>
        /// Creates a new CET Option DescriptionReference Reference Table
        /// </summary>
        /// <returns>Table creation task</returns>
        public Task CreateTableAsync()
        {
            const string commandText = "CREATE TABLE Option_descriptionsREF (id INTEGER PRIMARY KEY, ownerKey INTEGER, lookupKey TEXT, valueKey TEXT, typeKey TEXT)";
            return ExecuteNonQueryAsync(commandText, new List<KeyValuePair<string, string>>());
        }

        /// <summary>
        /// Get All Option DescriptionReference References
        /// </summary>
        /// <returns>All Option DescriptionReference references</returns>
        public Task<IEnumerable<CetOptionDescriptionReferenceModel>> ReadAllAsync()
        {
            var commandText = $"SELECT * FROM {CetOptionDescriptionReferenceConstants.TableName}";
            return QueryAsync(commandText, new List<KeyValuePair<string, string>>());
        }

        #region Read By ID

        /// <summary>
        /// Read Option DescriptionReference Reference By Id
        /// </summary>
        /// <param name="id">Unique Option DescriptionReference reference ID</param>
        /// <returns>Option DescriptionReference reference with matching Id</returns>
        public async Task<CetOptionDescriptionReferenceModel> ReadByIdAsync(int id)
        {
            var commandText = $"SELECT * FROM {CetOptionDescriptionReferenceConstants.TableName} WHERE id = $optionCode";
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
        public Task<IEnumerable<CetOptionDescriptionReferenceModel>> ReadByIdsAsync(IEnumerable<int> ids)
        {
            var commandText = $"SELECT * FROM {CetOptionDescriptionReferenceConstants.TableName} WHERE id IN ({string.Join(',', ids)})";
            var parameters = new List<KeyValuePair<string, string>>();
            return QueryAsync(commandText, parameters);
        }

        #endregion Read By ID

        #region Read By Owner Key

        /// <summary>
        /// Read all options with provided ID's
        /// </summary>
        /// <param name="ownerKey">Owner codes of Option DescriptionReference references</param>
        /// <returns>All options with provided ID's</returns>
        public async Task<IEnumerable<CetOptionDescriptionReferenceModel>> ReadByOwnerKeyAsync(int ownerKey)
        {
            var commandText = $"SELECT * FROM {CetOptionDescriptionReferenceConstants.TableName} WHERE {CetOptionDescriptionReferenceConstants.OwnerKeyColumnName} = $optionCode";
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
        /// <param name="ownerKey">Owner codes of Option DescriptionReference references</param>
        /// <returns>All options with provided ID's</returns>
        public Task<IEnumerable<CetOptionDescriptionReferenceModel>> ReadByOwnerKeysAsync(IEnumerable<int> ownerKey)
        {
            var commandText = $"SELECT * FROM {CetOptionDescriptionReferenceConstants.TableName} WHERE {CetOptionDescriptionReferenceConstants.OwnerKeyColumnName} IN ({string.Join(',', ownerKey)})";
            var parameters = new List<KeyValuePair<string, string>>();
            return QueryAsync(commandText, parameters);
        }

        #endregion Read By Owner Key

        #region Add New Model

        /// <summary>
        /// Add New Option DescriptionReference Reference to table.
        /// </summary>
        /// <param name="ownerKey">ID of option that this description belongs to</param>
        /// <param name="lookupKey">Language code</param>
        /// <param name="valueKey">DescriptionReference</param>
        /// <param name="typeKey">DescriptionReference Type - Usually 'Str'</param>
        /// <returns>Number of rows created</returns>
        public Task<int> CreateModelAsync(int ownerKey, string lookupKey, string valueKey, string typeKey)
        {
            var commandText =
                $"INSERT INTO {CetOptionDescriptionReferenceConstants.TableName} ({CetOptionDescriptionReferenceConstants.OwnerKeyColumnName}, {CetOptionDescriptionReferenceConstants.LookupKeyColumnName}, {CetOptionDescriptionReferenceConstants.ValueKeyColumnName}, {CetOptionDescriptionReferenceConstants.TypeKeyColumnName}) VALUES {CreateValuesPartialStatement(ownerKey, lookupKey, valueKey, typeKey)}";
            return ExecuteNonQueryAsync(commandText, new List<KeyValuePair<string, string>>());
        }

        /// <summary>
        /// Add New Option DescriptionReference Reference to table.
        /// </summary>
        /// <returns>Number of rows created</returns>
        public Task<int> CreateModelAsync(CetOptionDescriptionReferenceModel model) => CreateModelAsync(model.OwnerKey, model.LookupKey, model.ValueKey, model.TypeKey);

        /// <summary>
        /// Add New Option DescriptionReference References to table.
        /// </summary>
        /// <returns>Number of rows created</returns>
        public Task<int> CreateModelsAsync(IEnumerable<CetOptionDescriptionReferenceModel> models)
        {
            var toInsert = models.Select(model => CreateValuesPartialStatement(model.OwnerKey, model.LookupKey, model.ValueKey, model.TypeKey)).ToList();
            var commandText =
                $"INSERT INTO {CetOptionDescriptionReferenceConstants.TableName} ({CetOptionDescriptionReferenceConstants.OwnerKeyColumnName}, {CetOptionDescriptionReferenceConstants.LookupKeyColumnName}, {CetOptionDescriptionReferenceConstants.ValueKeyColumnName}, {CetOptionDescriptionReferenceConstants.TypeKeyColumnName}) VALUES {string.Join(',', toInsert)};";

            return ExecuteNonQueryAsync(commandText, new List<KeyValuePair<string, string>>());
        }

        #endregion Add New Model

        #region Delete Models

        /// <summary>
        /// Delete Reference By Id
        /// </summary>
        /// <param name="id">Id of CetOptionDescriptionReference</param>
        /// <returns>Number of effected rows</returns>
        public Task<int> DeleteByIdAsync(int id)
        {
            var commandText =
                $"DELETE FROM {CetOptionDescriptionReferenceConstants.TableName} WHERE {CetOptionDescriptionReferenceConstants.IdColumnName} = {id}";
            return ExecuteNonQueryAsync(commandText, new List<KeyValuePair<string, string>>());
        }

        /// <summary>
        /// Delete Reference
        /// </summary>
        /// <param name="model">Model to remove from table</param>
        /// <returns>number of effected rows.</returns>
        public Task<int> DeleteByIdAsync(CetOptionDescriptionReferenceModel model) => DeleteByIdAsync(model.Id);

        /// <summary>
        /// Delete all references with matching Id's
        /// </summary>
        /// <param name="ids">Reference Id collection</param>
        /// <returns>number of effected rows.</returns>
        public Task<int> DeleteByIdsAsync(IEnumerable<int> ids)
        {
            var commandText =
                $"DELETE FROM {CetOptionDescriptionReferenceConstants.TableName} WHERE {CetOptionDescriptionReferenceConstants.IdColumnName} IN ({string.Join(',', ids.Distinct())});";
            return ExecuteNonQueryAsync(commandText, new List<KeyValuePair<string, string>>());
        }

        /// <summary>
        /// Delete all references provided.
        /// </summary>
        /// <param name="models">Models to remove</param>
        /// <returns>number of effected rows.</returns>
        public Task<int> DeleteByIdsAsync(IEnumerable<CetOptionDescriptionReferenceModel> models) =>
            DeleteByIdsAsync(models.Select(model => model.Id));

        /// <summary>
        /// Delete reference by Owner Key value
        /// </summary>
        /// <param name="ownerKey">Owner Id</param>
        /// <returns>number of effected rows</returns>
        public Task<int> DeleteByOwnerKeyAsync(int ownerKey)
        {
            var commandText =
                $"DELETE FROM {CetOptionDescriptionReferenceConstants.TableName} WHERE {CetOptionDescriptionReferenceConstants.OwnerKeyColumnName} = {ownerKey}";
            return ExecuteNonQueryAsync(commandText, new List<KeyValuePair<string, string>>());
        }

        /// <summary>
        /// Delete all with same owner key (Including self)
        /// </summary>
        /// <param name="model">Reference Model</param>
        /// <returns>number of effected rows</returns>
        public Task<int> DeleteByOwnerKeyAsync(CetOptionDescriptionReferenceModel model) => DeleteByOwnerKeyAsync(model.OwnerKey);

        /// <summary>
        /// Delete all with same owner key (Including self)
        /// </summary>
        /// <param name="ownerKeys">All owner keys to remove references of</param>
        /// <returns>number of effected rows</returns>
        public Task<int> DeleteByOwnerKeysAsync(IEnumerable<int> ownerKeys)
        {
            var commandText =
                $"DELETE FROM {CetOptionDescriptionReferenceConstants.TableName} WHERE {CetOptionDescriptionReferenceConstants.OwnerKeyColumnName} IN ({string.Join(',', ownerKeys.Distinct())});";
            return ExecuteNonQueryAsync(commandText, new List<KeyValuePair<string, string>>());
        }

        /// <summary>
        /// Delete all with same owner key (Including self)
        /// </summary>
        /// <param name="models">All owner keys to remove references of</param>
        /// <returns>number of effected rows</returns>
        public Task<int> DeleteByOwnerKeysAsync(IEnumerable<CetOptionDescriptionReferenceModel> models) =>
            DeleteByOwnerKeysAsync(models.Select(model => model.OwnerKey));

        #endregion

        #region Sqlite Helper Methods

        /// <summary>
        /// Creates the Values portion of a create statement.
        /// </summary>
        /// <param name="ownerKey">Owner Option ID</param>
        /// <param name="lookupKey">Language code</param>
        /// <param name="valueKey">DescriptionReference</param>
        /// <param name="typeKey">DescriptionReference Type - Usually 'Str'</param>
        /// <returns>Formatted 'Value' portion of SQL statement.</returns>
        private static string CreateValuesPartialStatement(int ownerKey, string lookupKey, string valueKey,
            string typeKey)
        {
            return $"({ownerKey}, '{lookupKey}', '{valueKey}', '{typeKey}')";
        }

        #endregion


        /// <inheritdoc />
        protected override async Task<IEnumerable<CetOptionDescriptionReferenceModel>> DeserializeAsync(SqliteDataReader reader)
        {
            var cetOptionReferences = new List<CetOptionDescriptionReferenceModel>();
            while (await reader.ReadAsync())
            {
                var cetOptionDescriptionReference = new CetOptionDescriptionReferenceModel
                {
                    Id = reader.GetInt32(CetOptionDescriptionReferenceConstants.IdColumnIndex),
                    OwnerKey = reader.GetInt32(CetOptionDescriptionReferenceConstants.OwnerKeyColumnIndex),
                    LookupKey = reader.GetString(CetOptionDescriptionReferenceConstants.LookupKeyColumnIndex),
                    ValueKey = reader.GetString(CetOptionDescriptionReferenceConstants.ValueKeyColumnIndex),
                    TypeKey = reader.GetString(CetOptionDescriptionReferenceConstants.TypeKeyColumnIndex)
                };
                cetOptionReferences.Add(cetOptionDescriptionReference);
            }

            return cetOptionReferences;
        }
    }
}
