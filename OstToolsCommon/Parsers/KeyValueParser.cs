using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OstToolsCommon.Parsers
{
    public abstract class KeyValueParser<TModel> where TModel : new()
    {
        /// <summary>
        /// Get single use keys only. If these keys are used again, it denotes the creation of a new model
        /// </summary>
        /// <returns></returns>
        protected abstract HashSet<string> GetUniqueKeys();

        /// <summary>
        /// Parse provided key value pair.
        /// </summary>
        /// <param name="filePath">Path to Key Value file</param>
        /// <param name="splitter">String or character used to split the Key and value</param>
        /// <returns></returns>
        public async Task<IEnumerable<TModel>> ParseFileAsync(string filePath, string splitter = "=")
        {
            if (!File.Exists(filePath)) return new List<TModel>();
            var content = await File.ReadAllLinesAsync(filePath);
            return ParseAllLines(content, splitter);
        }

        /// <summary>
        /// Parse provided key value string. Can be one or multiple lines.
        /// </summary>
        /// <param name="content">Key value string</param>
        /// <param name="splitter">String or character used to split the Key and value</param>
        /// <returns></returns>
        public IEnumerable<TModel> ParseString(string content, string splitter = "=")
        {
            return ParseAllLines(content.Split('\r', '\n'), splitter);
        }

        /// <summary>
        /// Parse provided lines of key value line collection.
        /// </summary>
        /// <param name="lineEnumerable">Collection of Key Value pairs split by splitter</param>
        /// <param name="splitter">String or character splitting the key and value</param>
        /// <returns>Collection of parsed models.</returns>
        public IEnumerable<TModel> ParseAllLines(IEnumerable<string> lineEnumerable, string splitter = "=")
        {
            var lines = lineEnumerable.ToList();
            var models = new List<TModel>();
            var i = 0;
            while (i < lines.Count)
            {
                i = ParseModel(models, lines, splitter, i);
            }

            return models;
        }

        /// <summary>
        /// Parse single model from current index in line collection
        /// </summary>
        /// <param name="modelCollection"></param>
        /// <param name="lines"></param>
        /// <param name="splitter"></param>
        /// <param name="i"></param>
        /// <returns>Index of the start of a new model</returns>
        private int ParseModel(ICollection<TModel> modelCollection, IReadOnlyList<string> lines, string splitter, int i)
        {
            var usedKeys = new HashSet<string>();
            var model = new TModel();
            while (ShouldContinueParsingModel(usedKeys, GetKey(lines, splitter, i)) && i < lines.Count)
            {
                SetPropertyValue(GetKey(lines, splitter, i), GetValue(lines, splitter, i), model);
                i++;
            }

            modelCollection.Add(model);
            return i;
        }

        /// <summary>
        /// Should continue parsing same model?
        /// </summary>
        /// <param name="usedKeys">Used keys on current model</param>
        /// <param name="currentKey">Current key being parsed in model</param>
        /// <returns>True if model is not done being parsed.</returns>
        private bool ShouldContinueParsingModel(ISet<string> usedKeys, string currentKey)
        {
            var shouldContinue = !(usedKeys.Contains(currentKey) && GetUniqueKeys().Contains(currentKey));
            usedKeys.Add(currentKey);

            return shouldContinue;
        }

        /// <summary>
        /// Get key from line
        /// </summary>
        /// <param name="lines">Line Collection</param>
        /// <param name="splitter">Character or string the separates key and value</param>
        /// <param name="index">Current line index in line collection</param>
        /// <returns>Key Value in lines[i]</returns>
        private static string GetKey(IReadOnlyList<string> lines, string splitter, int index)
        {
            if (index >= lines.Count) return string.Empty;
            var key = lines[index].Split(splitter).FirstOrDefault();
            return key;
        }

        /// <summary>
        /// Get Value from line
        /// </summary>
        /// <param name="lines">Line collection</param>
        /// <param name="splitter">Character or string that separates the key and value pair</param>
        /// <param name="index">index in line collection</param>
        /// <returns>Value of key value pair in lines[i]</returns>
        private static string GetValue(IReadOnlyList<string> lines, string splitter, int index)
        {
            if (index >= lines.Count) return string.Empty;
            var value = lines[index].Split(splitter).LastOrDefault();
            return value;
        }

        /// <summary>
        /// Set property of provided model
        /// </summary>
        /// <param name="key">Property name</param>
        /// <param name="value">Value of property</param>
        /// <param name="model">Model to set the property on.</param>
        protected abstract void SetPropertyValue(string key, string value, TModel model);
    }
}
