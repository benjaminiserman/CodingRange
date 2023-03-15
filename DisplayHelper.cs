using System.Collections;
using System.Text;

namespace CodingRange
{
    public static class DisplayHelper
    {
        private static string CollectionToString(IEnumerable array, bool simplify)
        {
            StringBuilder stringBuilder = new(simplify 
                ? string.Empty 
                : "{ ");

            foreach (var x in array)
            {
                stringBuilder.Append($"{ForDisplay(x, false)}, ");
            }

            stringBuilder.Remove(stringBuilder.Length - 2, 2);

            var end = simplify 
                ? string.Empty 
                : " }";
            return $"{stringBuilder}{end}";
        }

        public static string ForDisplay(object x, bool simplify) => x switch
        {
            null => "null",
            string s => $"\"{s}\"",
            IEnumerable ie => CollectionToString(ie, simplify),
            char c => $"'{c}'",
            bool b => b.ToString().ToLower(),
            _ => x.ToString()
        };
    }
}