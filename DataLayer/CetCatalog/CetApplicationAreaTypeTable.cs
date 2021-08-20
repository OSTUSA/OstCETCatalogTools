using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using DataLayer.CatalogDb3;
using Microsoft.Data.Sqlite;
using OstToolsDataLayer.Constants.CetCatalog;
using OstToolsModels.CetCatalog;

namespace OstToolsDataLayer.CetCatalog
{
    public class CetApplicationAreaTypeTable : CetCatalog<CetApplicationAreaTypeModel>
    {
        /// <inheritdoc />
        public CetApplicationAreaTypeTable(string connectionString) : base(connectionString)
        {
        }

        /// <summary>
        /// Create Table
        /// </summary>
        /// <returns>Table Creation Task</returns>
        public async Task CreateTable()
        {
            if (await MetaExists("table", "Child")) 
                return;

            const string commandText =
                "CREATE TABLE Child (id INTEGER PRIMARY KEY, code TEXT, _surfaceId TEXT, _mtrlRef TEXT)";
            await ExecuteNonQueryAsync(commandText, new List<KeyValuePair<string, string>>());
        }

        /// <summary>
        /// Create Application Area Type Surface Ids Reference Owner Key Index
        /// </summary>
        /// <returns>Index Creation task</returns>
        public async Task CreateApplicationAreaTypeSurfaceIdsReferenceOwnerKeyIndex()
        {
            if (await MetaExists("index", "ApplicationAreaType_surfaceIdsREFownerKey")) 
                return;

            const string commandText = "CREATE INDEX ApplicationAreaType_surfaceIdsREFownerKey ON ApplicationAreaType_surfaceIdsREF (ownerKey)";
            await ExecuteNonQueryAsync(commandText, new List<KeyValuePair<string, string>>());
        }



        /// <summary>
        /// Create Application Area Type Surface Ids Reference Value Key Index
        /// </summary>
        /// <returns>Index Creation Task</returns>
        public async Task CreateApplicationAreaTypeSurfaceIdsReferenceValueKeyIndex()
        {
            if (await MetaExists("index", "ApplicationAreaType_surfaceIdsREFvalueKey"))
                return;

            const string commandText =
                "CREATE INDEX ApplicationAreaType_surfaceIdsREFvalueKey ON ApplicationAreaType_surfaceIdsREF (valueKey)";
            await ExecuteNonQueryAsync(commandText, new List<KeyValuePair<string, string>>());
        }

        /// <summary>
        /// Create Application Area Type Code Index
        /// </summary>
        /// <returns>Index creation Task</returns>
        public async Task CreateApplicationAreaTypeCodeIndex()
        {
            if (await MetaExists("index", "ApplicationAreaTypecode"))
                return;

            const string commandText = "CREATE INDEX ApplicationAreaTypecode ON Child (code)";
            await ExecuteNonQueryAsync(commandText, new List<KeyValuePair<string, string>>());
        }

        /// <summary>
        /// Insert a new Application Area Type into the table
        /// </summary>
        /// <param name="code">Code</param>
        /// <param name="surfaceId">Surface Id</param>
        /// <param name="materialReference">Material Reference</param>
        /// <returns>Number of effected rows.</returns>
        public Task<int> CreateAsync(string code, string surfaceId, string materialReference)
        {
            var commandText =
                $"INSERT INTO {CetApplicationAreaTypeConstants.TableName} {CreateKeyPartialStatement()} VALUES {CreateValuesPartialStatement(code, surfaceId, materialReference)};";
            return ExecuteNonQueryAsync(commandText, new List<KeyValuePair<string, string>>());
        }

        /// <summary>
        /// Insert a new Application Area Type into the table
        /// </summary>
        /// <returns>Number of effected rows</returns>
        public Task<int> CreateAsync(CetApplicationAreaTypeModel model) =>
            CreateAsync(model.Code, model.SurfaceId, model.MaterialReference);

        /// <summary>
        /// Insert N new application area types into the table
        /// </summary>
        /// <param name="models">Models to insert</param>
        /// <returns>Number of effected rows</returns>
        public Task<int> CreateAsync(IEnumerable<CetApplicationAreaTypeModel> models)
        {
            var toInsert = models.Select(model =>
                CreateValuesPartialStatement(model.Code, model.SurfaceId, model.MaterialReference)).ToList();
            var commandText =
                $"INSERT INTO {CetApplicationAreaTypeConstants.TableName} {CreateKeyPartialStatement()} VALUES {string.Join(',', toInsert)}";
            return ExecuteNonQueryAsync(commandText, new List<KeyValuePair<string, string>>());
        }

        /// <summary>
        /// Creates the Values portion of a create statement.
        /// </summary>
        /// <returns>Formatted 'Value' portion of SQL statement.</returns>
        private static string CreateValuesPartialStatement(string code, string surfaceId, string materialReference)
        {
            return $"('{code}', '{surfaceId}', '{materialReference}')";
        }

        /// <summary>
        /// Creates the Keys portion of a insert statement
        /// </summary>
        /// <returns>Formatted 'Key' portion of SQL insert statement.</returns>
        private static string CreateKeyPartialStatement()
        {
            return
                $"({CetApplicationAreaTypeConstants.CodeColumnName}, {CetApplicationAreaTypeConstants.SurfaceIdColumnName}, {CetApplicationAreaTypeConstants.MaterialReferenceColumnName})";
        }

        public Task<IEnumerable<CetApplicationAreaTypeModel>> ReadAllAsync()
        {
            var commandText = $"SELECT * FROM {CetApplicationAreaTypeConstants.TableName}";
            return QueryAsync(commandText, new List<KeyValuePair<string, string>>());
        }


        /// <inheritdoc />
        protected override async Task<IEnumerable<CetApplicationAreaTypeModel>> DeserializeAsync(SqliteDataReader reader)
        {
            var collection = new List<CetApplicationAreaTypeModel>();
            while (await reader.ReadAsync())
            {
                var model = new CetApplicationAreaTypeModel
                {
                    Id = reader.GetInt32(CetApplicationAreaTypeConstants.IdColumnIndex),
                    Code = reader.GetString(CetApplicationAreaTypeConstants.CodeColumnIndex),
                    SurfaceId = reader.GetString(CetApplicationAreaTypeConstants.SurfaceIdColumnIndex),
                    MaterialReference = reader.GetString(CetApplicationAreaTypeConstants.MaterialReferenceColumnIndex)
                };
                collection.Add(model);
            }

            return collection;
        }
    }
}
