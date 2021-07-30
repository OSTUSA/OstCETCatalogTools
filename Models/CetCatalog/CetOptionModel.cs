namespace OstToolsModels.CetCatalog
{
    public class CetOptionModel
    {
        #region Fields

        public int Id { get; set; }
        public string Code { get; set; }
        public string VariantsTableReference { get; set; }
        public string Enterprise { get; set; }
        public string Vendor { get; set; }
        public string Prices { get; set; }
        public int OmitOnOrder { get; set; }
        public int OmitPartNumberOnStyleNr { get; set; }
        public string MirrorProductReference { get; set; }
        public float MirrorAngleOfSymmetry { get; set; }
        public int PackageCount { get; set; }
        public string CodeRange { get; set; }
        public float CodeRangeStep { get; set; }
        public string Range { get; set; }
        public int SkuSelection { get; set; }
        public int UndefinedSelection { get; set; }
        public string CustomOptionReference { get; set; }
        public string Delimiter { get; set; }
        public int NumericSku { get; set; }
        public string MirrorOptionReference { get; set; }

        #endregion

        #region References

        /// <summary>
        /// Description Reference
        /// </summary>
        public CetOptionDescriptionReferenceModel DescriptionReference { get; set; }

        /// <summary>
        /// Material Application Reference
        /// </summary>
        public CetOptionMaterialApplicationReferenceModel MaterialApplicationReference { get; set; }

        #endregion
    }
}
