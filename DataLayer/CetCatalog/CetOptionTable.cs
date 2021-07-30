using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.CatalogDb3;
using Microsoft.Data.Sqlite;
using OstToolsDataLayer.Constants.CetCatalog;
using OstToolsModels.CetCatalog;

namespace OstToolsDataLayer.CetCatalog
{
    public class CetOptionTable : CetCatalog<CetOptionModel>
    {
        public CetOptionTable(string connectionString) : base(connectionString)
        {
        }

        /// <summary>
        /// Create a new Options Table
        /// </summary>
        /// <returns></returns>
        public Task CreateTableAsync()
        {
            var commandText =
                $"CREATE TABLE {CetOptionConstants.TableName} ({CetOptionConstants.IdColumnName} {CetOptionConstants.IdColumnType} PRIMARY KEY, {CetOptionConstants.CodeColumnName} {CetOptionConstants.CodeColumnType}, {CetOptionConstants.VariantsTableReferenceColumnName} {CetOptionConstants.VariantsTableReferenceColumnType}, {CetOptionConstants.EnterpriseColumnName} {CetOptionConstants.EnterpriseColumnType}, {CetOptionConstants.VendorColumnName} {CetOptionConstants.VendorColumnType}, {CetOptionConstants.PricesColumnName} {CetOptionConstants.PricesColumnType}, {CetOptionConstants.OmitOnOrderColumnName} {CetOptionConstants.OmitOnOrderColumnType}, {CetOptionConstants.OmitPartNumberOnStyleNrColumnName} {CetOptionConstants.OmitPartNumberOnStyleNrColumnType}, {CetOptionConstants.MirrorProductReferenceColumnName} {CetOptionConstants.MirrorProductReferenceColumnType}, {CetOptionConstants.MirrorAngleOfSymmetryColumnName} {CetOptionConstants.MirrorAngleOfSymmetryColumnType}, {CetOptionConstants.PackageCountColumnName} {CetOptionConstants.PackageCountColumnType}, {CetOptionConstants.CodeRangeColumnName} {CetOptionConstants.CodeRangeColumnType}, {CetOptionConstants.CodeRangeStepColumnName} {CetOptionConstants.CodeRangeStepColumnType}, {CetOptionConstants.RangeColumnName} {CetOptionConstants.RangeColumnType}, {CetOptionConstants.SkuSelectionColumnName} {CetOptionConstants.SkuSelectionColumnType}, {CetOptionConstants.UndefinedSelectionColumnName} {CetOptionConstants.UndefinedSelectionColumnType}, {CetOptionConstants.CustomOptionReferenceColumnName} {CetOptionConstants.CustomOptionReferenceColumnType}, {CetOptionConstants.DelimiterColumnName} {CetOptionConstants.DelimiterColumnType}, {CetOptionConstants.NumericSkuColumnName} {CetOptionConstants.NumericSkuColumnType}, {CetOptionConstants.MirrorOptionReferenceColumnName} {CetOptionConstants.MirrorOptionReferenceColumnType})";
            return ExecuteNonQueryAsync(commandText, new List<KeyValuePair<string, string>>());
        }

        /// <summary>
        /// Get all options.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<CetOptionModel>> GetAllAsync()
        {
            var commandText = $"SELECT * FROM Option";
            var parameters = new List<KeyValuePair<string, string>>();
            return QueryAsync(commandText, parameters);
        }

        #region Find By Code

        /// <summary>
        /// Find Collection of Options by Code
        /// </summary>
        /// <param name="code">Option Code value</param>
        /// <returns>Collection of options with matching code.</returns>
        public Task<IEnumerable<CetOptionModel>> FindByCodeAsync(string code)
        {
            const string commandText = @"SELECT * FROM Option WHERE code = $optionCode";
            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("$optionCode", code)
            };
            return QueryAsync(commandText, parameters);
        }

        /// <summary>
        /// Find All options with a list of option codes
        /// </summary>
        /// <param name="codes">Collection of codes to match options</param>
        /// <returns>All options where Code is in the provided code collection</returns>
        public Task<IEnumerable<CetOptionModel>> FindByMatchingCodesAsync(IEnumerable<string> codes)
        {
            var commandText = $"SELECT * FROM Option WHERE code IN ({string.Join(',', codes.Select(code => '"' + code + '"'))})";
            return QueryAsync(commandText, new List<KeyValuePair<string, string>>());
        }

        #endregion


        #region Find By ID

        /// <summary>
        /// Find Option By Id
        /// </summary>
        /// <param name="id">Unique Option ID</param>
        /// <returns>Option with matching Id</returns>
        public async Task<CetOptionModel> FindByIdAsync(int id)
        {
            var commandText = @"SELECT * FROM Option WHERE id = $optionCode";
            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("$optionCode", id.ToString())
            };
            var response = await QueryAsync(commandText, parameters);
            return response.FirstOrDefault();
        }

        /// <summary>
        /// Find all options with provided ID's
        /// </summary>
        /// <param name="ids">ID's of Options to find</param>
        /// <returns>All options with provided ID's</returns>
        public Task<IEnumerable<CetOptionModel>> FindByIdsAsync(IEnumerable<int> ids)
        {
            var commandText = $"SELECT * FROM Option WHERE id IN ({string.Join(',', ids)})";
            var parameters = new List<KeyValuePair<string, string>>();
            return QueryAsync(commandText, parameters);
        }

        #endregion Find By ID

        #region Deserialization

        /// <inheritdoc />
        protected override async Task<IEnumerable<CetOptionModel>> DeserializeAsync(SqliteDataReader reader)
        {
            var cetOptions = new List<CetOptionModel>();
            while (await reader.ReadAsync())
            {
                var cetOption = new CetOptionModel
                {
                    Id = reader.GetInt32(CetOptionConstants.IdColumnIndex),
                    Code = reader.GetString(CetOptionConstants.CodeColumnIndex),
                    VariantsTableReference = reader.GetString(CetOptionConstants.VariantsTableReferenceColumnIndex),
                    Enterprise = reader.GetString(CetOptionConstants.EnterpriseColumnIndex),
                    Vendor = reader.GetString(CetOptionConstants.VendorColumnIndex),
                    Prices = reader.GetString(CetOptionConstants.PricesColumnIndex),
                    OmitOnOrder = reader.GetInt32(CetOptionConstants.OmitOnOrderColumnIndex),
                    OmitPartNumberOnStyleNr = reader.GetInt32(CetOptionConstants.OmitPartNumberOnStyleNrColumnIndex),
                    MirrorProductReference = reader.GetString(CetOptionConstants.MirrorProductReferenceColumnIndex),
                    MirrorAngleOfSymmetry = reader.GetInt32(CetOptionConstants.MirrorAngleOfSymmetryColumnIndex),
                    PackageCount = reader.GetInt32(CetOptionConstants.PackageCountColumnIndex),
                    CodeRange = reader.GetString(CetOptionConstants.CodeRangeColumnIndex),
                    CodeRangeStep = reader.GetInt32(CetOptionConstants.CodeRangeStepColumnIndex),
                    Range = reader.GetString(CetOptionConstants.RangeColumnIndex),
                    SkuSelection = reader.GetInt32(CetOptionConstants.SkuSelectionColumnIndex),
                    UndefinedSelection = reader.GetInt32(CetOptionConstants.UndefinedSelectionColumnIndex),
                    CustomOptionReference = reader.GetString(CetOptionConstants.CustomOptionReferenceColumnIndex),
                    Delimiter = reader.GetString(CetOptionConstants.DelimiterColumnIndex),
                    NumericSku = reader.GetInt32(CetOptionConstants.NumericSkuColumnIndex),
                    MirrorOptionReference = reader.GetString(CetOptionConstants.MirrorOptionReferenceColumnIndex)
                };
                cetOptions.Add(cetOption);
            }

            return cetOptions;
        }

        #endregion Deserialization
    }
}
