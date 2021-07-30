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
    public class CetSMaterialTable : CetCatalog<CetSMaterialModel>
    {
        /// <inheritdoc />
        public CetSMaterialTable(string connectionString) : base(connectionString)
        {
        }

        /// <summary>
        /// Read All Async
        /// </summary>
        /// <returns>All Models in table</returns>
        public Task<IEnumerable<CetSMaterialModel>> ReadAllAsync()
        {
            var commandText = $"SELECT * FROM {CetSMaterialConstants.TableName}";
            return QueryAsync(commandText, new List<KeyValuePair<string, string>>());
        }

        /// <inheritdoc />
        protected override async Task<IEnumerable<CetSMaterialModel>> DeserializeAsync(SqliteDataReader reader)
        {
            var models = new List<CetSMaterialModel>();
            while (await reader.ReadAsync())
            {
                models.Add(new CetSMaterialModel
                {
                    Id = reader.GetInt32(CetSMaterialConstants.IdColumnIndex),
                    Code = reader.GetString(CetSMaterialConstants.CodeColumnIndex),
                    VariantsTableReference = reader.GetString(CetSMaterialConstants.VariantsTableReferenceColumnIndex),
                    Directional = reader.GetInt32(CetSMaterialConstants.DirectionalColumnIndex)
                });
            }

            return models;
        }
    }
}
