using System;
using System.Collections.Generic;
using System.IO;

namespace XrfParser
{
    class Program
    {
        static void Main(string[] args)
        {
            var directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "CET Documents", "Trig", "DWG");
            var files = Directory.GetFiles(directoryPath, "*XRF.txt");
            var xrfModels = new List<XrfModel>();
            Console.WriteLine(directoryPath);
            foreach (var file in files)
            {
                xrfModels.AddRange(new XrfParser(file).ParseFile());
            }

            foreach (var xrfModel in xrfModels)
            {
                Console.WriteLine(xrfModel.PartNumber);
                Console.WriteLine(xrfModel.Symbol);
                Console.WriteLine();
            }
        }
    }
}
