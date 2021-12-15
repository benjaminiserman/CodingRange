using System.Collections;
using System.Text;

namespace CodingRange
{
    public static class DisplayHelper
    {
        private static string CollectionToString(IEnumerable array, bool simplify)
        {
            StringBuilder sb = new(simplify ? string.Empty : "{ ");

            foreach (var x in array)
            {
                sb.Append($"{ForDisplay(x, false)}, ");
            }

            sb.Remove(sb.Length - 2, 2);

            string end = simplify ? string.Empty : " }";
            return $"{sb}{end}";
        }

        public static string ForDisplay(object x, bool simplify) => x switch
        {
            null => "null",
            string str => $"\"{str}\"",
            IEnumerable ie => CollectionToString(ie, simplify),
            char c => $"'{c}'",
            bool b => b.ToString().ToLower(),
            _ => x.ToString()
        };
    }
}