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
    public class CetExternalReferenceTypeTable : CetCatalog<CetExternalReferenceTypeModel>
    {
        /// <inheritdoc />
        public CetExternalReferenceTypeTable(string connectionString) : base(connectionString)
        {
        }

        /// <summary>
        /// Read All models from table
        /// </summary>
        /// <returns>All models in table</returns>
        public Task<IEnumerable<CetExternalReferenceTypeModel>> ReadAll()
        {
            var command = $"SELECT * FROM {CetExternalReferenceTypeConstants.TableName}";
            return QueryAsync(command, new List<KeyValuePair<string, string>>());
        }

        /// <summary>
        /// Update Model
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Number of effected rows.</returns>
        public Task<int> Update(CetExternalReferenceTypeModel model)
        {
            var command =
                $"UPDATE {CetExternalReferenceTypeConstants.TableName} SET {CetExternalReferenceTypeConstants.UrlColumnName}='{model.Url}', {CetExternalReferenceTypeConstants.PreviewUrlColumnName}='{model.PreviewUrl}', {CetExternalReferenceTypeConstants.UsageTypeColumnName}='{model.UsageType}', {CetExternalReferenceTypeConstants.MeasureParameterColumnName}='{model.MeasureParameter}' WHERE {CetExternalReferenceTypeConstants.IdColumnName} = '{model.Id}'";
            return ExecuteNonQueryAsync(command, new List<KeyValuePair<string, string>>());
        }

        /// <inheritdoc />
        protected override async Task<IEnumerable<CetExternalReferenceTypeModel>> DeserializeAsync(SqliteDataReader reader)
        {
            var models = new List<CetExternalReferenceTypeModel>();
            while (await reader.ReadAsync())
            {
                models.Add(new CetExternalReferenceTypeModel
                {
                    Id = reader.GetInt32(CetExternalReferenceTypeConstants.IdColumnIndex),
                    Url = reader.GetString(CetExternalReferenceTypeConstants.UrlColumnIndex),
                    PreviewUrl = reader.GetString(CetExternalReferenceTypeConstants.PreviewUrlColumnIndex),
                    UsageType = reader.GetString(CetExternalReferenceTypeConstants.UsageTypeColumnIndex),
                    MeasureParameter = reader.GetString(CetExternalReferenceTypeConstants.MeasureParameterColumnIndex)
                });
            }

            return models;
        }
    }
}
