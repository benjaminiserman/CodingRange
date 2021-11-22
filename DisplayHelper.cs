using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingRange
{
    public static class DisplayHelper
    {
        private static string CollectionToString(IEnumerable<object> array)
        {
            string result = string.Empty;

            foreach (var x in array)
            {
                result += $"{ForDisplay(x)}, ";
            }

            return result[..^2];
        }

        public static string ForDisplay(object x)
        {
            return x switch
            {
                string str => $"\"{str}\"",
                IEnumerable<object> ie => CollectionToString(ie),
                char c => $"'{c}'",
                bool b => b.ToString().ToLower(),
                _ => x.ToString()
            };
        }
    }
}
