using System.Collections.Generic;
using OstToolsCommon.Parsers.Models;

namespace OstToolsCommon.Parsers
{
    public class XrfParser: KeyValueParser<XrfModel>
    {
        /// <inheritdoc />
        protected override HashSet<string> GetUniqueKeys()
        {
            return new HashSet<string>
            {
                "PN",
                "PV",
                "3D"
            };
        }

        /// <inheritdoc />
        protected override void SetPropertyValue(string key, string value, XrfModel model)
        {
            switch (key)
            {
                case "PN":
                    model.PartNumber = value;
                    return;
                case "PV":
                    model.PartValue = value;
                    return;
                case "3D":
                    model.Symbol = value;
                    return;
            }
        }
    }
}