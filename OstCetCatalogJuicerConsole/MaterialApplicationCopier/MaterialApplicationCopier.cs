using System;
using System.Linq;
using System.Threading.Tasks;

namespace OstCetCatalogJuicerConsole.MaterialApplicationCopier
{
    public class MaterialApplicationCopier
    {
        private readonly string _copyDbConnectionString;
        private readonly string _pasteDbConnectionString;

        public MaterialApplicationCopier(string copyDbConnectionString, string pasteDbConnectionString)
        {
            _pasteDbConnectionString = pasteDbConnectionString;
            _copyDbConnectionString = copyDbConnectionString;
        }

        public async Task CopyMaterialApplications()
        {
            var retriever = new MaterialApplicationRetriever(_copyDbConnectionString);
            var materialApplications = (await retriever.GetApplicationAreas()).ToList();
            var materialApplicationReferences = (await retriever.GetApplicationReferences()).ToList();

            Console.WriteLine("Material Applications Count: " + materialApplications.Count);
            Console.WriteLine("Material References Count: " + materialApplicationReferences.Count);

            var inserter = new MaterialApplicationInserter(_pasteDbConnectionString);
            await inserter.InsertApplications(materialApplications, materialApplicationReferences);
        }
    }
}
