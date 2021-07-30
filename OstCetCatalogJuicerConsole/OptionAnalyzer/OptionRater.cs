using System;
using System.Collections.Generic;
using System.Linq;
using OstToolsModels.CetCatalog;

namespace OstCetCatalogJuicerConsole.OptionAnalyzer
{
    internal class OptionRater
    {
        /// <summary>
        /// History of decisions
        /// </summary>
        private Stack<ConsoleKey> _history = new Stack<ConsoleKey>();

        /// <summary>
        /// Good codes
        /// </summary>
        private readonly List<string> _good;

        /// <summary>
        /// Bad codes
        /// </summary>
        private readonly List<string> _bad;

        /// <summary>
        /// Unknown codes
        /// </summary>
        private readonly List<string> _unknown;

        /// <summary>
        /// Current index in Options
        /// </summary>
        private int _index = 0;

        /// <summary>
        /// List of Good option codes - csv.
        /// </summary>
        public string GoodList => string.Join(';', _good);

        /// <summary>
        /// List of bad option codes - csv.
        /// </summary>
        public string BadList => string.Join(';', _bad);

        /// <summary>
        /// List of unknown option codes - csv
        /// </summary>
        public string UnknownList => string.Join(';', _unknown);

        /// <summary>
        /// List of all options
        /// </summary>
        public List<CetOptionModel> Options { get; }

        public OptionRater(string goodList, string badList, string unknownList, List<CetOptionModel> options)
        {
            _good = goodList.Split(';').ToList();
            _bad = badList.Split(';').ToList();
            _unknown = unknownList.Split(';').ToList();
            Options = options;
        }

        /// <summary>
        /// Pick and choose the options manually.
        /// </summary>
        public void PickAndChoose()
        {
            while (_index < Options.Count)
            {
                if (_index < 0) _index = 0;
                CreatePrompt();
                ReadInput();
            }
        }

        /// <summary>
        /// Get the current option.
        /// </summary>
        /// <returns>Null if out of bounds. Returns option at current index.</returns>
        private CetOptionModel GetCurrentOption()
        {
            if (_index < 0 || _index >= Options.Count) return null;
            return Options[_index];
        }

        /// <summary>
        /// Create Prompt for user with instructions and current option displayed in console.
        /// </summary>
        private void CreatePrompt()
        {
            var option = GetCurrentOption();
            Console.Clear();
            Console.WriteLine($"Currently on {_index}/{Options.Count}");
            Console.WriteLine("Press 'G' for good, 'B' for bad, 'U' for unknown, 'P' for previous, or 'E' for exit");
            Console.WriteLine();
            Console.WriteLine("Code: " + option.Code);
            Console.WriteLine("Description: " + option.DescriptionReference.ValueKey);
            Console.WriteLine();
        }

        /// <summary>
        /// Read User Input
        /// </summary>
        private void ReadInput()
        {
            var option = GetCurrentOption();
            var key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.G:
                    _good.Add(option.Code);
                    _history.Push(ConsoleKey.G);
                    _index++;
                    return;
                case ConsoleKey.B:
                    _bad.Add(option.Code);
                    _history.Push(ConsoleKey.B);
                    _index++;
                    return;
                case ConsoleKey.U:
                    _unknown.Add(option.Code);
                    _history.Push(ConsoleKey.U);
                    _index++;
                    return;
                case ConsoleKey.P:
                    Previous();
                    _index--;
                    return;
                case ConsoleKey.E:
                    _index = Options.Count;
                    return;
                default:
                    return;
            }
        }

        /// <summary>
        /// Go back to the previously decided option and redo it.
        /// </summary>
        private void Previous()
        {
            if (_index <= 0) return;
            var key = _history.Pop();
            switch (key)
            {
                case ConsoleKey.G:
                    _good.RemoveAt(_good.Count - 1);
                    break;
                case ConsoleKey.B:
                    _bad.RemoveAt(_bad.Count - 1);
                    break;
                case ConsoleKey.U:
                    _unknown.RemoveAt(_unknown.Count - 1);
                    break;
                default:
                    Console.WriteLine("Unrecognized key: " + key);
                    break;
            }
        }
    }
}
