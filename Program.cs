using System;
using System.Reflection;

namespace CodingRange
{
    internal class Program
    {
        private static void Main()
        {
            Workspace workspace = new();

            var method = typeof(Workspace).GetMethod("Method", (BindingFlags)(-1));

            int problemNumber = (int)typeof(Workspace).GetField("problemNumber", (BindingFlags)(-1)).GetValue(workspace);
            bool displayProblem = (bool)typeof(Workspace).GetField("displayProblem", (BindingFlags)(-1)).GetValue(workspace);
            bool evaluateAnswer = (bool)typeof(Workspace).GetField("evaluateAnswer", (BindingFlags)(-1)).GetValue(workspace);

            if (problemNumber == ProblemList.List.Count)
            {
                Console.WriteLine("It seems you've completed all available problems! Ask Ben if you want more.");
                return;
            }
            else if (problemNumber < 0 || problemNumber > ProblemList.List.Count)
            {
                Console.WriteLine($"Invalid problem number added! Problems range from (0-{ProblemList.List.Count - 1})");
                return;
            }

            if (displayProblem)
            {
                ProblemList.List[problemNumber].Display();
            }

            if (evaluateAnswer)
            {
                ProblemList.List[problemNumber].Evaluate(method);
            }

            if (!displayProblem && !evaluateAnswer) Console.WriteLine("Nothing to display. Enable either displayProblem or evaluateAnswer.");
        }
    }
}