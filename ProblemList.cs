using System.Collections.Generic;

namespace CodingRange
{
    public static class ProblemList
    {
        public static List<Problem> List { get; } = new()
        {
            new Problem("Hello World", "Return the string \"Hello World!\"", "(no parameters)", "string", new[] { 
                new TestCase(null, "Hello World!")
            }),


        };
    }
}
