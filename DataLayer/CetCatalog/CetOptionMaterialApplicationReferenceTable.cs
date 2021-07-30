using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.CatalogDb3;
using DataLayer.Constants.CetCatalog;
using Microsoft.Data.Sqlite;
using OstToolsModels.CetCatalog;

namespace DataLayer.CetCatalog
{
    public class CetOptionMaterialApplicationReferenceTable : CetCatalog<CetOptionMaterialApplicationReferenceModel>
    {
        public CetOptionMaterialApplicationReferenceTable(string connectionString) : base(connectionString)
        {
        }

        /// <summary>
        /// Creates a new CET Option Material Reference Table
        /// </summary>
        /// <returns>Table creation task</returns>
        public Task CreateTableAsync()
        {
            var commandText = $"CREATE TABLE {CetOptionMaterialApplicationsReferenceConstants.TableName} (id INTEGER PRIMARY KEY, ownerKey INTEGER, valueKey INTEGER, typeKey TEXT)";
            return ExecuteNonQueryAsync(commandText, new List<KeyValuePair<string, string>>());
        }

        /// <summary>
        /// Get All Option Material Application References
        /// </summary>
        /// <returns>All Option DescriptionReference references</returns>
        public Task<IEnumerable<CetOptionMaterialApplicationReferenceModel>> GetAllAsync()
        {
            var commandText = $"SELECT * FROM {CetOptionMaterialApplicationsReferenceConstants.TableName}";
            return QueryAsync(commandText, new List<KeyValuePair<string, string>>());
        }

        #region Find By ID

        /// <summary>
        /// Find Option DescriptionReference Reference By Id
        /// </summary>
        /// <param name="id">Unique Option DescriptionReference reference ID</param>
        /// <returns>Option DescriptionReference reference with matching Id</returns>
        public async Task<CetOptionMaterialApplicationReferenceModel> FindByIdAsync(int id)
        {
            var commandText = $"SELECT * FROM {CetOptionMaterialApplicationsReferenceConstants.TableName} WHERE id = $optionCode";
            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("$optionCode", id.ToString())
            };
            var response = await QueryAsync(commandText, parameters);
            return response.FirstOrDefault();
        }

        /// <summary>
        /// Find all options description references with provided ID's
        /// </summary>
        /// <param name="ids">ID's of Options description references to find</param>
        /// <returns>All options description references with provided ID's</returns>
        public Task<IEnumerable<CetOptionMaterialApplicationReferenceModel>> FindByIdsAsync(IEnumerable<int> ids)
        {
            var commandText = $"SELECT * FROM {CetOptionMaterialApplicationsReferenceConstants.TableName} WHERE id IN ({string.Join(',', ids)})";
            var parameters = new List<KeyValuePair<string, string>>();
            return QueryAsync(commandText, parameters);
        }

        #endregion Find By ID

        #region Find By Owner Key

        /// <summary>
        /// Find all options with provided ID's
        /// </summary>
        /// <param name="ownerKey">Owner codes of Option DescriptionReference references</param>
        /// <returns>All options with provided ID's</returns>
        public async Task<IEnumerable<CetOptionMaterialApplicationReferenceModel>> FindByOwnerKeyAsync(int ownerKey)
        {
            var commandText = $"SELECT * FROM {CetOptionMaterialApplicationsReferenceConstants.TableName} WHERE {CetOptionMaterialApplicationsReferenceConstants.OwnerKeyColumnName} = $optionCode";
            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("$optionCode", ownerKey.ToString())
            };
            var response = await QueryAsync(commandText, parameters);
            return response;
        }

        /// <summary>
        /// Find all options with provided ID's
        /// </summary>
        /// <param name="ownerKey">Owner codes of Option DescriptionReference references</param>
        /// <returns>All options with provided ID's</returns>
        public Task<IEnumerable<CetOptionMaterialApplicationReferenceModel>> FindByOwnerKeysAsync(IEnumerable<int> ownerKey)
        {
            var commandText = $"SELECT * FROM {CetOptionMaterialApplicationsReferenceConstants.TableName} WHERE {CetOptionMaterialApplicationsReferenceConstants.OwnerKeyColumnName} IN ({string.Join(',', ownerKey)})";
            var parameters = new List<KeyValuePair<string, string>>();
            return QueryAsync(commandText, parameters);
        }

        #endregion Find By Owner Key

        #region Add New Model

        /// <summary>
        /// Add New Option DescriptionReference Reference to table.
        /// </summary>
        /// <param name="ownerKey">ID of option that this description belongs to</param>
        /// <param name="valueKey">DescriptionReference</param>
        /// <param name="typeKey">DescriptionReference Type - Usually 'Str'</param>
        /// <returns>Number of rows created</returns>
        public Task<int> AddNewReferenceAsync(int ownerKey, int valueKey, string typeKey)
        {
            var commandText =
                $"INSERT INTO {CetOptionMaterialApplicationsReferenceConstants.TableName} ({CetOptionMaterialApplicationsReferenceConstants.OwnerKeyColumnName}, {CetOptionMaterialApplicationsReferenceConstants.ValueKeyColumnName}, {CetOptionMaterialApplicationsReferenceConstants.TypeKeyColumnName}) VALUES {CreateValuesPartialStatement(ownerKey, valueKey, typeKey)}";
            return ExecuteNonQueryAsync(commandText, new List<KeyValuePair<string, string>>());
        }

        /// <summary>
        /// Add New Option DescriptionReference Reference to table.
        /// </summary>
        /// <returns>Number of rows created</returns>
        public Task<int> AddNewReferenceAsync(CetOptionMaterialApplicationReferenceModel model) => AddNewReferenceAsync(model.OwnerKey, model.ValueKey, model.TypeKey);

        /// <summary>
        /// Add New Option DescriptionReference References to table.
        /// </summary>
        /// <returns>Number of rows created</returns>
        public Task<int> AddMultipleReferencesAsync(IEnumerable<CetOptionMaterialApplicationReferenceModel> models)
        {
            var toInsert = models.Select(model => CreateValuesPartialStatement(model.OwnerKey, model.ValueKey, model.TypeKey)).ToList();
            var commandText =
                $"INSERT INTO {CetOptionMaterialApplicationsReferenceConstants.TableName} ({CetOptionMaterialApplicationsReferenceConstants.OwnerKeyColumnName}, {CetOptionMaterialApplicationsReferenceConstants.ValueKeyColumnName}, {CetOptionMaterialApplicationsReferenceConstants.TypeKeyColumnName}) VALUES {string.Join(',', toInsert)};";

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
                $"DELETE FROM {CetOptionMaterialApplicationsReferenceConstants.TableName} WHERE {CetOptionMaterialApplicationsReferenceConstants.IdColumnName} = {id}";
            return ExecuteNonQueryAsync(commandText, new List<KeyValuePair<string, string>>());
        }

        /// <summary>
        /// Delete Reference
        /// </summary>
        /// <param name="model">Model to remove from table</param>
        /// <returns>number of effected rows.</returns>
        public Task<int> DeleteByIdAsync(CetOptionMaterialApplicationReferenceModel model) => DeleteByIdAsync(model.Id);

        /// <summary>
        /// Delete all references with matching Id's
        /// </summary>
        /// <param name="ids">Reference Id collection</param>
        /// <returns>number of effected rows.</returns>
        public Task<int> DeleteByIdsAsync(IEnumerable<int> ids)
        {
            var commandText =
                $"DELETE FROM {CetOptionMaterialApplicationsReferenceConstants.TableName} WHERE {CetOptionMaterialApplicationsReferenceConstants.IdColumnName} IN ({string.Join(',', ids.Distinct())});";
            return ExecuteNonQueryAsync(commandText, new List<KeyValuePair<string, string>>());
        }

        /// <summary>
        /// Delete all references provided.
        /// </summary>
        /// <param name="models">Models to remove</param>
        /// <returns>number of effected rows.</returns>
        public Task<int> DeleteByIdsAsync(IEnumerable<CetOptionMaterialApplicationReferenceModel> models) =>
            DeleteByIdsAsync(models.Select(model => model.Id));

        /// <summary>
        /// Delete reference by Owner Key value
        /// </summary>
        /// <param name="ownerKey">Owner Id</param>
        /// <returns>number of effected rows</returns>
        public Task<int> DeleteByOwnerKeyAsync(int ownerKey)
        {
            var commandText =
                $"DELETE FROM {CetOptionMaterialApplicationsReferenceConstants.TableName} WHERE {CetOptionMaterialApplicationsReferenceConstants.OwnerKeyColumnName} = {ownerKey}";
            return ExecuteNonQueryAsync(commandText, new List<KeyValuePair<string, string>>());
        }

        /// <summary>
        /// Delete all with same owner key (Including self)
        /// </summary>
        /// <param name="model">Reference Model</param>
        /// <returns>number of effected rows</returns>
        public Task<int> DeleteByOwnerKeyAsync(CetOptionMaterialApplicationReferenceModel model) => DeleteByOwnerKeyAsync(model.OwnerKey);

        /// <summary>
        /// Delete all with same owner key (Including self)
        /// </summary>
        /// <param name="ownerKeys">All owner keys to remove references of</param>
        /// <returns>number of effected rows</returns>
        public Task<int> DeleteByOwnerKeysAsync(IEnumerable<int> ownerKeys)
        {
            var commandText =
                $"DELETE FROM {CetOptionMaterialApplicationsReferenceConstants.TableName} WHERE {CetOptionMaterialApplicationsReferenceConstants.OwnerKeyColumnName} IN ({string.Join(',', ownerKeys.Distinct())});";
            return ExecuteNonQueryAsync(commandText, new List<KeyValuePair<string, string>>());
        }

        /// <summary>
        /// Delete all with same owner key (Including self)
        /// </summary>
        /// <param name="models">All owner keys to remove references of</param>
        /// <returns>number of effected rows</returns>
        public Task<int> DeleteByOwnerKeysAsync(IEnumerable<CetOptionMaterialApplicationReferenceModel> models) =>
            DeleteByOwnerKeysAsync(models.Select(model => model.OwnerKey));

        #endregion

        #region Sqlite Helper Methods

        /// <summary>
        /// Creates the Values portion of a create statement.
        /// </summary>
        /// <param name="ownerKey">Owner Option ID</param>
        /// <param name="valueKey">DescriptionReference</param>
        /// <param name="typeKey">DescriptionReference Type - Usually 'Str'</param>
        /// <returns>Formatted 'Value' portion of SQL statement.</returns>
        private static string CreateValuesPartialStatement(int ownerKey, int valueKey,
            string typeKey)
        {
            return $"({ownerKey}, '{valueKey}', '{typeKey}')";
        }

        #endregion

        /// <inheritdoc />
        protected override async Task<IEnumerable<CetOptionMaterialApplicationReferenceModel>> DeserializeAsync(SqliteDataReader reader)
        {
            var cetOptionReferences = new List<CetOptionMaterialApplicationReferenceModel>();
            while (await reader.ReadAsync())
            {
                var cetOptionDescriptionReference = new CetOptionMaterialApplicationReferenceModel
                {
                    Id = reader.GetInt32(CetOptionMaterialApplicationsReferenceConstants.IdColumnIndex),
                    OwnerKey = reader.GetInt32(CetOptionMaterialApplicationsReferenceConstants.OwnerKeyColumnIndex),
                    ValueKey = reader.GetInt32(CetOptionMaterialApplicationsReferenceConstants.ValueKeyColumnIndex),
                    TypeKey = reader.GetString(CetOptionMaterialApplicationsReferenceConstants.TypeKeyColumnIndex)
                };
                cetOptionReferences.Add(cetOptionDescriptionReference);
            }

            return cetOptionReferences;
        }
    }
}
