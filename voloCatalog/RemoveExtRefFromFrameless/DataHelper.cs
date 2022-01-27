using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;


namespace voloCatalog.RemoveExtRefFromFrameless
{
    public class DataHelper
    {
        private const string _dbConnectionString = @"Data Source=C:\Users\nanderle\Long Term Docs\Trendway\Volo\Juicer_Projects\RemoveExtRefFromFrameless\TML.db3";

        //Grab our .NET instance of the CET Catalog
        public CetCatalogContext GetContext()
        {
            return new CetCatalogContext(BuildContext());
        }

        /// <summary>
        /// Build DB Context Options
        /// </summary>
        /// <returns>Builds DB Context Options with contained DB.</returns>
        private DbContextOptions<CetCatalogContext> BuildContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<CetCatalogContext>();
            optionsBuilder.UseSqlite(_dbConnectionString).EnableSensitiveDataLogging();
            return optionsBuilder.Options;
        }


        //Given a products external ref...ACTUALLY get the external ref
        public IEnumerable<PrdExternalRefType> GetProductExternalRefsByValueKey(long? valueKey)
        {
            var commandText = @"Select  * FROM PrdExternalRefType WHERE  Id = $valueKey";
            var parameters = new List<KeyValuePair<string, string>>
                {new KeyValuePair<string, string>($"$valueKey", valueKey.ToString())};
            return Query(commandText, parameters, DeserializeProductExternalRefType);
        }


        //Given a product owner id, grab the "external ref"
        public IEnumerable<DsProductTypeExternalRef> GetExternalRefsByOwnerKey(long id)
        {
            var commandText = @"Select  * FROM DsProductType_externalREF WHERE ownerKey = $id";
            var parameters = new List<KeyValuePair<string, string>>
                {new KeyValuePair<string, string>($"$id", id.ToString())};
            return Query(commandText, parameters, DeserializeDsProductExternalRefType);
        }


        //This is the Product External Ref. This guy actually holds the reference to the model URL
        private IEnumerable<PrdExternalRefType> DeserializeProductExternalRefType(SqliteDataReader reader)
        {
            var refs = new List<PrdExternalRefType>();
            while (reader.Read())
            {
                var res = new PrdExternalRefType();
                res.Id = reader.GetInt32(0);
                res.Url = reader.GetString(1);
                refs.Add(res);
            }

            return refs;
        }

        //DsProduct External Ref has a parent of DsProduct and a child of a ProductExternalRef
        private IEnumerable<DsProductTypeExternalRef> DeserializeDsProductExternalRefType(SqliteDataReader reader)
        {
            var refs = new List<DsProductTypeExternalRef>();
            while (reader.Read())
            {
                var res = new DsProductTypeExternalRef();
                res.Id = reader.GetInt32(0);
                res.OwnerKey = reader.GetInt32(1);
                res.ValueKey = reader.GetInt32(2);
                res.TypeKey = reader.GetString(3);
                refs.Add(res);
            }

            return refs;
        }

        //Get stuff using SQL or something like that.
        protected T Query<T>(string commandText, List<KeyValuePair<string, string>> parameters, Func<SqliteDataReader, T> deserializerFuc)
        {
            using var connection = new SqliteConnection(_dbConnectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = commandText;
            foreach (var keyValuePair in parameters)
            {
                command.Parameters.AddWithValue(keyValuePair.Key, keyValuePair.Value);
            }

            using var reader = command.ExecuteReader();
            var response = deserializerFuc(reader);
            connection.Close();
            return response;
        }
    }
}
