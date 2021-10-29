using System;
using System.Reflection;

namespace CodingRange
{
    public class Problem
    {
        readonly string name;
        readonly string description;
        readonly string expectedSignature;
        readonly string expectedOutput;
        readonly TestCase[] testCases;
        readonly string specialNotes;

        public Problem(string name, string description, string expectedSignature, string expectedOutput, TestCase[] testCases, string specialNotes = null)
        {
            this.name = name;
            this.description = description;
            this.expectedSignature = expectedSignature;
            this.expectedOutput = expectedOutput;
            this.testCases = testCases;
            this.specialNotes = specialNotes;
        }

        public void Evaluate(MethodInfo method)
        {
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
                    Console.WriteLine($"Error! An ArgumentException was thrown... This may be due to an error in your method signature. Does it match \"{expectedSignature}\"?");
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

            Console.WriteLine($"Problem {id}: {name}\nInstructions:\n\n{description}\n\nExpected method signature: {expectedSignature}\nExpected output type: {expectedOutput}\n");
            if (!string.IsNullOrWhiteSpace(specialNotes)) Console.WriteLine(specialNotes);
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
