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
    public class CetSMaterialExternalReferenceTable : CetCatalog<CetSMaterialExternalReferenceModel>
    {
        /// <inheritdoc />
        public CetSMaterialExternalReferenceTable(string connectionString) : base(connectionString)
        {
        }

        /// <summary>
        /// Read All Models from table
        /// </summary>
        /// <returns>All Models from table</returns>
        public Task<IEnumerable<CetSMaterialExternalReferenceModel>> ReadAll()
        {
            var command = $"SELECT * FROM {CetSMaterialExternalReferenceConstants.TableName}";
            return QueryAsync(command, new List<KeyValuePair<string, string>>());
        }

        /// <inheritdoc />
        protected override async Task<IEnumerable<CetSMaterialExternalReferenceModel>> DeserializeAsync(SqliteDataReader reader)
        {
            var models = new List<CetSMaterialExternalReferenceModel>();
            while (await reader.ReadAsync())
            {
                models.Add(new CetSMaterialExternalReferenceModel
                {
                    Id = reader.GetInt32(CetSMaterialExternalReferenceConstants.IdColumnIndex),
                    OwnerKey = reader.GetInt32(CetSMaterialExternalReferenceConstants.OwnerKeyColumnIndex),
                    ValueKey = reader.GetInt32(CetSMaterialExternalReferenceConstants.ValueKeyColumnIndex),
                    TypeKey = reader.GetString(CetSMaterialExternalReferenceConstants.TypeKeyColumnIndex)
                });
            }

            return models;
        }
    }
}
