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
    public class CetApplicationAreaTypeSurfaceIdsReferenceTable : CetCatalog<CetApplicationAreaTypeSurfaceIdsReferenceModel>
    {
        /// <inheritdoc />
        public CetApplicationAreaTypeSurfaceIdsReferenceTable(string connectionString) : base(connectionString)
        {
        }

        /// <summary>
        /// Create Table
        /// </summary>
        /// <returns>Table Creation Task</returns>
        public async Task CreateTable()
        {
            if (await MetaExists("table", CetApplicationAreaTypeSurfaceIdsReferenceConstants.TableName))
                return;

            const string commandText =
                "CREATE TABLE ApplicationAreaType_surfaceIdsREF (id INTEGER PRIMARY KEY, ownerKey INTEGER, valueKey TEXT, typeKey TEXT)";
            await ExecuteNonQueryAsync(commandText, new List<KeyValuePair<string, string>>());
        }

        /// <summary>
        /// Create Model async
        /// </summary>
        /// <param name="ownerKey">owner Key</param>
        /// <param name="valueKey">Value Key</param>
        /// <param name="typeKey">Type Key</param>
        /// <returns>Number of effected rows</returns>
        public Task<int> CreateAsync(int ownerKey, string valueKey, string typeKey)
        {
            var commandText =
                $"INSERT INTO {CetApplicationAreaTypeSurfaceIdsReferenceConstants.TableName} {CreateKeyPartialStatement()} VALUES {CreateValuesPartialStatement(ownerKey, valueKey, typeKey)}";
            return ExecuteNonQueryAsync(commandText, new List<KeyValuePair<string, string>>());
        }

        /// <summary>
        /// Create Model async
        /// </summary>
        /// <returns>Number of effected rows.</returns>
        public Task<int> CreateAsync(CetApplicationAreaTypeSurfaceIdsReferenceModel model) =>
            CreateAsync(model.OwnerKey, model.ValueKey, model.TypeKey);

        /// <summary>
        /// Create Models async
        /// </summary>
        /// <param name="models">Models to insert</param>
        /// <returns>Number of effected rows.</returns>
        public Task<int> CreateAsync(IEnumerable<CetApplicationAreaTypeSurfaceIdsReferenceModel> models)
        {
            var toInsert = models.Select(model =>
                CreateValuesPartialStatement(model.OwnerKey, model.ValueKey, model.TypeKey)).ToList();
            var commandText =
                $"INSERT INTO {CetApplicationAreaTypeSurfaceIdsReferenceConstants.TableName} {CreateKeyPartialStatement()} VALUES {string.Join(',', toInsert)}";

            return ExecuteNonQueryAsync(commandText, new List<KeyValuePair<string, string>>());
        }

        /// <summary>
        /// Read All models from table
        /// </summary>
        /// <returns>All models in table</returns>
        public Task<IEnumerable<CetApplicationAreaTypeSurfaceIdsReferenceModel>> ReadAllAsync()
        {
            var commandText = $"SELECT * FROM {CetApplicationAreaTypeSurfaceIdsReferenceConstants.TableName}";
            return QueryAsync(commandText, new List<KeyValuePair<string, string>>());
        }


        /// <summary>
        /// Creates the Values portion of a create statement.
        /// </summary>
        /// <returns>Formatted 'Value' portion of SQL statement.</returns>
        private static string CreateValuesPartialStatement(int ownerKey, string valueKey, string typeKey)
        {
            return $"({ownerKey}, '{valueKey}', '{typeKey}')";
        }

        /// <summary>
        /// Creates the Keys portion of a insert statement
        /// </summary>
        /// <returns>Formatted 'Key' portion of SQL insert statement.</returns>
        private static string CreateKeyPartialStatement()
        {
            return
                $"({CetApplicationAreaTypeSurfaceIdsReferenceConstants.OwnerKeyColumnName}, {CetApplicationAreaTypeSurfaceIdsReferenceConstants.ValueKeyColumnName}, {CetApplicationAreaTypeSurfaceIdsReferenceConstants.TypeKeyColumnName})";
        }

        /// <inheritdoc />
        protected override async Task<IEnumerable<CetApplicationAreaTypeSurfaceIdsReferenceModel>> DeserializeAsync(SqliteDataReader reader)
        {
            var models = new List<CetApplicationAreaTypeSurfaceIdsReferenceModel>();
            while (await reader.ReadAsync())
            {
                models.Add(new CetApplicationAreaTypeSurfaceIdsReferenceModel
                {
                    Id = reader.GetInt32(CetApplicationAreaTypeSurfaceIdsReferenceConstants.IdColumnIndex),
                    OwnerKey = reader.GetInt32(CetApplicationAreaTypeSurfaceIdsReferenceConstants.OwnerKeyColumnIndex),
                    ValueKey = reader.GetString(CetApplicationAreaTypeSurfaceIdsReferenceConstants.ValueKeyColumnIndex),
                    TypeKey = reader.GetString(CetApplicationAreaTypeSurfaceIdsReferenceConstants.TypeKeyColumnIndex)
                });
            }

            return models;
        }
    }
}
