using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissingSymbolListCreator
{
    public class MissingSymbolListCreator
    {
        public void SortSymbolList(string list)
        {
            var symbolCollection = list.Split('\n').ToList();
            symbolCollection.Sort();
            foreach (var symbol in symbolCollection)
            {
                Console.WriteLine(symbol);
            }

            Console.WriteLine(symbolCollection.Count);
        }

        public string LineDelimitedToCsv(string list)
        {
            var symbolCollection = list.Split('\r').ToList();
            symbolCollection.Sort();
            return string.Join(';', symbolCollection).Replace("\n", "");
        }
    }
}
