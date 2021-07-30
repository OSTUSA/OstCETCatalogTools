using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OstToolsModels.CetCatalog;
using DataLayer.CatalogDb3;
using Microsoft.Data.Sqlite;
using OstToolsDataLayer.Constants.CetCatalog;


namespace OstToolsDataLayer.CetCatalog
{
    public class CetDsProductTypeTable : CetCatalog<CetDsProductTypeModel>
    {
        public CetDsProductTypeTable(string connectionString) : base(connectionString)
        {
        }

        /// <summary>
        /// Get all products.
        /// </summary>
        /// <returns>All products in table</returns>
        public Task<IEnumerable<CetDsProductTypeModel>> GetAllAsync()
        {
            var commandText = $"SELECT * FROM {CetDsProductTypeConstants.TableName}";
            var parameters = new List<KeyValuePair<string, string>>();
            return QueryAsync(commandText, parameters);
        }

        #region Find By Code

        /// <summary>
        /// Find Collection of products by Code
        /// </summary>
        /// <param name="code">product Code value</param>
        /// <returns>Collection of products with matching code.</returns>
        public Task<IEnumerable<CetDsProductTypeModel>> FindByCodeAsync(string code)
        {
            var commandText = $"SELECT * FROM {CetDsProductTypeConstants.TableName} WHERE code = $productCode";
            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("$productCode", code)
            };
            return QueryAsync(commandText, parameters);
        }

        /// <summary>
        /// Find All products with a list of product codes
        /// </summary>
        /// <param name="codes">Collection of codes to match products</param>
        /// <returns>All products where Code is in the provided code collection</returns>
        public Task<IEnumerable<CetDsProductTypeModel>> FindByMatchingCodesAsync(IEnumerable<string> codes)
        {
            var commandText = $"SELECT * FROM {CetDsProductTypeConstants.TableName} WHERE code IN ({string.Join(',', codes.Select(code => '"' + code + '"'))})";
            return QueryAsync(commandText, new List<KeyValuePair<string, string>>());
        }

        #endregion


        #region Find By ID

        /// <summary>
        /// Find product By Id
        /// </summary>
        /// <param name="id">Unique product ID</param>
        /// <returns>product with matching Id</returns>
        public async Task<CetDsProductTypeModel> FindByIdAsync(int id)
        {
            var commandText = $"SELECT * FROM {CetDsProductTypeConstants.TableName} WHERE id = $productCode";
            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("$productCode", id.ToString())
            };
            var response = await QueryAsync(commandText, parameters);
            return response.FirstOrDefault();
        }

        /// <summary>
        /// Find all products with provided ID's
        /// </summary>
        /// <param name="ids">ID's of products to find</param>
        /// <returns>All products with provided ID's</returns>
        public Task<IEnumerable<CetDsProductTypeModel>> FindByIdsAsync(IEnumerable<int> ids)
        {
            var commandText = $"SELECT * FROM {CetDsProductTypeConstants.TableName} WHERE id IN ({string.Join(',', ids)})";
            var parameters = new List<KeyValuePair<string, string>>();
            return QueryAsync(commandText, parameters);
        }

        #endregion Find By ID

        protected override async Task<IEnumerable<CetDsProductTypeModel>> DeserializeAsync(SqliteDataReader reader)
        {
            var cetProducts = new List<CetDsProductTypeModel>();
            while (await reader.ReadAsync())
            {
                var cetProduct = new CetDsProductTypeModel
                {
                    Id = reader.GetInt32(CetDsProductTypeConstants.IdColumnIndex),
                    Code = reader.GetString(CetDsProductTypeConstants.CodeColumnIndex),
                    VariantsTableReference = reader.GetString(CetDsProductTypeConstants.VariantsTableReferenceColumnIndex),
                    Enterprise = reader.GetString(CetDsProductTypeConstants.EnterpriseColumnIndex),
                    Vendor = reader.GetString(CetDsProductTypeConstants.VendorColumnIndex),
                    Prices = reader.GetString(CetDsProductTypeConstants.PricesColumnIndex),
                    OmitOnOrder = reader.GetInt32(CetDsProductTypeConstants.OmitOnOrderColumnIndex),
                    OmitPartNumberOnStyleNr = reader.GetInt32(CetDsProductTypeConstants.OmitPartNumberOnStyleNrColumnIndex),
                    MirrorProductReference = reader.GetString(CetDsProductTypeConstants.MirrorProductReferenceColumnIndex),
                    MirrorAngleOfSymmetry = reader.GetInt32(CetDsProductTypeConstants.MirrorAngleOfSymmetryColumnIndex),
                    PackageCount = reader.GetInt32(CetDsProductTypeConstants.PackageCountColumnIndex)
                };
                cetProducts.Add(cetProduct);
            }

            return cetProducts;
        }
    }
}
