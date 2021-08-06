using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.CetCatalog;
using OstToolsDataLayer.CetCatalog;
using OstToolsModels.CetCatalog;

namespace OstToolsBc.CetCatalogBc
{
    public class CetOptionBc : CetCrudCatalogBc<CetOptionModel>
    {
        private readonly ICetCrudReferenceBc<CetOptionMaterialApplicationReferenceModel> _materialApplicationBc;
        private readonly ICetCrudReferenceBc<CetOptionDescriptionReferenceModel> _descriptionBc;
        private readonly CetOptionTable _optionTable;

        public CetOptionBc(CetOptionTable optionTable, ICetCrudReferenceBc<CetOptionMaterialApplicationReferenceModel> materialApplicationBc, ICetCrudReferenceBc<CetOptionDescriptionReferenceModel> descriptionBc)
        {
            _materialApplicationBc = materialApplicationBc;
            _descriptionBc = descriptionBc;
            _optionTable = optionTable;
        }

        /// <summary>
        /// Populate all reference data
        /// </summary>
        /// <param name="models">Models to populate</param>
        /// <returns>Populated Models</returns>
        private async Task<IEnumerable<CetOptionModel>> PopulateReferences(IEnumerable<CetOptionModel> models)
        {
            var optionModels = models as CetOptionModel[] ?? models.ToArray();
            var modelKeys = optionModels.Select(model => model.Id).ToList();
            var descriptionTask = _descriptionBc.ReadByOwnerKeysAsync(modelKeys);
            var materialAppTask = _materialApplicationBc.ReadByOwnerKeysAsync(modelKeys);

            await Task.WhenAll(descriptionTask, materialAppTask);

            return JoinReferences(optionModels, descriptionTask.Result, materialAppTask.Result);
        }

        /// <summary>
        /// Populate All reference data
        /// </summary>
        /// <param name="model">Model to populate</param>
        /// <returns>Populated model</returns>
        private async Task<CetOptionModel> PopulateReferences(CetOptionModel model) => (await PopulateReferences(new[] { model })).FirstOrDefault();

        /// <summary>
        /// Bind all references to their parents
        /// </summary>
        /// <param name="options">Option models to bind to</param>
        /// <param name="descriptions">Option reference that needs parent</param>
        /// <param name="materials">Material application reference that needs parent</param>
        /// <returns>Bound Options</returns>
        private static IEnumerable<CetOptionModel> JoinReferences(IEnumerable<CetOptionModel> options,
            IEnumerable<CetOptionDescriptionReferenceModel> descriptions,
            IEnumerable<CetOptionMaterialApplicationReferenceModel> materials)
        {
            var optionList = options.ToList();
            var descriptionList = descriptions.ToList();
            var materialList = materials.ToList();
            var found = new List<CetOptionModel>();

            foreach (var option in optionList)
            {
                var description = descriptionList.FirstOrDefault(des => des.OwnerKey == option.Id);
                var material = materialList.FirstOrDefault(mat => mat.OwnerKey == option.Id);

                option.DescriptionReference = description;
                option.MaterialApplicationReference = material;

                found.Add(option);
            }

            return found;
        }

        /// <summary>
        /// Build Model from references
        /// </summary>
        /// <param name="option">Parent Option</param>
        /// <param name="description">Option description reference that belongs to option</param>
        /// <param name="material">Option Material application reference than belongs to option</param>
        /// <returns>Newly bound option</returns>
        private static CetOptionModel BuildModel(CetOptionModel option, CetOptionDescriptionReferenceModel description,
            CetOptionMaterialApplicationReferenceModel material)
        {
            option.DescriptionReference = description;
            option.MaterialApplicationReference = material;
            return option;
        }

        #region Create

        public override Task<int> CreateModelAsync(CetOptionModel model)
        {
            throw new NotImplementedException();
        }

        public override Task<int> CreateModelAsync(IEnumerable<CetOptionModel> models)
        {
            throw new NotImplementedException();
        }

        #endregion Create

        #region Read

        public override async Task<CetOptionModel> ReadModelByIdAsync(int id)
        {
            var option = await _optionTable.FindByIdAsync(id);
            return await PopulateReferences(option);
        }

        public override async Task<IEnumerable<CetOptionModel>> ReadAllAsync()
        {
            var options = await _optionTable.GetAllAsync();
            return await PopulateReferences(options);
        }

        #endregion Read

        #region Update

        public override Task<int> UpdateModelAsync(CetOptionModel model)
        {
            throw new NotImplementedException();
        }

        public override Task<int> UpdateModelAsync(IEnumerable<CetOptionModel> models)
        {
            throw new NotImplementedException();
        }

        #endregion Update

        #region Delete

        public override Task<int> DeleteModelAsync(CetOptionModel model)
        {
            throw new NotImplementedException();
        }

        public override Task<int> DeleteModelAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<int> DeleteModelsAsync(IEnumerable<CetOptionModel> models)
        {
            throw new NotImplementedException();
        }

        public override Task<int> DeleteModelsAsync(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        #endregion Delete
    }
}
