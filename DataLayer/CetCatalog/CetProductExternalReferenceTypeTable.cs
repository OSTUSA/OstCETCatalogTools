using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.CatalogDb3;
using Microsoft.Data.Sqlite;
using OstToolsDataLayer.Constants.CetCatalog;
using OstToolsModels.CetCatalog;

namespace OstToolsDataLayer.CetCatalog
{
    public class CetProductExternalReferenceTypeTable : CetCatalog<CetProductExternalReferenceTypeModel>
    {
        public CetProductExternalReferenceTypeTable(string connectionString) : base(connectionString)
        {
        }

        #region Read By ID

        /// <summary>
        /// Read All
        /// </summary>
        /// <returns>All models in table</returns>
        public async Task<IEnumerable<CetProductExternalReferenceTypeModel>> ReadAllAsync()
        {
            var commandText = $"SELECT * FROM {CetProductExternalReferenceTypeConstants.TableName}";
            var response = await QueryAsync(commandText, new List<KeyValuePair<string, string>>());
            return response;
        }

        /// <summary>
        /// Read Option Model Reference By Id
        /// </summary>
        /// <param name="id">Unique Option Model reference ID</param>
        /// <returns>Option Model reference with matching Id</returns>
        public async Task<CetProductExternalReferenceTypeModel> ReadByIdAsync(int id)
        {
            var commandText = $"SELECT * FROM {CetProductExternalReferenceTypeConstants.TableName} WHERE id = $optionCode";
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
        public Task<IEnumerable<CetProductExternalReferenceTypeModel>> ReadByIdsAsync(IEnumerable<int> ids)
        {
            var commandText = $"SELECT * FROM {CetProductExternalReferenceTypeConstants.TableName} WHERE id IN ({string.Join(',', ids)})";
            var parameters = new List<KeyValuePair<string, string>>();
            return QueryAsync(commandText, parameters);
        }

        #endregion Read By ID

        #region Add New Model

        /// <summary>
        /// Add New Option Model Reference to table.
        /// </summary>
        /// <returns>Number of rows created</returns>
        public Task<int> CreateModelAsync(string url, string previewUrl, string usageType, string measureParam, string code, string insertionId, string pt)
        {
            var commandText =
                $"INSERT INTO {CetProductExternalReferenceTypeConstants.TableName} ({CetProductExternalReferenceTypeConstants.UrlColumnName}, {CetProductExternalReferenceTypeConstants.PreviewUrlColumnName}, {CetProductExternalReferenceTypeConstants.UsageTypeColumnName}, {CetProductExternalReferenceTypeConstants.MeasureParamColumnName}, {CetProductExternalReferenceTypeConstants.CodeColumnName}, {CetProductExternalReferenceTypeConstants.InsertionIdColumnName}, {CetProductExternalReferenceTypeConstants.PtColumnName}) VALUES {CreateValuesPartialStatement(url, previewUrl, usageType, measureParam, code, insertionId, pt)}";
            return ExecuteNonQueryAsync(commandText, new List<KeyValuePair<string, string>>());
        }

        /// <summary>
        /// Add New Option Model Reference to table.
        /// </summary>
        /// <returns>Number of rows created</returns>
        public Task<int> CreateModelAsync(CetProductExternalReferenceTypeModel model) => CreateModelAsync(model.Url, model.PreviewUrl, model.UsageType, model.MeasureParameter, model.Code, model.InsertionId, model.Pt);

        /// <summary>
        /// Add New Option Model References to table.
        /// </summary>
        /// <returns>Number of rows created</returns>
        public Task<int> CreateModelsAsync(IEnumerable<CetProductExternalReferenceTypeModel> models)
        {
            var toInsert = models.Select(model => CreateValuesPartialStatement(model.Url, model.PreviewUrl, model.UsageType, model.MeasureParameter, model.Code, model.InsertionId, model.Pt)).ToList();
            var commandText =
                $"INSERT INTO {CetProductExternalReferenceTypeConstants.TableName} ({CetProductExternalReferenceTypeConstants.UrlColumnName}, {CetProductExternalReferenceTypeConstants.PreviewUrlColumnName}, {CetProductExternalReferenceTypeConstants.UsageTypeColumnName}, {CetProductExternalReferenceTypeConstants.MeasureParamColumnName}, {CetProductExternalReferenceTypeConstants.CodeColumnName}, {CetProductExternalReferenceTypeConstants.InsertionIdColumnName}, {CetProductExternalReferenceTypeConstants.PtColumnName}) VALUES {string.Join(',', toInsert)};";

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
                $"DELETE FROM {CetProductExternalReferenceTypeConstants.TableName} WHERE {CetProductExternalReferenceTypeConstants.IdColumnName} = {id}";
            return ExecuteNonQueryAsync(commandText, new List<KeyValuePair<string, string>>());
        }

        /// <summary>
        /// Delete Reference
        /// </summary>
        /// <param name="model">Model to remove from table</param>
        /// <returns>number of effected rows.</returns>
        public Task<int> DeleteByIdAsync(CetProductExternalReferenceTypeModel model) => DeleteByIdAsync(model.Id);

        /// <summary>
        /// Delete all references with matching Id's
        /// </summary>
        /// <param name="ids">Reference Id collection</param>
        /// <returns>number of effected rows.</returns>
        public Task<int> DeleteByIdsAsync(IEnumerable<int> ids)
        {
            var commandText =
                $"DELETE FROM {CetProductExternalReferenceTypeConstants.TableName} WHERE {CetProductExternalReferenceTypeConstants.IdColumnName} IN ({string.Join(',', ids.Distinct())});";
            return ExecuteNonQueryAsync(commandText, new List<KeyValuePair<string, string>>());
        }

        /// <summary>
        /// Delete all references provided.
        /// </summary>
        /// <param name="models">Models to remove</param>
        /// <returns>number of effected rows.</returns>
        public Task<int> DeleteByIdsAsync(IEnumerable<CetProductExternalReferenceTypeModel> models) =>
            DeleteByIdsAsync(models.Select(model => model.Id));

        #endregion

        #region Update

        public Task<int> Update(CetProductExternalReferenceTypeModel model)
        {
            var command =
                $"UPDATE {CetProductExternalReferenceTypeConstants.TableName} SET {CetProductExternalReferenceTypeConstants.UrlColumnName}='{model.Url}', {CetProductExternalReferenceTypeConstants.PreviewUrlColumnName}='{model.PreviewUrl}', {CetProductExternalReferenceTypeConstants.UsageTypeColumnName}='{model.UsageType}',{CetProductExternalReferenceTypeConstants.MeasureParamColumnName}='{model.MeasureParameter}', {CetProductExternalReferenceTypeConstants.CodeColumnName}='{model.Code}', {CetProductExternalReferenceTypeConstants.InsertionIdColumnName}='{model.InsertionId}', {CetProductExternalReferenceTypeConstants.PtColumnName}='{model.Pt}' WHERE {CetProductExternalReferenceTypeConstants.IdColumnName} = '{model.Id}'";
            return ExecuteNonQueryAsync(command, new List<KeyValuePair<string, string>>());
        }

        #endregion

        #region Sqlite Helper Methods

        /// <summary>
        /// Creates the Values portion of a create statement.
        /// </summary>
        /// <returns>Formatted 'Value' portion of SQL statement.</returns>
        private static string CreateValuesPartialStatement(string url, string previewUrl, string usageType, string measureParameter, string code, string insertionId, string pt)
        {
            return $"('{url}', '{previewUrl}', '{usageType}', '{measureParameter}', '{code}', '{insertionId}', '{pt}')";
        }

        #endregion


        protected override async Task<IEnumerable<CetProductExternalReferenceTypeModel>> DeserializeAsync(SqliteDataReader reader)
        {
            var productExternalReferences = new List<CetProductExternalReferenceTypeModel>();
            while (await reader.ReadAsync())
            {
                var productExternalReference = new CetProductExternalReferenceTypeModel
                {
                    Id = reader.GetInt32(CetProductExternalReferenceTypeConstants.IdColumnIndex),
                    Url = reader.GetString(CetProductExternalReferenceTypeConstants.UrlColumnIndex),
                    PreviewUrl = reader.GetString(CetProductExternalReferenceTypeConstants.PreviewUrlColumnIndex),
                    UsageType = reader.GetString(CetProductExternalReferenceTypeConstants.UsageTypeColumnIndex),
                    MeasureParameter = reader.GetString(CetProductExternalReferenceTypeConstants.MeasureParamColumnIndex),
                    Code = reader.GetString(CetProductExternalReferenceTypeConstants.CodeColumnIndex),
                    InsertionId = reader.GetString(CetProductExternalReferenceTypeConstants.InsertionIdColumnIndex),
                    Pt = reader.GetString(CetProductExternalReferenceTypeConstants.PtColumnIndex),
                };
                productExternalReferences.Add(productExternalReference);
            }

            return productExternalReferences;
        }
    }
}
