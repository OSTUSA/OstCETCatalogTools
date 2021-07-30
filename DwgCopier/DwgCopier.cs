using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XrfParser;

namespace DwgCopier
{
    public class DwgCopier
    {
        private readonly string _outputDirectory;
        private readonly string _dwgDirectory;


        public DwgCopier(string catalogName, string outputDirectory="", string dwgDirectory="")
        {
            if (string.IsNullOrWhiteSpace(outputDirectory))
            {
                _outputDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "CET Documents",
                    catalogName);
            }
            else
            {
                _outputDirectory = outputDirectory;
            }

            if (string.IsNullOrWhiteSpace(dwgDirectory))
            {
                _dwgDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "CET Documents",
                    catalogName, "DWG");
            }
            else
            {
                _dwgDirectory = dwgDirectory;
            }

            if (!Directory.Exists(_dwgDirectory))
            {
                throw new Exception("DWG directory not found: " + _dwgDirectory);
            }

            if (Directory.Exists(Path.Combine(_outputDirectory, "not reviewed")))
            {
                DeleteOldFiles(Path.Combine(_outputDirectory, "not reviewed"));
            }
        }

        public void CopyToInchesCsv(string csv, char separator = ';')
        {
            if (string.IsNullOrWhiteSpace(csv)) return;
            DeleteOldFiles(GetToInchesPath());
            var filePaths = GetFilePathsFromCsv(csv, separator);
            CopyFiles(filePaths, GetToInchesPath());
        }

        public void CopyToInchesXrf(IEnumerable<XrfModel> xrfModels)
        {
            DeleteOldFiles(GetToInchesPath());
            var filePaths = GetFilePathsFromXrf(xrfModels);
            CopyFiles(filePaths, GetToInchesPath());
        }

        public void CopyToMeterCsv(string csv, char separator = ';')
        {
            if (string.IsNullOrWhiteSpace(csv)) return;
            DeleteOldFiles(GetToMeterPath());
            var filePaths = GetFilePathsFromCsv(csv, separator);
            CopyFiles(filePaths, GetToMeterPath());
        }

        public void CopyToMeterXrf(IEnumerable<XrfModel> xrfModels)
        {
            DeleteOldFiles(GetToMeterPath());
            var filePaths = GetFilePathsFromXrf(xrfModels);
            CopyFiles(filePaths, GetToMeterPath());
        }

        private void DeleteOldFiles(string directory)
        {
            if (!Directory.Exists(directory)) return;
            var files = Directory.GetFiles(directory);
            foreach (var file in files)
            {
                if (file.ToLower().EndsWith("xrf.txt")) continue;
                File.Delete(file);
            }
            if (Directory.GetFiles(directory).Length == 0) Directory.Delete(directory);
        }

        private IEnumerable<string> GetFilePathsFromCsv(string csv, char separator)
        {
            var formattedFileNames = GetFormattedFileNames(csv.Split(separator));
            var filePaths = FindFilePaths(formattedFileNames, _dwgDirectory);
            return filePaths;
        }

        private IEnumerable<string> GetFilePathsFromXrf(IEnumerable<XrfModel> xrf)
        {
            var fileNames = xrf.Select(x => x.Symbol + ".dwg");

            var filePaths = FindFilePaths(fileNames, _dwgDirectory);
            return filePaths;
        }

        private string GetToInchesPath()
        {
            return Path.Combine(_outputDirectory, "ToInches");
        }

        private string GetToMeterPath()
        {
            return Path.Combine(_outputDirectory, "ToMeter");
        }

        protected virtual IEnumerable<string> GetFormattedFileNames(IEnumerable<string> csv)
        {
            var list = csv.ToList();
            var newList = new List<string>();
            foreach (var item in list)
            {
                newList.Add("3" + item.Replace(".", "") + ".dwg");
                newList.Add("3" + item + ".dwg");
            }

            return newList;
        }

        private IEnumerable<string> FindFilePaths(IEnumerable<string> fileNames, string searchDirectory)
        {
            return fileNames.Select(fileName => Directory.GetFiles(searchDirectory, fileName).FirstOrDefault()).ToList();
        }

        private void CopyFiles(IEnumerable<string> filePaths, string outputDirectory)
        {
            // Only creates directories if they do not exist.
            Directory.CreateDirectory(outputDirectory);

            foreach (var filePath in filePaths)
            {
                if (string.IsNullOrWhiteSpace(filePath)) continue;
                var fileName = filePath.Split('\\').LastOrDefault();
                if (string.IsNullOrWhiteSpace(fileName))
                {
                    Console.WriteLine("File was not found: " + filePath);
                    continue;
                }

                File.Copy(filePath, Path.Combine(outputDirectory, fileName), overwrite:true);
            }
            
        }
    }
}
