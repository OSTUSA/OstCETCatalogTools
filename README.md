![Build Status](https://github.com/Jucci16Ost/OstCatalogTools/workflows/BuildAndTest/badge.svg)

# OstCatalogTools
Tools for assisting in Catalog creation

# External Tools that will make your life easier.
[Sqlite Browser](https://sqlitebrowser.org/dl/) is an open source and free Database browser. Use this to get familiar with the catalog schemes and to make simple changes to the data itself. Be careful not to have this browser and the Catalog Creator in CET open the same catalog, it may cause some issues saving changes.

[SQLite CLI](https://www.sqlite.org/download.html) is useful for comparing database schemes and seeing which tables we are missing. Be sure to add these to your System Paths or these tools will be useless. Once added you can run a command like 

```
sqldiff --schema C:\Users\jucci\Downloads\TML.db3 "C:\Users\jucci\Downloads\TML (1).db3"
```

Entity Framework Core tools is crucial to creating new databases. This can be done by running the command:

```
dotnet tool install --global dotnet-ef
```

# OstToolsDataLayer
OstToolsDataLayer is where the core logic resides. More specifically the CetCatalogEf folder. For a quick reference on how to use the Catalog Juicer, look at the OstCatalogToolsUnitTest project. 

# Using dotnet-ef

Careful when updating the schema of the CetCatalog. The DbContext has all the data on related entities and will be overwritten by the scaffolder. To keep things safe, always output the new tables to a different folder. Here is an example of a command that was used to add new tables to the schema. They had to be copied over and have the namespace renamed after the scaffolder ran. In the provided example, all tables were added to a folder named aaa and were also added to that namespace. 

```
dotnet ef dbcontext scaffold "Data Source=C:\Users\jucci\Downloads\TML (1).db3" Microsoft.EntityFrameworkCore.Sqlite --output-dir aaa --table DataCatalog_connectorsREF --table DataCatalog_thumbPathsREF --table DsExternalRefKeyType --table DsProductType_addProductRefsREF --table DsProductType_connectorsREF --table DsProductType_ruleRefsREF --table DsTableRowType --table DsTableRowType_cellsREF --table DsTableType_rowsREF --table Option_connectorsREF --table Option_externalRefKeysREF --table PrdExternalRefType_externalRefKeysREF --table PrdExternalRefType_namedPointsREF --table SFeature_connectorsREF --table SFeature_featureRefsREF --table Url
```

If tables are not specified, it will scaffold the entire database again. [Here is the link to Reverse Engineering the catalog](https://docs.microsoft.com/en-us/ef/core/managing-schemas/scaffolding?tabs=dotnet-core-cli). Please note that insetead of using Microsoft.EntityFrameworkCore.SqlServer, you will be using Microsoft.EntityFrameworkCore.Sqlite in the command above. 

# Good luck!
