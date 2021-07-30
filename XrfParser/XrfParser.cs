using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrfParser
{
    public class XrfParser
    {
        private readonly string _filePath;

        public XrfParser(string filePath)
        {
            _filePath = filePath;
        }

        public IEnumerable<XrfModel> ParseFile()
        {
            if (!File.Exists(_filePath)) return null;
            var content = File.ReadAllLines(_filePath);
            var models = new List<XrfModel>();

            for (var i = 0; i < content.Length; i++)
            {
                var s = content[i];
                var j = i + 1;
                var k = j + 1;
                var xrf = new XrfModel();
                
                if (j >= content.Length) continue;

                if (s.ToLower().StartsWith("pn")) xrf.PartNumber = s.Substring(3);
                if (content[j].ToLower().StartsWith("pv")) xrf.PartValue = content[j].Substring(3);
                if (content[j].ToLower().StartsWith("3d")) xrf.Symbol = content[j].Substring(3);
                if (!string.IsNullOrWhiteSpace(xrf.Symbol))
                {
                    models.Add(xrf);
                    continue;
                } 

                if (k >= content.Length) continue;
                if (content[k].ToLower().StartsWith("3d")) xrf.Symbol = content[k].Substring(3);
                if (!string.IsNullOrWhiteSpace(xrf.Symbol)) models.Add(xrf);
            }

            return models;
        }
    }
}
