using System;
using System.Reflection;
using System.Linq;

namespace CodingRange
{
    public class Problem
    {
        readonly string name;
        readonly string description;
        readonly string expectedParameters;
        readonly string expectedOutput;
        readonly TestCase[] testCases;
        readonly string specialNotes;

        public Problem(string name, string description, string expectedParameters, string expectedOutput, TestCase[] testCases, string specialNotes = null)
        {
            this.name = name;
            this.description = description;
            this.expectedParameters = expectedParameters;
            this.expectedOutput = expectedOutput;
            this.testCases = testCases;
            this.specialNotes = specialNotes;
        }

        public void Evaluate(MethodInfo method)
        {
            Console.WriteLine("\nOutput:\n");

            foreach (var @case in testCases)
            {
                object result;

                try
                {
                    result = method.Invoke(new Workspace(), @case.inputs);
                }
                catch (TargetParameterCountException)
                {
                    Console.WriteLine($"Error! Incorrect number of parameters. Problem \"{name}\" expects {@case.inputs?.Length ?? 0} inputs.");
                    return;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine($"Error! An ArgumentException was thrown... This may be due to an error in your method signature. Does it match \"{expectedParameters}\"?");
                    throw;
                }

                if (!result.Equals(@case.expectedOutput))
                {
                    if (@case.inputs == null || @case.inputs.Length == 0) Console.WriteLine($"Error!\nGot: {result}\nExpected: {@case.expectedOutput}");
                    else Console.WriteLine($"Error!\nInputs: {{ {ArrayToString(@case.inputs)} }}\nGot: {result}\nExpected: {@case.expectedOutput}");
                    return;
                }
            }

            Console.WriteLine($"SUCCESS!\n\nAll {testCases.Length} cases passed successfully.\nHave your tutor evaluate your code before moving on to the next problem.");
        }

        public void Display()
        {
            int id = ProblemList.List.FindIndex(x => x.name == name);

            Console.WriteLine($"Problem {id}: {name}\nExpected method parameters: {expectedParameters}\nExpected output type: {expectedOutput}\n\nInstructions:\n\n{description}");
            if (testCases[0].inputs != null)
            {
                TestCase @case;
                if (testCases[0].expectedOutput is bool)
                {
                    @case = testCases.First(x => (bool)x.expectedOutput);
                    Console.WriteLine($"\nExample: {{ {ArrayToString(@case.inputs)} }} => {@case.expectedOutput}");

                    @case = testCases.First(x => !(bool)x.expectedOutput);
                    Console.WriteLine($"\nExample: {{ {ArrayToString(@case.inputs)} }} => {@case.expectedOutput}");
                }
                else
                {
                    @case = testCases[0];
                    Console.WriteLine($"\nExample: {{ {ArrayToString(@case.inputs)} }} => {@case.expectedOutput}");
                }
            }
            if (!string.IsNullOrWhiteSpace(specialNotes)) Console.WriteLine($"\n{specialNotes}");
        }

        private static string ArrayToString(object[] array)
        {
            string result = string.Empty;

            foreach (var x in array)
            {
                result += $"{x}, ";
            }

            return result[0..^2];
        }
    }
}