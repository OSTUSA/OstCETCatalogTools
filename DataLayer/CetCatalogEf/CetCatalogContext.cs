using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace OstToolsDataLayer.CetCatalogEf
{
    public partial class CetCatalogContext : DbContext
    {
        public CetCatalogContext()
        {
        }

        public CetCatalogContext(DbContextOptions<CetCatalogContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApplicationAreaType> ApplicationAreaTypes { get; set; }
        public virtual DbSet<ApplicationAreaTypeSurfaceIdsRef> ApplicationAreaTypeSurfaceIdsRefs { get; set; }
        public virtual DbSet<DataCatalog> DataCatalog { get; set; }
        public virtual DbSet<DataCatalogs> DataCatalogs { get; set; }
        public virtual DbSet<DataCatalogApplicationAreasRef> DataCatalogApplicationAreasRefs { get; set; }
        public virtual DbSet<DataCatalogCatalogsRef> DataCatalogCatalogsRefs { get; set; }
        public virtual DbSet<DataCatalogClassificationsRef> DataCatalogClassificationsRefs { get; set; }
        public virtual DbSet<DataCatalogCustomOptionsRef> DataCatalogCustomOptionsRefs { get; set; }
        public virtual DbSet<DataCatalogFeaturesRef> DataCatalogFeaturesRefs { get; set; }
        public virtual DbSet<DataCatalogLeadTimeProgramsRef> DataCatalogLeadTimeProgramsRefs { get; set; }
        public virtual DbSet<DataCatalogMaterialsRef> DataCatalogMaterialsRefs { get; set; }
        public virtual DbSet<DataCatalogPricelistsRef> DataCatalogPricelistsRefs { get; set; }
        public virtual DbSet<DataCatalogProductsRef> DataCatalogProductsRefs { get; set; }
        public virtual DbSet<DataCatalogVendorsRef> DataCatalogVendorsRefs { get; set; }
        public virtual DbSet<DataCatalogscatalogsRef> DataCatalogscatalogsRefs { get; set; }
        public virtual DbSet<DsClassificationRefType> DsClassificationRefTypes { get; set; }
        public virtual DbSet<DsClassificationRefTypeSubRefsRef> DsClassificationRefTypeSubRefsRefs { get; set; }
        public virtual DbSet<DsClassificationType> DsClassificationTypes { get; set; }
        public virtual DbSet<DsClassificationTypeClassificationsRef> DsClassificationTypeClassificationsRefs { get; set; }
        public virtual DbSet<DsClassificationTypeDescriptionsRef> DsClassificationTypeDescriptionsRefs { get; set; }
        public virtual DbSet<DsCustomInquiryType> DsCustomInquiryTypes { get; set; }
        public virtual DbSet<DsCustomInquiryTypeDescriptionsRef> DsCustomInquiryTypeDescriptionsRefs { get; set; }
        public virtual DbSet<DsCustomOptionType> DsCustomOptionTypes { get; set; }
        public virtual DbSet<DsCustomOptionTypeInquiriesRef> DsCustomOptionTypeInquiriesRefs { get; set; }
        public virtual DbSet<DsProductRefType> DsProductRefTypes { get; set; }
        public virtual DbSet<DsProductRefTypeDescriptionsRef> DsProductRefTypeDescriptionsRefs { get; set; }
        public virtual DbSet<DsProductType> DsProductTypes { get; set; }
        public virtual DbSet<DsProductTypeAliasesRef> DsProductTypeAliasesRefs { get; set; }
        public virtual DbSet<DsProductTypeClassificationRefsRef> DsProductTypeClassificationRefsRefs { get; set; }
        public virtual DbSet<DsProductTypeDescriptionsRef> DsProductTypeDescriptionsRefs { get; set; }
        public virtual DbSet<DsProductTypeExternalRef> DsProductTypeExternalRefs { get; set; }
        public virtual DbSet<DsProductTypeFeatureRefsRef> DsProductTypeFeatureRefsRefs { get; set; }
        public virtual DbSet<DsProductTypeMeasurementsRef> DsProductTypeMeasurementsRefs { get; set; }
        public virtual DbSet<DsProductTypeMtrlApplicationsRef> DsProductTypeMtrlApplicationsRefs { get; set; }
        public virtual DbSet<DsProductTypeWireRefsRef> DsProductTypeWireRefsRefs { get; set; }
        public virtual DbSet<DsTableHeadType> DsTableHeadTypes { get; set; }
        public virtual DbSet<DsTableHeadTypeNamesRef> DsTableHeadTypeNamesRefs { get; set; }
        public virtual DbSet<DsTableType> DsTableTypes { get; set; }
        public virtual DbSet<DsTableTypeHeadsRef> DsTableTypeHeadsRefs { get; set; }
        public virtual DbSet<DsVendorType> DsVendorTypes { get; set; }
        public virtual DbSet<DsVendorTypeDescriptionsRef> DsVendorTypeDescriptionsRefs { get; set; }
        public virtual DbSet<DsVendorTypeNamesRef> DsVendorTypeNamesRefs { get; set; }
        public virtual DbSet<DsVendorTypeTablesRef> DsVendorTypeTablesRefs { get; set; }
        public virtual DbSet<DsVersionPolicy> DsVersionPolicies { get; set; }
        public virtual DbSet<DsiFeatureRefType> DsiFeatureRefTypes { get; set; }
        public virtual DbSet<DsiOptionRangeType> DsiOptionRangeTypes { get; set; }
        public virtual DbSet<ExternalRefType> ExternalRefTypes { get; set; }
        public virtual DbSet<MeasurementType> MeasurementTypes { get; set; }
        public virtual DbSet<MtrlApplication> MtrlApplications { get; set; }
        public virtual DbSet<MtrlApplicationareaRefRef> MtrlApplicationareaRefRefs { get; set; }
        public virtual DbSet<OfdaheaderDataDescriptionsRef> OfdaheaderDataDescriptionsRefs { get; set; }
        public virtual DbSet<OfdaheaderDataNamesRef> OfdaheaderDataNamesRefs { get; set; }
        public virtual DbSet<OfdaheaderDatum> OfdaheaderData { get; set; }
        public virtual DbSet<Option> Options { get; set; }
        public virtual DbSet<OptionAddProductRefsRef> OptionAddProductRefsRefs { get; set; }
        public virtual DbSet<OptionAliasesRef> OptionAliasesRefs { get; set; }
        public virtual DbSet<OptionDescriptionsRef> OptionDescriptionsRefs { get; set; }
        public virtual DbSet<OptionExternalRef> OptionExternalRefs { get; set; }
        public virtual DbSet<OptionFeatureRefsRef> OptionFeatureRefsRefs { get; set; }
        public virtual DbSet<OptionMtrlApplicationsRef> OptionMtrlApplicationsRefs { get; set; }
        public virtual DbSet<OptionPriceType> OptionPriceTypes { get; set; }
        public virtual DbSet<PackageVersion> PackageVersions { get; set; }
        public virtual DbSet<PlacementType> PlacementTypes { get; set; }
        public virtual DbSet<PrdExternalRefType> PrdExternalRefTypes { get; set; }
        public virtual DbSet<PriceType> PriceTypes { get; set; }
        public virtual DbSet<PriceTypeSeq> PriceTypeSeqs { get; set; }
        public virtual DbSet<PriceTypeSeqPriceTypesRef> PriceTypeSeqPriceTypesRefs { get; set; }
        public virtual DbSet<PricelistType> PricelistTypes { get; set; }
        public virtual DbSet<PricelistTypeDescriptionsRef> PricelistTypeDescriptionsRefs { get; set; }
        public virtual DbSet<ProductCatalog> ProductCatalogs { get; set; }
        public virtual DbSet<ProductCatalogDescriptionsRef> ProductCatalogDescriptionsRefs { get; set; }
        public virtual DbSet<ProductCatalogEnterpriseRefRef> ProductCatalogEnterpriseRefRefs { get; set; }
        public virtual DbSet<ProductCatalogNamesRef> ProductCatalogNamesRefs { get; set; }
        public virtual DbSet<ProductCatalogPriceListRefRef> ProductCatalogPriceListRefRefs { get; set; }
        public virtual DbSet<ProductCatalogTableOfContentsRef> ProductCatalogTableOfContentsRefs { get; set; }
        public virtual DbSet<ProductCatalogToolboxesRef> ProductCatalogToolboxesRefs { get; set; }
        public virtual DbSet<ProductLevel> ProductLevels { get; set; }
        public virtual DbSet<ProductLevelDescriptionsRef> ProductLevelDescriptionsRefs { get; set; }
        public virtual DbSet<ProductLevelExternalRef> ProductLevelExternalRefs { get; set; }
        public virtual DbSet<ProductLevelsubLvlsRef> ProductLevelsubLvlsRefs { get; set; }
        public virtual DbSet<Sfeature> Sfeatures { get; set; }
        public virtual DbSet<SfeatureAliasesRef> SfeatureAliasesRefs { get; set; }
        public virtual DbSet<SfeatureDescriptionsRef> SfeatureDescriptionsRefs { get; set; }
        public virtual DbSet<SfeatureExternalRef> SfeatureExternalRefs { get; set; }
        public virtual DbSet<SfeatureMtrlApplicationsRef> SfeatureMtrlApplicationsRefs { get; set; }
        public virtual DbSet<SfeatureOptionIndexRef> SfeatureOptionIndexRefs { get; set; }
        public virtual DbSet<SfeatureOptionInfoRef> SfeatureOptionInfoRefs { get; set; }
        public virtual DbSet<Smaterial> Smaterials { get; set; }
        public virtual DbSet<SmaterialDescriptionsRef> SmaterialDescriptionsRefs { get; set; }
        public virtual DbSet<SmaterialExternalRef> SmaterialExternalRefs { get; set; }
        public virtual DbSet<SmaterialPatternRepeatRef> SmaterialPatternRepeatRefs { get; set; }
        public virtual DbSet<UsageType> UsageTypes { get; set; }
        public virtual DbSet<VersionType> VersionTypes { get; set; }
        public virtual DbSet<DataCatalogConnectorsRef> DataCatalogConnectorsRefs { get; set; }
        public virtual DbSet<DataCatalogThumbPathsRef> DataCatalogThumbPathsRefs { get; set; }
        public virtual DbSet<DsExternalRefKeyType> DsExternalRefKeyTypes { get; set; }
        public virtual DbSet<DsProductTypeAddProductRefsRef> DsProductTypeAddProductRefsRefs { get; set; }
        public virtual DbSet<DsProductTypeConnectorsRef> DsProductTypeConnectorsRefs { get; set; }
        public virtual DbSet<DsProductTypeRuleRefsRef> DsProductTypeRuleRefsRefs { get; set; }
        public virtual DbSet<DsTableRowType> DsTableRowTypes { get; set; }
        public virtual DbSet<DsTableRowTypeCellsRef> DsTableRowTypeCellsRefs { get; set; }
        public virtual DbSet<DsTableTypeRowsRef> DsTableTypeRowsRefs { get; set; }
        public virtual DbSet<OptionConnectorsRef> OptionConnectorsRefs { get; set; }
        public virtual DbSet<OptionExternalRefKeysRef> OptionExternalRefKeysRefs { get; set; }
        public virtual DbSet<PrdExternalRefTypeExternalRefKeysRef> PrdExternalRefTypeExternalRefKeysRefs { get; set; }
        public virtual DbSet<PrdExternalRefTypeNamedPointsRef> PrdExternalRefTypeNamedPointsRefs { get; set; }
        public virtual DbSet<SfeatureConnectorsRef> SfeatureConnectorsRefs { get; set; }
        public virtual DbSet<SfeatureFeatureRefsRef> SfeatureFeatureRefsRefs { get; set; }
        public virtual DbSet<Url> Urls { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationAreaType>(entity =>
            {
                entity.ToTable("ApplicationAreaType");

                entity.HasIndex(e => e.Code, "ApplicationAreaTypecode");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.MtrlRef).HasColumnName("_mtrlRef");

                entity.Property(e => e.SurfaceId).HasColumnName("_surfaceId");
            });

            modelBuilder.Entity<ApplicationAreaTypeSurfaceIdsRef>(entity =>
            {
                entity.ToTable("ApplicationAreaType_surfaceIdsREF");

                entity.HasIndex(e => e.OwnerKey, "ApplicationAreaType_surfaceIdsREFownerKey");

                entity.HasIndex(e => e.ValueKey, "ApplicationAreaType_surfaceIdsREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<ApplicationAreaTypeSurfaceIdsRef>()
                .HasOne(a => a.Parent)
                .WithMany(aa => aa.ApplicationSurfaceReference)
                .HasForeignKey(a => a.OwnerKey);

            modelBuilder.Entity<DataCatalog>(entity =>
            {
                entity.ToTable("DataCatalog");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.AnonymousDir).HasColumnName("_anonymousDir");

                entity.Property(e => e.DevCid).HasColumnName("devCid");

                entity.Property(e => e.Enterprise).HasColumnName("_enterprise");

                entity.Property(e => e.ExtensionPolicy).HasColumnName("_extensionPolicy");

                entity.Property(e => e.PackagePolicy).HasColumnName("_packagePolicy");

                entity.Property(e => e.SymbolsDir).HasColumnName("_symbolsDir");

                entity.Property(e => e.TexturesDir).HasColumnName("_texturesDir");

                entity.Property(e => e.ThumbsDir).HasColumnName("_thumbsDir");

                entity.Property(e => e.ToolboxDir).HasColumnName("_toolboxDir");
            });


            modelBuilder.Entity<DataCatalogs>(entity =>
            {
                entity.ToTable("DataCatalogs");

                entity.HasIndex(e => e.Code, "DataCatalogscode");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.DbVersion).HasColumnName("dbVersion");
            });

            modelBuilder.Entity<DataCatalogApplicationAreasRef>(entity =>
            {
                entity.ToTable("DataCatalog_applicationAreasREF");

                entity.HasIndex(e => e.LookupKey, "DataCatalog_applicationAreasREFlookupKey");

                entity.HasIndex(e => e.OwnerKey, "DataCatalog_applicationAreasREFownerKey");

                entity.HasIndex(e => e.ValueKey, "DataCatalog_applicationAreasREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.LookupKey).HasColumnName("lookupKey");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<DataCatalogApplicationAreasRef>()
                .HasOne(a => a.Owner)
                .WithMany(cat => cat.ApplicationAreasRefs)
                .HasForeignKey(a => a.OwnerKey);

            modelBuilder.Entity<DataCatalogApplicationAreasRef>()
                .HasOne(a => a.Child)
                .WithOne(aa => aa.DataCatalogApplicationAreasRef)
                .HasForeignKey<DataCatalogApplicationAreasRef>(a => a.ValueKey);



            modelBuilder.Entity<DataCatalogCatalogsRef>(entity =>
            {
                entity.ToTable("DataCatalog_catalogsREF");

                entity.HasIndex(e => e.LookupKey, "DataCatalog_catalogsREFlookupKey");

                entity.HasIndex(e => e.OwnerKey, "DataCatalog_catalogsREFownerKey");

                entity.HasIndex(e => e.ValueKey, "DataCatalog_catalogsREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.LookupKey).HasColumnName("lookupKey");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<DataCatalogCatalogsRef>()
                .HasOne(dcc => dcc.Owner)
                .WithMany(dc => dc.CatalogsRefs)
                .HasForeignKey(dcc => dcc.OwnerKey);

            modelBuilder.Entity<DataCatalogCatalogsRef>()
                .HasOne(dcc => dcc.Child)
                .WithOne(pc => pc.CatalogCatalogsRef)
                .HasForeignKey<DataCatalogCatalogsRef>(dcc => dcc.ValueKey);

            modelBuilder.Entity<DataCatalogClassificationsRef>(entity =>
            {
                entity.ToTable("DataCatalog_classificationsREF");

                entity.HasIndex(e => e.LookupKey, "DataCatalog_classificationsREFlookupKey");

                entity.HasIndex(e => e.OwnerKey, "DataCatalog_classificationsREFownerKey");

                entity.HasIndex(e => e.ValueKey, "DataCatalog_classificationsREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.LookupKey).HasColumnName("lookupKey");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<DataCatalogClassificationsRef>()
                .HasOne(dccr => dccr.Owner)
                .WithMany(dc => dc.ClassificationsRefs)
                .HasForeignKey(dccr => dccr.OwnerKey);

            modelBuilder.Entity<DataCatalogClassificationsRef>()
                .HasOne(dccr => dccr.Child)
                .WithOne(dct => dct.DataCatalogClassificationsRef)
                .HasForeignKey<DataCatalogClassificationsRef>(dccr => dccr.ValueKey);

            modelBuilder.Entity<DataCatalogCustomOptionsRef>(entity =>
            {
                entity.ToTable("DataCatalog_customOptionsREF");

                entity.HasIndex(e => e.LookupKey, "DataCatalog_customOptionsREFlookupKey");

                entity.HasIndex(e => e.OwnerKey, "DataCatalog_customOptionsREFownerKey");

                entity.HasIndex(e => e.ValueKey, "DataCatalog_customOptionsREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.LookupKey).HasColumnName("lookupKey");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<DataCatalogCustomOptionsRef>()
                .HasOne(dcco => dcco.Owner)
                .WithMany(dc => dc.CustomOptionsRefs)
                .HasForeignKey(dcco => dcco.OwnerKey);

            modelBuilder.Entity<DataCatalogCustomOptionsRef>()
                .HasOne(dcco => dcco.Child)
                .WithMany(dco => dco.DataCatalogCustomOptionsRefs)
                .HasForeignKey(dcco => dcco.ValueKey);

            modelBuilder.Entity<DataCatalogFeaturesRef>(entity =>
            {
                entity.ToTable("DataCatalog_featuresREF");

                entity.HasIndex(e => e.LookupKey, "DataCatalog_featuresREFlookupKey");

                entity.HasIndex(e => e.OwnerKey, "DataCatalog_featuresREFownerKey");

                entity.HasIndex(e => e.ValueKey, "DataCatalog_featuresREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.LookupKey).HasColumnName("lookupKey");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<DataCatalogFeaturesRef>()
                .HasOne(dcf => dcf.Owner)
                .WithMany(dc => dc.FeaturesRefs)
                .HasForeignKey(dcf => dcf.OwnerKey);

            modelBuilder.Entity<DataCatalogFeaturesRef>()
                .HasOne(dcf => dcf.Child)
                .WithMany(sf => sf.CatalogFeatureRefs)
                .HasForeignKey(dcf => dcf.ValueKey);

            modelBuilder.Entity<DataCatalogLeadTimeProgramsRef>(entity =>
            {
                entity.ToTable("DataCatalog_leadTimeProgramsREF");

                entity.HasIndex(e => e.LookupKey, "DataCatalog_leadTimeProgramsREFlookupKey");

                entity.HasIndex(e => e.OwnerKey, "DataCatalog_leadTimeProgramsREFownerKey");

                entity.HasIndex(e => e.ValueKey, "DataCatalog_leadTimeProgramsREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.LookupKey).HasColumnName("lookupKey");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<DataCatalogMaterialsRef>(entity =>
            {
                entity.ToTable("DataCatalog_materialsREF");

                entity.HasIndex(e => e.LookupKey, "DataCatalog_materialsREFlookupKey");

                entity.HasIndex(e => e.OwnerKey, "DataCatalog_materialsREFownerKey");

                entity.HasIndex(e => e.ValueKey, "DataCatalog_materialsREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.LookupKey).HasColumnName("lookupKey");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<DataCatalogMaterialsRef>()
                .HasOne(dcm => dcm.Owner)
                .WithMany(dc => dc.MaterialsRefs)
                .HasForeignKey(dcm => dcm.OwnerKey);

            modelBuilder.Entity<DataCatalogMaterialsRef>()
                .HasOne(dcm => dcm.Child)
                .WithMany(mat => mat.CatalogMaterialsRefs)
                .HasForeignKey(dcm => dcm.ValueKey);

            modelBuilder.Entity<DataCatalogPricelistsRef>(entity =>
            {
                entity.ToTable("DataCatalog_pricelistsREF");

                entity.HasIndex(e => e.LookupKey, "DataCatalog_pricelistsREFlookupKey");

                entity.HasIndex(e => e.OwnerKey, "DataCatalog_pricelistsREFownerKey");

                entity.HasIndex(e => e.ValueKey, "DataCatalog_pricelistsREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.LookupKey).HasColumnName("lookupKey");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<DataCatalogPricelistsRef>()
                .HasOne(dcp => dcp.Owner)
                .WithMany(dc => dc.PricelistsRefs)
                .HasForeignKey(dcp => dcp.OwnerKey);

            modelBuilder.Entity<DataCatalogPricelistsRef>()
                .HasOne(dcp => dcp.Child)
                .WithMany(pl => pl.DataCatalogPricelistRef)
                .HasForeignKey(dcp => dcp.ValueKey);

            modelBuilder.Entity<DataCatalogProductsRef>(entity =>
            {
                entity.ToTable("DataCatalog_productsREF");

                entity.HasIndex(e => e.LookupKey, "DataCatalog_productsREFlookupKey");

                entity.HasIndex(e => e.OwnerKey, "DataCatalog_productsREFownerKey");

                entity.HasIndex(e => e.ValueKey, "DataCatalog_productsREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.LookupKey).HasColumnName("lookupKey");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<DataCatalogProductsRef>()
                .HasOne(dcp => dcp.Owner)
                .WithMany(dc => dc.ProductsRefs)
                .HasForeignKey(dcp => dcp.OwnerKey);

            modelBuilder.Entity<DataCatalogProductsRef>()
                .HasOne(dcp => dcp.Child)
                .WithMany(p => p.CatalogProductsRefs)
                .HasForeignKey(dcp => dcp.ValueKey);

            modelBuilder.Entity<DataCatalogVendorsRef>(entity =>
            {
                entity.ToTable("DataCatalog_vendorsREF");

                entity.HasIndex(e => e.LookupKey, "DataCatalog_vendorsREFlookupKey");

                entity.HasIndex(e => e.OwnerKey, "DataCatalog_vendorsREFownerKey");

                entity.HasIndex(e => e.ValueKey, "DataCatalog_vendorsREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.LookupKey).HasColumnName("lookupKey");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<DataCatalogVendorsRef>()
                .HasOne(dcv => dcv.Owner)
                .WithMany(dc => dc.VendorsRefs)
                .HasForeignKey(dcv => dcv.OwnerKey);

            modelBuilder.Entity<DataCatalogVendorsRef>()
                .HasOne(dcv => dcv.Child)
                .WithMany(dvt => dvt.CatalogVendorsRefs)
                .HasForeignKey(dcv => dcv.ValueKey);

            modelBuilder.Entity<DataCatalogscatalogsRef>(entity =>
            {
                entity.ToTable("DataCatalogscatalogsREF");

                entity.HasIndex(e => e.OwnerKey, "DataCatalogscatalogsREFownerKey");

                entity.HasIndex(e => e.ValueKey, "DataCatalogscatalogsREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<DataCatalogscatalogsRef>()
                .HasOne(dcc => dcc.Owner)
                .WithMany(dcs => dcs.CatalogsRefs)
                .HasForeignKey(dcc => dcc.OwnerKey);

            modelBuilder.Entity<DataCatalogscatalogsRef>()
                .HasOne(dcc => dcc.Child)
                .WithMany(dc => dc.DataCatalogsRef)
                .HasForeignKey(dcc => dcc.ValueKey);

            modelBuilder.Entity<DsClassificationRefType>(entity =>
            {
                entity.ToTable("DsClassificationRefType");

                entity.HasIndex(e => e.Code, "DsClassificationRefTypecode");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Code).HasColumnName("code");
            });

            modelBuilder.Entity<DsClassificationRefTypeSubRefsRef>(entity =>
            {
                entity.ToTable("DsClassificationRefType_subRefsREF");

                entity.HasIndex(e => e.OwnerKey, "DsClassificationRefType_subRefsREFownerKey");

                entity.HasIndex(e => e.ValueKey, "DsClassificationRefType_subRefsREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<DsClassificationRefTypeSubRefsRef>()
                .HasOne(dsr => dsr.Owner)
                .WithMany(dct => dct.SubRefsRefs)
                .HasForeignKey(dsr => dsr.OwnerKey);

            modelBuilder.Entity<DsClassificationRefTypeSubRefsRef>()
                .HasOne(dsr => dsr.Child)
                .WithMany(rt => rt.ClassificationRefTypeSubRefsRefs)
                .HasForeignKey(dsr => dsr.ValueKey);

            modelBuilder.Entity<DsClassificationType>(entity =>
            {
                entity.ToTable("DsClassificationType");

                entity.HasIndex(e => e.Code, "DsClassificationTypecode");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.OtherUsage).HasColumnName("_otherUsage");

                entity.Property(e => e.Usage).HasColumnName("_usage");
            });

            modelBuilder.Entity<DsClassificationTypeClassificationsRef>(entity =>
            {
                entity.ToTable("DsClassificationType_classificationsREF");

                entity.HasIndex(e => e.OwnerKey, "DsClassificationType_classificationsREFownerKey");

                entity.HasIndex(e => e.ValueKey, "DsClassificationType_classificationsREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<DsClassificationTypeClassificationsRef>()
                .HasOne(r => r.Owner)
                .WithMany(o => o.OwnerOfReferences)
                .HasForeignKey(r => r.OwnerKey);

            modelBuilder.Entity<DsClassificationTypeClassificationsRef>()
                .HasOne(r => r.Child)
                .WithMany(o => o.OwnedByReferences)
                .HasForeignKey(r => r.ValueKey);

            modelBuilder.Entity<DsClassificationTypeDescriptionsRef>(entity =>
            {
                entity.ToTable("DsClassificationType_descriptionsREF");

                entity.HasIndex(e => e.LookupKey, "DsClassificationType_descriptionsREFlookupKey");

                entity.HasIndex(e => e.OwnerKey, "DsClassificationType_descriptionsREFownerKey");

                entity.HasIndex(e => e.ValueKey, "DsClassificationType_descriptionsREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.LookupKey).HasColumnName("lookupKey");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<DsCustomInquiryType>(entity =>
            {
                entity.ToTable("DsCustomInquiryType");

                entity.HasIndex(e => e.Code, "DsCustomInquiryTypecode");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.CodeIncr).HasColumnName("_codeIncr");

                entity.Property(e => e.CodeMax).HasColumnName("_codeMax");

                entity.Property(e => e.CodeMin).HasColumnName("_codeMin");

                entity.Property(e => e.Expression).HasColumnName("_expression");

                entity.Property(e => e.OtherOrderMapping).HasColumnName("_otherOrderMapping");
            });

            modelBuilder.Entity<DsCustomInquiryTypeDescriptionsRef>(entity =>
            {
                entity.ToTable("DsCustomInquiryType_descriptionsREF");

                entity.HasIndex(e => e.LookupKey, "DsCustomInquiryType_descriptionsREFlookupKey");

                entity.HasIndex(e => e.OwnerKey, "DsCustomInquiryType_descriptionsREFownerKey");

                entity.HasIndex(e => e.ValueKey, "DsCustomInquiryType_descriptionsREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.LookupKey).HasColumnName("lookupKey");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<DsCustomInquiryTypeDescriptionsRef>()
                .HasOne(r => r.Owner)
                .WithMany(i => i.DescriptionsRefs)
                .HasForeignKey(r => r.OwnerKey);

            modelBuilder.Entity<DsCustomOptionType>(entity =>
            {
                entity.ToTable("DsCustomOptionType");

                entity.HasIndex(e => e.Code, "DsCustomOptionTypecode");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.Vendor).HasColumnName("vendor");
            });

            modelBuilder.Entity<DsCustomOptionTypeInquiriesRef>(entity =>
            {
                entity.ToTable("DsCustomOptionType_inquiriesREF");

                entity.HasIndex(e => e.OwnerKey, "DsCustomOptionType_inquiriesREFownerKey");

                entity.HasIndex(e => e.ValueKey, "DsCustomOptionType_inquiriesREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<DsCustomOptionTypeInquiriesRef>()
                .HasOne(r => r.Owner)
                .WithMany(o => o.InquiriesRefs)
                .HasForeignKey(r => r.OwnerKey);

            modelBuilder.Entity<DsCustomOptionTypeInquiriesRef>()
                .HasOne(r => r.Child)
                .WithMany(c => c.CustomOptionTypeInquiriesRefs)
                .HasForeignKey(r => r.ValueKey);

            modelBuilder.Entity<DsProductRefType>(entity =>
            {
                entity.ToTable("DsProductRefType");

                entity.HasIndex(e => e.Code, "DsProductRefTypecode");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.Enterprise).HasColumnName("_enterprise");

                entity.Property(e => e.PrdCatKey).HasColumnName("_prdCatKey");

                entity.Property(e => e.PriceFactor).HasColumnName("priceFactor");

                entity.Property(e => e.PriceRoundingRule).HasColumnName("priceRoundingRule");

                entity.Property(e => e.UiLvl).HasColumnName("uiLvl");

                entity.Property(e => e.VariantsTableRef).HasColumnName("_variantsTableRef");

                entity.Property(e => e.Vendor).HasColumnName("_vendor");
            });

            modelBuilder.Entity<DsProductRefTypeDescriptionsRef>(entity =>
            {
                entity.ToTable("DsProductRefType_descriptionsREF");

                entity.HasIndex(e => e.LookupKey, "DsProductRefType_descriptionsREFlookupKey");

                entity.HasIndex(e => e.OwnerKey, "DsProductRefType_descriptionsREFownerKey");

                entity.HasIndex(e => e.ValueKey, "DsProductRefType_descriptionsREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.LookupKey).HasColumnName("lookupKey");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<DsProductRefTypeDescriptionsRef>()
                .HasOne(r => r.Owner)
                .WithMany(o => o.DescriptionsRefs)
                .HasForeignKey(r => r.OwnerKey);

            modelBuilder.Entity<DsProductType>(entity =>
            {
                entity.ToTable("DsProductType");

                entity.HasIndex(e => e.Code, "DsProductTypecode");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.Enterprise).HasColumnName("enterprise");

                entity.Property(e => e.MirrAngleOfSymmetry).HasColumnName("_mirrAngleOfSymmetry");

                entity.Property(e => e.MirrPrdRef).HasColumnName("_mirrPrdRef");

                entity.Property(e => e.OmitOnOrder).HasColumnName("_omitOnOrder");

                entity.Property(e => e.OmitPnonStyleNr).HasColumnName("_omitPNOnStyleNr");

                entity.Property(e => e.PackageCount).HasColumnName("_packageCount");

                entity.Property(e => e.Prices).HasColumnName("_prices");

                entity.Property(e => e.VariantsTableRef).HasColumnName("_variantsTableRef");

                entity.Property(e => e.Vendor).HasColumnName("vendor");
            });

            modelBuilder.Entity<DsProductTypeAliasesRef>(entity =>
            {
                entity.ToTable("DsProductType_aliasesREF");

                entity.HasIndex(e => e.OwnerKey, "DsProductType_aliasesREFownerKey");

                entity.HasIndex(e => e.ValueKey, "DsProductType_aliasesREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<DsProductTypeClassificationRefsRef>(entity =>
            {
                entity.ToTable("DsProductType_classificationRefsREF");

                entity.HasIndex(e => e.OwnerKey, "DsProductType_classificationRefsREFownerKey");

                entity.HasIndex(e => e.ValueKey, "DsProductType_classificationRefsREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<DsProductTypeClassificationRefsRef>()
                .HasOne(r => r.Owner)
                .WithMany(o => o.ProductTypeClassificationRefsRefs)
                .HasForeignKey(r => r.OwnerKey);

            modelBuilder.Entity<DsProductTypeClassificationRefsRef>()
                .HasOne(r => r.Child)
                .WithMany(c => c.ProductTypeClassificationRefsRefs)
                .HasForeignKey(r => r.ValueKey);

            modelBuilder.Entity<DsProductTypeDescriptionsRef>(entity =>
            {
                entity.ToTable("DsProductType_descriptionsREF");

                entity.HasIndex(e => e.LookupKey, "DsProductType_descriptionsREFlookupKey");

                entity.HasIndex(e => e.OwnerKey, "DsProductType_descriptionsREFownerKey");

                entity.HasIndex(e => e.ValueKey, "DsProductType_descriptionsREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.LookupKey).HasColumnName("lookupKey");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<DsProductTypeDescriptionsRef>()
                .HasOne(r => r.Owner)
                .WithMany(o => o.ProductTypeDescriptionsRefs)
                .HasForeignKey(r => r.OwnerKey);

            modelBuilder.Entity<DsProductTypeExternalRef>(entity =>
            {
                entity.ToTable("DsProductType_externalREF");

                entity.HasIndex(e => e.OwnerKey, "DsProductType_externalREFownerKey");

                entity.HasIndex(e => e.ValueKey, "DsProductType_externalREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<DsProductTypeExternalRef>()
                .HasOne(r => r.Owner)
                .WithMany(o => o.ProductTypeExternalRefs)
                .HasForeignKey(r => r.OwnerKey);


            modelBuilder.Entity<DsProductTypeExternalRef>()
                .HasOne(r => r.Child)
                .WithMany(c => c.ProductTypeExternalRefs)
                .HasForeignKey(r => r.ValueKey);

            modelBuilder.Entity<DsProductTypeFeatureRefsRef>(entity =>
            {
                entity.ToTable("DsProductType_featureRefsREF");

                entity.HasIndex(e => e.OwnerKey, "DsProductType_featureRefsREFownerKey");

                entity.HasIndex(e => e.ValueKey, "DsProductType_featureRefsREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<DsProductTypeFeatureRefsRef>()
                .HasOne(r => r.Owner)
                .WithMany(o => o.ProductTypeFeatureRefsRefs)
                .HasForeignKey(r => r.OwnerKey);

            modelBuilder.Entity<DsProductTypeFeatureRefsRef>()
                .HasOne(r => r.Child)
                .WithMany(c => c.ProductTypeFeatureRefsRefs)
                .HasForeignKey(r => r.ValueKey);

            modelBuilder.Entity<DsProductTypeMeasurementsRef>(entity =>
            {
                entity.ToTable("DsProductType_measurementsREF");

                entity.HasIndex(e => e.OwnerKey, "DsProductType_measurementsREFownerKey");

                entity.HasIndex(e => e.ValueKey, "DsProductType_measurementsREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<DsProductTypeMeasurementsRef>()
                .HasOne(r => r.Owner)
                .WithMany(o => o.ProductTypeMeasurementsRefs)
                .HasForeignKey(r => r.OwnerKey);

            modelBuilder.Entity<DsProductTypeMeasurementsRef>()
                .HasOne(r => r.Child)
                .WithMany(c => c.ProductTypeMeasurementsRefs)
                .HasForeignKey(r => r.ValueKey);

            modelBuilder.Entity<DsProductTypeMtrlApplicationsRef>(entity =>
            {
                entity.ToTable("DsProductType_mtrlApplicationsREF");

                entity.HasIndex(e => e.OwnerKey, "DsProductType_mtrlApplicationsREFownerKey");

                entity.HasIndex(e => e.ValueKey, "DsProductType_mtrlApplicationsREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<DsProductTypeMtrlApplicationsRef>()
                .HasOne(r => r.Owner)
                .WithMany(o => o.ProductTypeMtrlApplicationsRefs)
                .HasForeignKey(r => r.OwnerKey);

            modelBuilder.Entity<DsProductTypeMtrlApplicationsRef>()
                .HasOne(r => r.Child)
                .WithMany(c => c.ProductTypeMtrlApplicationsRefs)
                .HasForeignKey(r => r.ValueKey);

            modelBuilder.Entity<DsProductTypeWireRefsRef>(entity =>
            {
                entity.ToTable("DsProductType_wireRefsREF");

                entity.HasIndex(e => e.OwnerKey, "DsProductType_wireRefsREFownerKey");

                entity.HasIndex(e => e.ValueKey, "DsProductType_wireRefsREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<DsTableHeadType>(entity =>
            {
                entity.ToTable("DsTableHeadType");

                entity.HasIndex(e => e.Code, "DsTableHeadTypecode");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Code).HasColumnName("code");
            });

            modelBuilder.Entity<DsTableHeadTypeNamesRef>(entity =>
            {
                entity.ToTable("DsTableHeadType_namesREF");

                entity.HasIndex(e => e.OwnerKey, "DsTableHeadType_namesREFownerKey");

                entity.HasIndex(e => e.ValueKey, "DsTableHeadType_namesREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<DsTableHeadTypeNamesRef>()
                .HasOne(r => r.Owner)
                .WithMany(o => o.NamesRefs)
                .HasForeignKey(r => r.OwnerKey);


            modelBuilder.Entity<DsTableType>(entity =>
            {
                entity.ToTable("DsTableType");

                entity.HasIndex(e => e.Code, "DsTableTypecode");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.TableType).HasColumnName("_tableType");
            });

            modelBuilder.Entity<DsTableTypeHeadsRef>(entity =>
            {
                entity.ToTable("DsTableType_headsREF");

                entity.HasIndex(e => e.OwnerKey, "DsTableType_headsREFownerKey");

                entity.HasIndex(e => e.ValueKey, "DsTableType_headsREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<DsTableTypeHeadsRef>()
                .HasOne(r => r.Owner)
                .WithMany(o => o.TableTypeHeadsRefs)
                .HasForeignKey(r => r.OwnerKey);

            modelBuilder.Entity<DsTableTypeHeadsRef>()
                .HasOne(r => r.Child)
                .WithMany(c => c.TableTypeHeadsRefs)
                .HasForeignKey(r => r.ValueKey);

            modelBuilder.Entity<DsVendorType>(entity =>
            {
                entity.ToTable("DsVendorType");

                entity.HasIndex(e => e.Code, "DsVendorTypecode");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.ConstraintType).HasColumnName("_constraintType");

                entity.Property(e => e.ConstraintsApplyStyle).HasColumnName("_constraintsApplyStyle");

                entity.Property(e => e.UnitMeasure).HasColumnName("unitMeasure");
            });

            modelBuilder.Entity<DsVendorTypeDescriptionsRef>(entity =>
            {
                entity.ToTable("DsVendorType_descriptionsREF");

                entity.HasIndex(e => e.LookupKey, "DsVendorType_descriptionsREFlookupKey");

                entity.HasIndex(e => e.OwnerKey, "DsVendorType_descriptionsREFownerKey");

                entity.HasIndex(e => e.ValueKey, "DsVendorType_descriptionsREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.LookupKey).HasColumnName("lookupKey");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<DsVendorTypeNamesRef>(entity =>
            {
                entity.ToTable("DsVendorType_namesREF");

                entity.HasIndex(e => e.LookupKey, "DsVendorType_namesREFlookupKey");

                entity.HasIndex(e => e.OwnerKey, "DsVendorType_namesREFownerKey");

                entity.HasIndex(e => e.ValueKey, "DsVendorType_namesREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.LookupKey).HasColumnName("lookupKey");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<DsVendorTypeTablesRef>(entity =>
            {
                entity.ToTable("DsVendorType_tablesREF");

                entity.HasIndex(e => e.LookupKey, "DsVendorType_tablesREFlookupKey");

                entity.HasIndex(e => e.OwnerKey, "DsVendorType_tablesREFownerKey");

                entity.HasIndex(e => e.ValueKey, "DsVendorType_tablesREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.LookupKey).HasColumnName("lookupKey");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<DsVendorTypeTablesRef>()
                .HasOne(r => r.Owner)
                .WithMany(o => o.VendorTypeTablesRefs)
                .HasForeignKey(r => r.OwnerKey);

            modelBuilder.Entity<DsVendorTypeTablesRef>()
                .HasOne(r => r.Child)
                .WithMany(c => c.VendorTypeTablesRefs)
                .HasForeignKey(r => r.ValueKey);

            modelBuilder.Entity<DsVersionPolicy>(entity =>
            {
                entity.ToTable("DsVersionPolicy");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Purpose).HasColumnName("purpose");
            });

            modelBuilder.Entity<DsiFeatureRefType>(entity =>
            {
                entity.ToTable("DsiFeatureRefType");

                entity.HasIndex(e => e.Code, "DsiFeatureRefTypecode");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.DefaultOptionRef).HasColumnName("_defaultOptionRef");

                entity.Property(e => e.SelectedOptionRef).HasColumnName("_selectedOptionRef");
            });

            modelBuilder.Entity<DsiOptionRangeType>(entity =>
            {
                entity.ToTable("DsiOptionRangeType");

                entity.HasIndex(e => e.Code, "DsiOptionRangeTypecode");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Code).HasColumnName("code");
            });

            modelBuilder.Entity<ExternalRefType>(entity =>
            {
                entity.ToTable("ExternalRefType");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.MeasureParam).HasColumnName("_measureParam");

                entity.Property(e => e.PreviewUrl).HasColumnName("previewUrl");

                entity.Property(e => e.Url).HasColumnName("url");

                entity.Property(e => e.UsageType).HasColumnName("_usageType");
            });

            modelBuilder.Entity<MeasurementType>(entity =>
            {
                entity.ToTable("MeasurementType");

                entity.HasIndex(e => e.Code, "MeasurementTypecode");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.MParam).HasColumnName("_mParam");

                entity.Property(e => e.MeasureParameter).HasColumnName("_measureParameter");

                entity.Property(e => e.System).HasColumnName("system");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.Property(e => e.Unit).HasColumnName("unit");

                entity.Property(e => e.Value).HasColumnName("value");
            });

            modelBuilder.Entity<MtrlApplication>(entity =>
            {
                entity.ToTable("MtrlApplication");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.MtrlRef).HasColumnName("mtrlRef");

                entity.Property(e => e.Placement).HasColumnName("placement");

                entity.Property(e => e.UniqueKey).HasColumnName("_uniqueKey");
            });

            modelBuilder.Entity<MtrlApplicationareaRefRef>(entity =>
            {
                entity.ToTable("MtrlApplicationareaRefREF");

                entity.HasIndex(e => e.OwnerKey, "MtrlApplicationareaRefREFownerKey");

                entity.HasIndex(e => e.ValueKey, "MtrlApplicationareaRefREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<MtrlApplicationareaRefRef>()
                .HasOne(r => r.Owner)
                .WithMany(o => o.MtrlApplicationareaRefs)
                .HasForeignKey(r => r.OwnerKey);

            modelBuilder.Entity<OfdaheaderDataDescriptionsRef>(entity =>
            {
                entity.ToTable("OFDAHeaderData_descriptionsREF");

                entity.HasIndex(e => e.LookupKey, "OFDAHeaderData_descriptionsREFlookupKey");

                entity.HasIndex(e => e.OwnerKey, "OFDAHeaderData_descriptionsREFownerKey");

                entity.HasIndex(e => e.ValueKey, "OFDAHeaderData_descriptionsREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.LookupKey).HasColumnName("lookupKey");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<OfdaheaderDataDescriptionsRef>()
                .HasOne(r => r.Owner)
                .WithMany(o => o.OfdaheaderDataDescriptionsRefs)
                .HasForeignKey(r => r.OwnerKey);

            modelBuilder.Entity<OfdaheaderDataNamesRef>(entity =>
            {
                entity.ToTable("OFDAHeaderData_namesREF");

                entity.HasIndex(e => e.LookupKey, "OFDAHeaderData_namesREFlookupKey");

                entity.HasIndex(e => e.OwnerKey, "OFDAHeaderData_namesREFownerKey");

                entity.HasIndex(e => e.ValueKey, "OFDAHeaderData_namesREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.LookupKey).HasColumnName("lookupKey");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<OfdaheaderDataNamesRef>()
                .HasOne(r => r.Owner)
                .WithMany(o => o.OfdaheaderDataNamesRefs)
                .HasForeignKey(r => r.OwnerKey);

            modelBuilder.Entity<OfdaheaderDatum>(entity =>
            {
                entity.ToTable("OFDAHeaderData");

                entity.HasIndex(e => e.Code, "OFDAHeaderDatacode");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.ConstraintType).HasColumnName("_constraintType");

                entity.Property(e => e.ConstraintsApplyStyle).HasColumnName("_constraintsApplyStyle");

                entity.Property(e => e.UnitMeasure).HasColumnName("unitMeasure");
            });

            modelBuilder.Entity<Option>(entity =>
            {
                entity.ToTable("Option");

                entity.HasIndex(e => e.Code, "Optioncode");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.CodeRange).HasColumnName("_codeRange");

                entity.Property(e => e.CodeRangeStep).HasColumnName("_codeRangeStep");

                entity.Property(e => e.CustomOptionRef).HasColumnName("_customOptionRef");

                entity.Property(e => e.Delimiter).HasColumnName("delimiter");

                entity.Property(e => e.Enterprise).HasColumnName("enterprise");

                entity.Property(e => e.MirrAngleOfSymmetry).HasColumnName("_mirrAngleOfSymmetry");

                entity.Property(e => e.MirrPrdRef).HasColumnName("_mirrPrdRef");

                entity.Property(e => e.MirrorOptionRef).HasColumnName("mirrorOptionRef");

                entity.Property(e => e.NumericSku).HasColumnName("numericSku");

                entity.Property(e => e.OmitOnOrder).HasColumnName("_omitOnOrder");

                entity.Property(e => e.OmitPnonStyleNr).HasColumnName("_omitPNOnStyleNr");

                entity.Property(e => e.PackageCount).HasColumnName("_packageCount");

                entity.Property(e => e.Prices).HasColumnName("_prices");

                entity.Property(e => e.Range).HasColumnName("_range");

                entity.Property(e => e.SkuSelection).HasColumnName("skuSelection");

                entity.Property(e => e.UndefinedSelection).HasColumnName("_undefinedSelection");

                entity.Property(e => e.VariantsTableRef).HasColumnName("_variantsTableRef");

                entity.Property(e => e.Vendor).HasColumnName("vendor");
            });

            modelBuilder.Entity<OptionAddProductRefsRef>(entity =>
            {
                entity.ToTable("Option_addProductRefsREF");

                entity.HasIndex(e => e.OwnerKey, "Option_addProductRefsREFownerKey");

                entity.HasIndex(e => e.ValueKey, "Option_addProductRefsREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<OptionAliasesRef>(entity =>
            {
                entity.ToTable("Option_aliasesREF");

                entity.HasIndex(e => e.OwnerKey, "Option_aliasesREFownerKey");

                entity.HasIndex(e => e.ValueKey, "Option_aliasesREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<OptionDescriptionsRef>(entity =>
            {
                entity.ToTable("Option_descriptionsREF");

                entity.HasIndex(e => e.LookupKey, "Option_descriptionsREFlookupKey");

                entity.HasIndex(e => e.OwnerKey, "Option_descriptionsREFownerKey");

                entity.HasIndex(e => e.ValueKey, "Option_descriptionsREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.LookupKey).HasColumnName("lookupKey");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<OptionDescriptionsRef>()
                .HasOne(r => r.Owner)
                .WithMany(o => o.DescriptionsRefs)
                .HasForeignKey(r => r.OwnerKey);

            modelBuilder.Entity<OptionExternalRef>(entity =>
            {
                entity.ToTable("Option_externalREF");

                entity.HasIndex(e => e.OwnerKey, "Option_externalREFownerKey");

                entity.HasIndex(e => e.ValueKey, "Option_externalREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<OptionFeatureRefsRef>(entity =>
            {
                entity.ToTable("Option_featureRefsREF");

                entity.HasIndex(e => e.OwnerKey, "Option_featureRefsREFownerKey");

                entity.HasIndex(e => e.ValueKey, "Option_featureRefsREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<OptionFeatureRefsRef>()
                .HasOne(r => r.Owner)
                .WithMany(o => o.FeatureRefs)
                .HasForeignKey(r => r.OwnerKey);

            modelBuilder.Entity<OptionFeatureRefsRef>()
                .HasOne(r => r.Child)
                .WithMany(c => c.OptionFeatureRefs)
                .HasForeignKey(r => r.ValueKey);

            modelBuilder.Entity<OptionMtrlApplicationsRef>(entity =>
            {
                entity.ToTable("Option_mtrlApplicationsREF");

                entity.HasIndex(e => e.OwnerKey, "Option_mtrlApplicationsREFownerKey");

                entity.HasIndex(e => e.ValueKey, "Option_mtrlApplicationsREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<OptionMtrlApplicationsRef>()
                .HasOne(r => r.Owner)
                .WithMany(o => o.MtrlApplicationsRefs)
                .HasForeignKey(r => r.OwnerKey);

            modelBuilder.Entity<OptionMtrlApplicationsRef>()
                .HasOne(r => r.Child)
                .WithMany(c => c.OptionMtrlApplicationsRefs)
                .HasForeignKey(r => r.ValueKey);

            modelBuilder.Entity<OptionPriceType>(entity =>
            {
                entity.ToTable("OptionPriceType");

                entity.HasIndex(e => e.Code, "OptionPriceTypecode");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.PricelistRef).HasColumnName("pricelistRef");

                entity.Property(e => e.Value).HasColumnName("value");
            });



            modelBuilder.Entity<PackageVersion>(entity =>
            {
                entity.ToTable("PackageVersion");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");
            });

            modelBuilder.Entity<PlacementType>(entity =>
            {
                entity.ToTable("PlacementType");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Offset).HasColumnName("_offset");

                entity.Property(e => e.Origin).HasColumnName("origin");

                entity.Property(e => e.RotationA).HasColumnName("_rotationA");

                entity.Property(e => e.RotationP).HasColumnName("_rotationP");

                entity.Property(e => e.Scalar).HasColumnName("_scalar");
            });

            modelBuilder.Entity<PrdExternalRefType>(entity =>
            {
                entity.ToTable("PrdExternalRefType");

                entity.HasIndex(e => e.Code, "PrdExternalRefTypecode");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.InsertionId).HasColumnName("insertionId");

                entity.Property(e => e.MeasureParam).HasColumnName("_measureParam");

                entity.Property(e => e.PreviewUrl).HasColumnName("previewUrl");

                entity.Property(e => e.Pt).HasColumnName("_pt");

                entity.Property(e => e.Url).HasColumnName("url");

                entity.Property(e => e.UsageType).HasColumnName("_usageType");
            });

            modelBuilder.Entity<PriceType>(entity =>
            {
                entity.ToTable("PriceType");

                entity.HasIndex(e => e.Code, "PriceTypecode");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.PricelistRef).HasColumnName("pricelistRef");

                entity.Property(e => e.Value).HasColumnName("value");
            });

            modelBuilder.Entity<PriceTypeSeq>(entity =>
            {
                entity.ToTable("PriceTypeSeq");

                entity.HasIndex(e => e.Code, "PriceTypeSeqcode");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Code).HasColumnName("code");
            });

            modelBuilder.Entity<PriceTypeSeqPriceTypesRef>(entity =>
            {
                entity.ToTable("PriceTypeSeq_priceTypesREF");

                entity.HasIndex(e => e.OwnerKey, "PriceTypeSeq_priceTypesREFownerKey");

                entity.HasIndex(e => e.ValueKey, "PriceTypeSeq_priceTypesREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<PriceTypeSeqPriceTypesRef>()
                .HasOne(r => r.Owner)
                .WithMany(o => o.PriceTypeSeqPriceTypesRefs)
                .HasForeignKey(r => r.OwnerKey);

            modelBuilder.Entity<PriceTypeSeqPriceTypesRef>()
                .HasOne(r => r.Child)
                .WithMany(c => c.PriceTypeSeqPriceTypesRefs)
                .HasForeignKey(r => r.ValueKey);

            modelBuilder.Entity<PricelistType>(entity =>
            {
                entity.ToTable("PricelistType");

                entity.HasIndex(e => e.Code, "PricelistTypecode");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.Currency).HasColumnName("currency");

                entity.Property(e => e.CurrencyRate).HasColumnName("currencyRate");

                entity.Property(e => e.CurrencyRoundingRule).HasColumnName("currencyRoundingRule");

                entity.Property(e => e.Effectivedate).HasColumnName("_effectivedate");

                entity.Property(e => e.Expirationdate).HasColumnName("_expirationdate");

                entity.Property(e => e.PriceId).HasColumnName("_priceID");
            });

            modelBuilder.Entity<PricelistTypeDescriptionsRef>(entity =>
            {
                entity.ToTable("PricelistType_descriptionsREF");

                entity.HasIndex(e => e.LookupKey, "PricelistType_descriptionsREFlookupKey");

                entity.HasIndex(e => e.OwnerKey, "PricelistType_descriptionsREFownerKey");

                entity.HasIndex(e => e.ValueKey, "PricelistType_descriptionsREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.LookupKey).HasColumnName("lookupKey");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<PricelistTypeDescriptionsRef>()
                .HasOne(r => r.Owner)
                .WithMany(o => o.PricelistTypeDescriptionsRefs)
                .HasForeignKey(r => r.OwnerKey);

            modelBuilder.Entity<ProductCatalog>(entity =>
            {
                entity.ToTable("ProductCatalog");

                entity.HasIndex(e => e.Code, "ProductCatalogcode");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.LeadTimeProgramRef).HasColumnName("_leadTimeProgramRef");

                entity.Property(e => e.Versions).HasColumnName("_versions");
            });

            modelBuilder.Entity<ProductCatalogDescriptionsRef>(entity =>
            {
                entity.ToTable("ProductCatalog_descriptionsREF");

                entity.HasIndex(e => e.LookupKey, "ProductCatalog_descriptionsREFlookupKey");

                entity.HasIndex(e => e.OwnerKey, "ProductCatalog_descriptionsREFownerKey");

                entity.HasIndex(e => e.ValueKey, "ProductCatalog_descriptionsREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.LookupKey).HasColumnName("lookupKey");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<ProductCatalogDescriptionsRef>()
                .HasOne(r => r.Owner)
                .WithMany(o => o.DescriptionsRefs)
                .HasForeignKey(r => r.OwnerKey);

            modelBuilder.Entity<ProductCatalogEnterpriseRefRef>(entity =>
            {
                entity.ToTable("ProductCatalog_enterpriseRefREF");

                entity.HasIndex(e => e.OwnerKey, "ProductCatalog_enterpriseRefREFownerKey");

                entity.HasIndex(e => e.ValueKey, "ProductCatalog_enterpriseRefREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<ProductCatalogEnterpriseRefRef>()
                .HasOne(r => r.Owner)
                .WithMany(o => o.EnterpriseRefRefs)
                .HasForeignKey(r => r.OwnerKey);

            modelBuilder.Entity<ProductCatalogNamesRef>(entity =>
            {
                entity.ToTable("ProductCatalog_namesREF");

                entity.HasIndex(e => e.LookupKey, "ProductCatalog_namesREFlookupKey");

                entity.HasIndex(e => e.OwnerKey, "ProductCatalog_namesREFownerKey");

                entity.HasIndex(e => e.ValueKey, "ProductCatalog_namesREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.LookupKey).HasColumnName("lookupKey");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<ProductCatalogNamesRef>()
                .HasOne(r => r.Owner)
                .WithMany(o => o.NamesRefs)
                .HasForeignKey(r => r.OwnerKey);

            modelBuilder.Entity<ProductCatalogPriceListRefRef>(entity =>
            {
                entity.ToTable("ProductCatalog_priceListRefREF");

                entity.HasIndex(e => e.LookupKey, "ProductCatalog_priceListRefREFlookupKey");

                entity.HasIndex(e => e.OwnerKey, "ProductCatalog_priceListRefREFownerKey");

                entity.HasIndex(e => e.ValueKey, "ProductCatalog_priceListRefREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.LookupKey).HasColumnName("lookupKey");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<ProductCatalogPriceListRefRef>()
                .HasOne(r => r.Owner)
                .WithMany(o => o.PriceListRefRefs)
                .HasForeignKey(r => r.OwnerKey);

            modelBuilder.Entity<ProductCatalogTableOfContentsRef>(entity =>
            {
                entity.ToTable("ProductCatalog_tableOfContentsREF");

                entity.HasIndex(e => e.OwnerKey, "ProductCatalog_tableOfContentsREFownerKey");

                entity.HasIndex(e => e.ValueKey, "ProductCatalog_tableOfContentsREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<ProductCatalogTableOfContentsRef>()
                .HasOne(r => r.Owner)
                .WithMany(o => o.TableOfContentsRefs)
                .HasForeignKey(r => r.OwnerKey);

            modelBuilder.Entity<ProductCatalogTableOfContentsRef>()
                .HasOne(r => r.Child)
                .WithMany(c => c.TableOfContentsRefs)
                .HasForeignKey(r => r.ValueKey);

            modelBuilder.Entity<ProductCatalogToolboxesRef>(entity =>
            {
                entity.ToTable("ProductCatalog_toolboxesREF");

                entity.HasIndex(e => e.OwnerKey, "ProductCatalog_toolboxesREFownerKey");

                entity.HasIndex(e => e.ValueKey, "ProductCatalog_toolboxesREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<ProductLevel>(entity =>
            {
                entity.ToTable("ProductLevel");

                entity.HasIndex(e => e.Code, "ProductLevelcode");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.PriceFactor).HasColumnName("priceFactor");

                entity.Property(e => e.PriceRoundingRule).HasColumnName("priceRoundingRule");

                entity.Property(e => e.UiLvl).HasColumnName("uiLvl");

                entity.Property(e => e.VariantsTableRef).HasColumnName("_variantsTableRef");
            });

            modelBuilder.Entity<ProductLevelDescriptionsRef>(entity =>
            {
                entity.ToTable("ProductLevel_descriptionsREF");

                entity.HasIndex(e => e.LookupKey, "ProductLevel_descriptionsREFlookupKey");

                entity.HasIndex(e => e.OwnerKey, "ProductLevel_descriptionsREFownerKey");

                entity.HasIndex(e => e.ValueKey, "ProductLevel_descriptionsREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.LookupKey).HasColumnName("lookupKey");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<ProductLevelDescriptionsRef>()
                .HasOne(r => r.Owner)
                .WithMany(o => o.DescriptionsRefs)
                .HasForeignKey(r => r.OwnerKey);

            modelBuilder.Entity<ProductLevelExternalRef>(entity =>
            {
                entity.ToTable("ProductLevel_externalREF");

                entity.HasIndex(e => e.OwnerKey, "ProductLevel_externalREFownerKey");

                entity.HasIndex(e => e.ValueKey, "ProductLevel_externalREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<ProductLevelsubLvlsRef>(entity =>
            {
                entity.ToTable("ProductLevelsubLvlsREF");

                entity.HasIndex(e => e.OwnerKey, "ProductLevelsubLvlsREFownerKey");

                entity.HasIndex(e => e.ValueKey, "ProductLevelsubLvlsREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<Sfeature>(entity =>
            {
                entity.ToTable("SFeature");

                entity.HasIndex(e => e.Code, "SFeaturecode");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.DataType).HasColumnName("_dataType");

                entity.Property(e => e.DecimalPlaces).HasColumnName("_decimalPlaces");

                entity.Property(e => e.DefaultOptionRef).HasColumnName("defaultOptionRef");

                entity.Property(e => e.Delimiter).HasColumnName("delimiter");

                entity.Property(e => e.Enterprise).HasColumnName("enterprise");

                entity.Property(e => e.FunctionalSelection).HasColumnName("functionalSelection");

                entity.Property(e => e.GroupCode).HasColumnName("_groupCode");

                entity.Property(e => e.HasGraphic).HasColumnName("_hasGraphic");

                entity.Property(e => e.HasMtrl).HasColumnName("_hasMtrl");

                entity.Property(e => e.HasRange).HasColumnName("_hasRange");

                entity.Property(e => e.MirrAngleOfSymmetry).HasColumnName("_mirrAngleOfSymmetry");

                entity.Property(e => e.MirrPrdRef).HasColumnName("_mirrPrdRef");

                entity.Property(e => e.MultipleSelection).HasColumnName("multipleSelection");

                entity.Property(e => e.OmitOnOrder).HasColumnName("_omitOnOrder");

                entity.Property(e => e.OmitPnonStyleNr).HasColumnName("_omitPNOnStyleNr");

                entity.Property(e => e.OptionalSelection).HasColumnName("optionalSelection");

                entity.Property(e => e.PackageCount).HasColumnName("_packageCount");

                entity.Property(e => e.Prices).HasColumnName("_prices");

                entity.Property(e => e.SkuSelection).HasColumnName("skuSelection");

                entity.Property(e => e.UnitMeasure).HasColumnName("unitMeasure");

                entity.Property(e => e.VariantsTableRef).HasColumnName("_variantsTableRef");

                entity.Property(e => e.Vendor).HasColumnName("vendor");
            });

            modelBuilder.Entity<SfeatureAliasesRef>(entity =>
            {
                entity.ToTable("SFeature_aliasesREF");

                entity.HasIndex(e => e.OwnerKey, "SFeature_aliasesREFownerKey");

                entity.HasIndex(e => e.ValueKey, "SFeature_aliasesREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<SfeatureDescriptionsRef>(entity =>
            {
                entity.ToTable("SFeature_descriptionsREF");

                entity.HasIndex(e => e.LookupKey, "SFeature_descriptionsREFlookupKey");

                entity.HasIndex(e => e.OwnerKey, "SFeature_descriptionsREFownerKey");

                entity.HasIndex(e => e.ValueKey, "SFeature_descriptionsREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.LookupKey).HasColumnName("lookupKey");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<SfeatureDescriptionsRef>()
                .HasOne(r => r.Owner)
                .WithMany(o => o.DescriptionsRefs)
                .HasForeignKey(r => r.OwnerKey);

            modelBuilder.Entity<SfeatureExternalRef>(entity =>
            {
                entity.ToTable("SFeature_externalREF");

                entity.HasIndex(e => e.OwnerKey, "SFeature_externalREFownerKey");

                entity.HasIndex(e => e.ValueKey, "SFeature_externalREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<SfeatureMtrlApplicationsRef>(entity =>
            {
                entity.ToTable("SFeature_mtrlApplicationsREF");

                entity.HasIndex(e => e.OwnerKey, "SFeature_mtrlApplicationsREFownerKey");

                entity.HasIndex(e => e.ValueKey, "SFeature_mtrlApplicationsREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<SfeatureMtrlApplicationsRef>()
                .HasOne(r => r.Owner)
                .WithMany(o => o.MtrlApplicationsRefs)
                .HasForeignKey(r => r.OwnerKey);

            modelBuilder.Entity<SfeatureMtrlApplicationsRef>()
                .HasOne(r => r.Child)
                .WithMany(c => c.SfeatureMtrlApplicationsRefs)
                .HasForeignKey(r => r.ValueKey);

            modelBuilder.Entity<SfeatureOptionIndexRef>(entity =>
            {
                entity.ToTable("SFeature_optionIndexREF");

                entity.HasIndex(e => e.LookupKey, "SFeature_optionIndexREFlookupKey");

                entity.HasIndex(e => e.OwnerKey, "SFeature_optionIndexREFownerKey");

                entity.HasIndex(e => e.ValueKey, "SFeature_optionIndexREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.LookupKey).HasColumnName("lookupKey");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<SfeatureOptionIndexRef>()
                .HasOne(r => r.Owner)
                .WithMany(o => o.OptionIndexRefs)
                .HasForeignKey(r => r.OwnerKey);

            modelBuilder.Entity<SfeatureOptionInfoRef>(entity =>
            {
                entity.ToTable("SFeature_optionInfoREF");

                entity.HasIndex(e => e.LookupKey, "SFeature_optionInfoREFlookupKey");

                entity.HasIndex(e => e.OwnerKey, "SFeature_optionInfoREFownerKey");

                entity.HasIndex(e => e.ValueKey, "SFeature_optionInfoREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.LookupKey).HasColumnName("lookupKey");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<SfeatureOptionInfoRef>()
                .HasOne(r => r.Owner)
                .WithMany(o => o.OptionInfoRefs)
                .HasForeignKey(r => r.OwnerKey);

            modelBuilder.Entity<SfeatureOptionInfoRef>()
                .HasOne(r => r.Child)
                .WithMany(c => c.SfeatureOptionInfoRefs)
                .HasForeignKey(r => r.ValueKey);

            modelBuilder.Entity<Smaterial>(entity =>
            {
                entity.ToTable("SMaterial");

                entity.HasIndex(e => e.Code, "SMaterialcode");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.Directional).HasColumnName("directional");

                entity.Property(e => e.VariantsTableRef).HasColumnName("_variantsTableRef");
            });

            modelBuilder.Entity<SmaterialDescriptionsRef>(entity =>
            {
                entity.ToTable("SMaterial_descriptionsREF");

                entity.HasIndex(e => e.LookupKey, "SMaterial_descriptionsREFlookupKey");

                entity.HasIndex(e => e.OwnerKey, "SMaterial_descriptionsREFownerKey");

                entity.HasIndex(e => e.ValueKey, "SMaterial_descriptionsREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.LookupKey).HasColumnName("lookupKey");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<SmaterialDescriptionsRef>()
                .HasOne(r => r.Owner)
                .WithMany(o => o.DescriptionsRefs)
                .HasForeignKey(r => r.OwnerKey);

            modelBuilder.Entity<SmaterialExternalRef>(entity =>
            {
                entity.ToTable("SMaterial_externalREF");

                entity.HasIndex(e => e.OwnerKey, "SMaterial_externalREFownerKey");

                entity.HasIndex(e => e.ValueKey, "SMaterial_externalREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<SmaterialExternalRef>()
                .HasOne(r => r.Owner)
                .WithMany(o => o.ExternalRefs)
                .HasForeignKey(r => r.OwnerKey);

            modelBuilder.Entity<SmaterialExternalRef>()
                .HasOne(r => r.Child)
                .WithMany(c => c.SmaterialExternalRefs)
                .HasForeignKey(r => r.ValueKey);

            modelBuilder.Entity<SmaterialPatternRepeatRef>(entity =>
            {
                entity.ToTable("SMaterial_patternRepeatREF");

                entity.HasIndex(e => e.OwnerKey, "SMaterial_patternRepeatREFownerKey");

                entity.HasIndex(e => e.ValueKey, "SMaterial_patternRepeatREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<UsageType>(entity =>
            {
                entity.ToTable("UsageType");

                entity.HasIndex(e => e.Code, "UsageTypecode");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.OtherQuality).HasColumnName("otherQuality");

                entity.Property(e => e.OtherType).HasColumnName("otherType");

                entity.Property(e => e.Quality).HasColumnName("quality");

                entity.Property(e => e.Type).HasColumnName("type");
            });

            modelBuilder.Entity<VersionType>(entity =>
            {
                entity.ToTable("VersionType");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Code).HasColumnName("_code");

                entity.Property(e => e.Effectivedate).HasColumnName("_effectivedate");

                entity.Property(e => e.Expirationdate).HasColumnName("_expirationdate");
            });

            modelBuilder.Entity<DataCatalogConnectorsRef>(entity =>
            {
                entity.ToTable("DataCatalog_connectorsREF");

                entity.HasIndex(e => e.LookupKey, "DataCatalog_connectorsREFlookupKey");

                entity.HasIndex(e => e.OwnerKey, "DataCatalog_connectorsREFownerKey");

                entity.HasIndex(e => e.ValueKey, "DataCatalog_connectorsREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.LookupKey).HasColumnName("lookupKey");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<DataCatalogThumbPathsRef>(entity =>
            {
                entity.ToTable("DataCatalog_thumbPathsREF");

                entity.HasIndex(e => e.LookupKey, "DataCatalog_thumbPathsREFlookupKey");

                entity.HasIndex(e => e.OwnerKey, "DataCatalog_thumbPathsREFownerKey");

                entity.HasIndex(e => e.ValueKey, "DataCatalog_thumbPathsREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.LookupKey).HasColumnName("lookupKey");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<DsExternalRefKeyType>(entity =>
            {
                entity.ToTable("DsExternalRefKeyType");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Type).HasColumnName("_type");

                entity.Property(e => e.Value).HasColumnName("_value");
            });

            modelBuilder.Entity<DsProductTypeAddProductRefsRef>(entity =>
            {
                entity.ToTable("DsProductType_addProductRefsREF");

                entity.HasIndex(e => e.OwnerKey, "DsProductType_addProductRefsREFownerKey");

                entity.HasIndex(e => e.ValueKey, "DsProductType_addProductRefsREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<DsProductTypeConnectorsRef>(entity =>
            {
                entity.ToTable("DsProductType_connectorsREF");

                entity.HasIndex(e => e.OwnerKey, "DsProductType_connectorsREFownerKey");

                entity.HasIndex(e => e.ValueKey, "DsProductType_connectorsREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<DsProductTypeRuleRefsRef>(entity =>
            {
                entity.ToTable("DsProductType_ruleRefsREF");

                entity.HasIndex(e => e.OwnerKey, "DsProductType_ruleRefsREFownerKey");

                entity.HasIndex(e => e.ValueKey, "DsProductType_ruleRefsREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<DsTableRowType>(entity =>
            {
                entity.ToTable("DsTableRowType");

                entity.HasIndex(e => e.Code, "DsTableRowTypecode");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Code).HasColumnName("code");
            });

            modelBuilder.Entity<DsTableRowTypeCellsRef>(entity =>
            {
                entity.ToTable("DsTableRowType_cellsREF");

                entity.HasIndex(e => e.OwnerKey, "DsTableRowType_cellsREFownerKey");

                entity.HasIndex(e => e.ValueKey, "DsTableRowType_cellsREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<DsTableRowTypeCellsRef>()
                .HasOne(r => r.Owner)
                .WithMany(o => o.Cells)
                .HasForeignKey(r => r.OwnerKey);


            modelBuilder.Entity<DsTableTypeRowsRef>(entity =>
            {
                entity.ToTable("DsTableType_rowsREF");

                entity.HasIndex(e => e.OwnerKey, "DsTableType_rowsREFownerKey");

                entity.HasIndex(e => e.ValueKey, "DsTableType_rowsREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<OptionConnectorsRef>(entity =>
            {
                entity.ToTable("Option_connectorsREF");

                entity.HasIndex(e => e.OwnerKey, "Option_connectorsREFownerKey");

                entity.HasIndex(e => e.ValueKey, "Option_connectorsREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<OptionExternalRefKeysRef>(entity =>
            {
                entity.ToTable("Option_externalRefKeysREF");

                entity.HasIndex(e => e.OwnerKey, "Option_externalRefKeysREFownerKey");

                entity.HasIndex(e => e.ValueKey, "Option_externalRefKeysREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<PrdExternalRefTypeExternalRefKeysRef>(entity =>
            {
                entity.ToTable("PrdExternalRefType_externalRefKeysREF");

                entity.HasIndex(e => e.OwnerKey, "PrdExternalRefType_externalRefKeysREFownerKey");

                entity.HasIndex(e => e.ValueKey, "PrdExternalRefType_externalRefKeysREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<PrdExternalRefTypeExternalRefKeysRef>()
                .HasOne(p => p.Owner)
                .WithMany(o => o.ExternalRefKeys)
                .HasForeignKey(p => p.OwnerKey);

            modelBuilder.Entity<PrdExternalRefTypeExternalRefKeysRef>()
                .HasOne(c => c.Child)
                .WithMany(d => d.PrdExternalRefTypeExternalRefKeysRefs)
                .HasForeignKey(p => p.ValueKey);

            modelBuilder.Entity<PrdExternalRefTypeNamedPointsRef>(entity =>
            {
                entity.ToTable("PrdExternalRefType_namedPointsREF");

                entity.HasIndex(e => e.OwnerKey, "PrdExternalRefType_namedPointsREFownerKey");

                entity.HasIndex(e => e.ValueKey, "PrdExternalRefType_namedPointsREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<SfeatureConnectorsRef>(entity =>
            {
                entity.ToTable("SFeature_connectorsREF");

                entity.HasIndex(e => e.OwnerKey, "SFeature_connectorsREFownerKey");

                entity.HasIndex(e => e.ValueKey, "SFeature_connectorsREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<SfeatureFeatureRefsRef>(entity =>
            {
                entity.ToTable("SFeature_featureRefsREF");

                entity.HasIndex(e => e.OwnerKey, "SFeature_featureRefsREFownerKey");

                entity.HasIndex(e => e.ValueKey, "SFeature_featureRefsREFvalueKey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.OwnerKey).HasColumnName("ownerKey");

                entity.Property(e => e.TypeKey).HasColumnName("typeKey");

                entity.Property(e => e.ValueKey).HasColumnName("valueKey");
            });

            modelBuilder.Entity<Url>(entity =>
            {
                entity.ToTable("Url");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.FileNameBase).HasColumnName("fileNameBase");

                entity.Property(e => e.Scheme).HasColumnName("scheme");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
