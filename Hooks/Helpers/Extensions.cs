using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SpecFlowNunit.Hooks.Helpers
{
    public static class Extensions
    {
        public static Dictionary<string, string> ToDictionary(this Table table)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                dictionary.Add(row[0], row[1]);
            }
            return dictionary;
        }

        public static string WithHtmlExtension(this string path) => $"{path}.html";
    }
}