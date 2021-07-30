using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeatureOptionCleaner.Models;
using Microsoft.Data.Sqlite;

namespace FeatureOptionCleaner.Cleaners
{
    public class FeatureCleaner : CatalogCleaner
    {
        public FeatureCleaner(string connectionString) : base(connectionString)
        {
        }

        /// <summary>
        /// Find Feature by Unique id
        /// </summary>
        /// <param name="id">Unique id</param>
        /// <returns>Feature with matching ID</returns>
        public Feature FindFeatureById(int id)
        {
            var commandText = @"SELECT * FROM SFeature WHERE id = $id";
            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("$id", id.ToString())
            };

            return Query(commandText, parameters, DeserializeFeatures).FirstOrDefault();
        }

        /// <summary>
        /// Find Feature by Feature code
        /// </summary>
        /// <param name="featureCode">Feature code</param>
        /// <returns>All Features with matching feature code</returns>
        public IEnumerable<Feature> FindFeatureByCode(string featureCode)
        {
            var commandText = @"SELECT * FROM SFeature WHERE code = $featureCode";
            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("$featureCode", featureCode)
            };

            return Query(commandText, parameters, DeserializeFeatures);
        }

        /// <summary>
        /// Find All features with that are in collection of provided feature Codes
        /// </summary>
        /// <param name="featureCodes">Collection of feature codes</param>
        /// <returns>Matching Feature collection</returns>
        public IEnumerable<Feature> FindFeaturesByMultiCodes(IEnumerable<string> featureCodes)
        {
            var formattedFeatures = string.Join(',', featureCodes.Select(code=> '"' + code + '"'));
            var commandText = $"SELECT * FROM SFeature WHERE code IN ({formattedFeatures})";
            var parameters = new List<KeyValuePair<string, string>>
            {
                // new KeyValuePair<string, string>("@featureCodes", formattedFeatures)
            };

             return Query(commandText, parameters, DeserializeFeatures);
        }

        /// <summary>
        /// Find Feature by Feature code
        /// </summary>
        /// <param name="ownerKey">Feature id is the FeatureOptionInfoReference.ownerKey</param>
        /// <returns>All FeatureOptionInfoReferences with matching OwnerKey</returns>
        public IEnumerable<FeatureOptionInfoReference> FindFeatureOptionInfoReferenceByOwnerKey(int ownerKey)
        {
            var commandText = @"SELECT * FROM SFeature_optionInfoREF WHERE ownerKey = $id";
            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("$id", ownerKey.ToString())
            };

            return Query(commandText, parameters, DeserializeFeatureOptionInfoReferences);
        }

        /// <summary>
        /// Find Feature by Feature code
        /// </summary>
        /// <param name="ownerKey">Feature id is the FeatureOptionInfoReference.ownerKey</param>
        /// <returns>All FeatureOptionInfoReferences with matching OwnerKey</returns>
        public IEnumerable<FeatureOptionInfoReference> FindFeatureOptionInfoReferencesByOwnerKeys(IEnumerable<int> ownerKeys)
        {
            var commandText = $"SELECT * FROM SFeature_optionInfoREF WHERE ownerKey IN ({string.Join(',', ownerKeys)})";
            var parameters = new List<KeyValuePair<string, string>>();

            return Query(commandText, parameters, DeserializeFeatureOptionInfoReferences);
        }

        /// <summary>
        /// Find Feature by Feature code
        /// </summary>
        /// <param name="id">Id of FeatureOptionInfoReference</param>
        /// <returns>All FeatureOptionInfoReferences with matching OwnerKey</returns>
        public FeatureOptionInfoReference FindFeatureOptionInfoReferenceById(int id)
        {
            var commandText = @"SELECT * FROM SFeature_optionInfoREF WHERE id = $id";
            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("$id", id.ToString())
            };

            return Query(commandText, parameters, DeserializeFeatureOptionInfoReferences).FirstOrDefault();
        }

        /// <summary>
        /// Deserialize Features from Sqlite Data Reader.
        /// </summary>
        /// <param name="reader">Sqlite Data reader containing query response</param>
        /// <returns>Deserialize DB query</returns>
        private IEnumerable<Feature> DeserializeFeatures(SqliteDataReader reader)
        {
            var features = new List<Feature>();
            while (reader.Read())
            {
                var feature = new Feature();
                feature.Id = reader.GetInt32(0);
                feature.Code = reader.GetString(1);
                feature.VariantsTableRef = reader.GetString(2);
                feature.Enterprise = reader.GetString(3);
                feature.Vendor = reader.GetString(4);
                feature.Prices = reader.GetString(5);
                feature.OmitOnOrder = reader.GetString(6);
                feature.OmitPNOnStyleNr = reader.GetString(7);
                feature.MirrPrdRef = reader.GetString(8);
                feature.MirrAngleOfSymmetry = reader.GetString(9);
                feature.PackageCount = reader.GetString(10);
                feature.DefaultOptionRef = reader.GetString(11);
                feature.MultipleSelection = reader.GetString(12);
                feature.OptionalSelection = reader.GetString(13);
                feature.FunctionalSelection = reader.GetString(14);
                feature.SkuSelection = reader.GetString(15);
                feature.UnitMeasure = reader.GetString(16);
                feature.GroupCode = reader.GetString(17);
                feature.DataType = reader.GetString(18);
                feature.DecimalPlaces = reader.GetString(19);
                feature.Delimiter = reader.GetString(20);
                feature.HasMtrl = reader.GetString(21);
                feature.HasGraphic = reader.GetString(22);
                feature.HasRange = reader.GetString(23);
                features.Add(feature);
            }

            return features;
        }

        /// <summary>
        /// Deserialize Feature option info reference from sqlite data reader.
        /// </summary>
        /// <param name="reader">Sqlite Data reader containing query response</param>
        /// <returns>Deserialized DB query</returns>
        private IEnumerable<FeatureOptionInfoReference> DeserializeFeatureOptionInfoReferences(SqliteDataReader reader)
        {
            var featureOptionReferences = new List<FeatureOptionInfoReference>();
            while (reader.Read())
            {
                var featureOptionReference = new FeatureOptionInfoReference();
                featureOptionReference.Id = reader.GetInt32(0);
                featureOptionReference.OwnerKey = reader.GetInt32(1);
                featureOptionReference.LookupKey = reader.GetString(2);
                featureOptionReference.ValueKey = reader.GetInt32(3);
                featureOptionReference.TypeKey = reader.GetString(4);
                featureOptionReferences.Add(featureOptionReference);
            }

            return featureOptionReferences;
        }
    }
}
