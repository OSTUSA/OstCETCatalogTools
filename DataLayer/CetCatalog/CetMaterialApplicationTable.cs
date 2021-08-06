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
    public class CetMaterialApplicationTable : CetCatalog<CetMaterialApplicationModel>
    {
        /// <inheritdoc />
        public CetMaterialApplicationTable(string connectionString) : base(connectionString)
        {
        }

        public Task<IEnumerable<CetMaterialApplicationModel>> ReadAll()
        {
            var commandText = $"SELECT * FROM {CetMaterialApplicationConstants.TableName}";
            return QueryAsync(commandText, new List<KeyValuePair<string, string>>());
        }

        /// <inheritdoc />
        protected override async Task<IEnumerable<CetMaterialApplicationModel>> DeserializeAsync(SqliteDataReader reader)
        {
            var models = new List<CetMaterialApplicationModel>();
            while (await reader.ReadAsync())
            {
                models.Add(new CetMaterialApplicationModel
                {
                    Id = reader.GetInt32(CetMaterialApplicationConstants.IdColumnIndex),
                    MaterialReference = reader.GetString(CetMaterialApplicationConstants.MaterialReferenceColumnIndex),
                    Placement = reader.GetString(CetMaterialApplicationConstants.PlacementColumnIndex),
                    UniqueKey = reader.GetString(CetMaterialApplicationConstants.UniqueKeyColumnIndex)
                });
            }

            return models;
        }
    }
}
