using System.Collections.Generic;

namespace CodingRange
{
    public static class ProblemList
    {
        public static List<Problem> List { get; } = new()
        {
            new Problem("Hello World", "Return the string \"Hello World!\".", "(no parameters)", "string", new[] { 
                new TestCase(null, "Hello World!")
            }),
            new Problem("Doubling", "Return the input multiplied by two.", "int x", "int", new[] {
                new TestCase(new object[] { 1 }, 2),
                new TestCase(new object[] { 0 }, 0),
                new TestCase(new object[] { -7 }, -14),
                new TestCase(new object[] { 5 }, 10),
                new TestCase(new object[] { 817 }, 1634),
                new TestCase(new object[] { -51 }, -102),
                new TestCase(new object[] { 21 }, 42),
            }),
            new Problem("Squares", "Return the input squared (hint: multiplied by itself).", "int x", "int", new[] {
                new TestCase(new object[] { 1 }, 1),
                new TestCase(new object[] { 0 }, 0),
                new TestCase(new object[] { -7 }, 49),
                new TestCase(new object[] { 5 }, 25),
                new TestCase(new object[] { 817 }, 667489),
                new TestCase(new object[] { 4 }, 16),
                new TestCase(new object[] { 21 }, 441),
            }),
            new Problem("Negatives", "Return the inverse of the input (hint: multiplied by -1).", "int x", "int", new[] {
                new TestCase(new object[] { 1 }, -1),
                new TestCase(new object[] { 0 }, 0),
                new TestCase(new object[] { -7 }, 7),
                new TestCase(new object[] { 6 }, -6),
                new TestCase(new object[] { -523 }, 523),
                new TestCase(new object[] { 375 }, -375),
                new TestCase(new object[] { 21 }, -21),
            }),
            new Problem("Order of Operations", "Add one to the input and return that new value multplied by negative two.", "int x", "int", new[] {
                new TestCase(new object[] { 1 }, -4),
                new TestCase(new object[] { 0 }, -2),
                new TestCase(new object[] { -7 }, 12),
                new TestCase(new object[] { 5 }, -12),
                new TestCase(new object[] { 817 }, -1636),
                new TestCase(new object[] { 4 }, -10),
                new TestCase(new object[] { 21 }, -44),
            }),
        };
    }
}
