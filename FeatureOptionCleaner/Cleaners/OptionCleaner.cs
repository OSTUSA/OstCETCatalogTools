using System.Collections.Generic;
using System.Linq;
using FeatureOptionCleaner.Models;
using Microsoft.Data.Sqlite;

namespace FeatureOptionCleaner.Cleaners
{
    public class OptionCleaner : CatalogCleaner
    {
        public OptionCleaner(string connectionString) : base(connectionString)
        {
        }

        /// <summary>
        /// Find Options by Option Code
        /// </summary>
        /// <param name="optionCode">Option Code value</param>
        /// <returns>Collection of Options with matching code</returns>
        public IEnumerable<Option> FindOptionsByCode(string optionCode)
        {
            // TILE12

            var commandText = @"SELECT * FROM Option WHERE code = $optionCode";
            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("$optionCode", optionCode)
            };
            return Query(commandText, parameters, DeserializeOptions);
        }

        /// <summary>
        /// Find Option By ID
        /// </summary>
        /// <param name="id">ID of Option</param>
        /// <returns>Option with matching ID. ID is unique.</returns>
        public Option FindOptionById(int id)
        {
            var commandText = @"SELECT * FROM Option WHERE id = $optionCode";
            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("$optionCode", id.ToString())
            };
            return Query(commandText, parameters, DeserializeOptions).FirstOrDefault();
        }

        /// <summary>
        /// Get Material Application Ref of option by ID. Id is Unique.
        /// </summary>
        /// <param name="id">Unique Option Material Ref ID</param>
        /// <returns>Option Material Reference with matching ID</returns>
        public OptionMaterialApplicationsRef GetMaterialApplicationsRefById(int id)
        {
            var commandText = @"Select  * FROM Option_mtrlApplicationsREF WHERE ID = $id";
            var parameters = new List<KeyValuePair<string, string>>
                {new KeyValuePair<string, string>($"$id", id.ToString())};
            return Query(commandText, parameters, DeserializeMaterialApplicationsRefs).FirstOrDefault();
        }

        /// <summary>
        /// All Material Application References with matching Owner key.
        /// </summary>
        /// <param name="id">Option Owner ID</param>
        /// <returns>All material references with matching owner ID</returns>
        public IEnumerable<OptionMaterialApplicationsRef> GetMaterialApplicationsRefsByOwnerKey(int id)
        {
            var commandText = @"Select  * FROM Option_mtrlApplicationsREF WHERE ownerKey = $id";
            var parameters = new List<KeyValuePair<string, string>>
                {new KeyValuePair<string, string>($"$id", id.ToString())};
            return Query(commandText, parameters, DeserializeMaterialApplicationsRefs);
        }

        public IEnumerable<Option> GetOptionsByIds(IEnumerable<int> ids)
        {
            var commandText = $"SELECT * FROM Option WHERE id IN ({string.Join(',', ids)})";
            var parameters = new List<KeyValuePair<string, string>>();
            return Query(commandText, parameters, DeserializeOptions);
        }

        public IEnumerable<Option> GetOptionsByCodes(IEnumerable<string> codes)
        {
            var commandText = $"SELECT * FROM Option WHERE code IN ({string.Join(',', codes.Select(code => '"' + code + '"'))})";
            return Query(commandText, new List<KeyValuePair<string, string>>(), DeserializeOptions);
        }

        public IEnumerable<OptionMaterialApplicationsRef> GetMaterialApplicationsRefsByOwnerKeys(IEnumerable<int> ids)
        {
            var formattedIds = string.Join(',', ids);
            var commandText = $"Select  * FROM Option_mtrlApplicationsREF WHERE ownerKey IN ({formattedIds})";
            var parameters = new List<KeyValuePair<string, string>>();
            return Query(commandText, parameters, DeserializeMaterialApplicationsRefs);
        }


        /// <summary>
        /// Dry Run of Delete Material reference with matching ID
        /// </summary>
        /// <param name="id">ID of material reference you would like to delete</param>
        /// <returns>Number of rows that would have been deleted</returns>
        public int DeleteMaterialReferenceDryRun(int id)
        {
            var commandText = "DELETE FROM Option_mtrlApplicationsREF WHERE id = $id";
            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("$id", id.ToString())
            };
            return ExecuteNonQueryDryRun(commandText, parameters);
        }

        /// <summary>
        /// Delete Material reference with matching ID
        /// </summary>
        /// <param name="id">ID of material reference you would like to delete</param>
        /// <returns>Number of rows deleted</returns>
        public int DeleteMaterialReference(int id)
        {
            var commandText = "DELETE FROM Option_mtrlApplicationsREF WHERE id = $id";
            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("$id", id.ToString())
            };
            return ExecuteNonQuery(commandText, parameters);
        }

        /// <summary>
        /// Dry Run of Delete Material reference with matching ID
        /// </summary>
        /// <param name="id">ID of material reference you would like to delete</param>
        /// <returns>Number of rows that would have been deleted</returns>
        public int DeleteMaterialReferencesDryRun(IEnumerable<int> ids)
        {
            var commandText = $"DELETE FROM Option_mtrlApplicationsREF WHERE id IN ({string.Join(',', ids)})";
            var parameters = new List<KeyValuePair<string, string>>();
            return ExecuteNonQueryDryRun(commandText, parameters);
        }

        /// <summary>
        /// Dry Run of Delete Material reference with matching ID
        /// </summary>
        /// <param name="id">ID of material reference you would like to delete</param>
        /// <returns>Number of rows that would have been deleted</returns>
        public int DeleteMaterialReferences(IEnumerable<int> ids)
        {
            var commandText = $"DELETE FROM Option_mtrlApplicationsREF WHERE id IN ({string.Join(',', ids)})";
            var parameters = new List<KeyValuePair<string, string>>();
            return ExecuteNonQuery(commandText, parameters);
        }

        /// <summary>
        /// Deserialize Option from SQL response
        /// </summary>
        /// <param name="reader">Sqlite Reader</param>
        /// <returns>Deserialized Options</returns>
        private IEnumerable<Option> DeserializeOptions(SqliteDataReader reader)
        {
            var options = new List<Option>();
            while (reader.Read())
            {
                var option = new Option();
                option.Id = reader.GetInt32(0);
                option.Code = reader.GetString(1);
                option.VariantsTableRef = reader.GetString(2);
                option.Enterprise = reader.GetString(3);
                option.Vendor = reader.GetString(4);
                option.Prices = reader.GetString(5);
                option.OmitOnOrder = reader.GetString(6);
                option.OmitPNOnStyleNr = reader.GetString(7);
                option.MirrPrdRef = reader.GetString(8);
                option.MirrAngleOfSymmetry = reader.GetString(9);
                option.PackageCount = reader.GetString(10);
                option.CodeRange = reader.GetString(11);
                option.CodeRangeStep = reader.GetString(12);
                option.Range = reader.GetString(13);
                option.SkuSelection = reader.GetString(14);
                option.UndefinedSelection = reader.GetString(15);
                option.CustomOptionRef = reader.GetString(16);
                option.Delimiter = reader.GetString(17);
                option.NumericSku = reader.GetString(18);
                option.MirrorOptionRef = reader.GetString(19);
                options.Add(option);
            }

            return options;
        }

        /// <summary>
        /// Deserialize Option Material Application Reference from Sqlite Data Reader
        /// </summary>
        /// <param name="reader">Sqlite Data Reader</param>
        /// <returns>Deserialized Option Material Application References.</returns>
        private IEnumerable<OptionMaterialApplicationsRef> DeserializeMaterialApplicationsRefs(SqliteDataReader reader)
        {
            var materialRefs = new List<OptionMaterialApplicationsRef>();
            while (reader.Read())
            {
                var materialRef = new OptionMaterialApplicationsRef();
                materialRef.Id = reader.GetInt32(0);
                materialRef.OwnerKey = reader.GetInt32(1);
                materialRef.ValueKey = reader.GetInt32(2);
                materialRef.TypeKey = reader.GetString(3);
                materialRefs.Add(materialRef);
            }

            return materialRefs;
        }
    }
}
