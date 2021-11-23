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
            StringBuilder sb = new();

            foreach (var x in array)
            {
                sb.Append($"{ForDisplay(x)}, ");
            }

            sb.Remove(sb.Length - 2, 2);

            return sb.ToString();
        }

        public static string ForDisplay(object x) => x switch
        {
            string str => $"\"{str}\"",
            IEnumerable<object> ie => CollectionToString(ie),
            char c => $"'{c}'",
            bool b => b.ToString().ToLower(),
            _ => x.ToString()
        };
    }
}
