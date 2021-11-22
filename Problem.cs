using System;
using System.Collections.Generic;
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
                    /*if (@case.inputs == null || @case.inputs.Length == 0) Console.WriteLine($"Error!\nGot: {result}\nExpected: {@case.expectedOutput}");
                    else Console.WriteLine($"Error!\nInputs: {{ {CollectionToString(@case.inputs)} }}\nGot: {result}\nExpected: {@case.expectedOutput}");*/
                    Console.WriteLine("Error!");
                    if (@case.inputs is not null && @case.inputs.Length > 0) Console.WriteLine($"Inputs: {{ {ForDisplay(@case.inputs)} }}");
                    Console.WriteLine($"Got: {ForDisplay(result)}\nExpected: {ForDisplay(@case.expectedOutput)}");
                    return;
                }
            }

            Console.WriteLine($"SUCCESS!\n\nAll {testCases.Length} cases passed successfully.\nHave your tutor evaluate your code before moving on to the next problem.");
        }

        public void Display()
        {
            int id = ProblemList.List.FindIndex(x => x.name == name);

            Console.WriteLine($"Problem {id}: {name}\nExpected method parameters: {expectedParameters}\nExpected output type: {ForDisplay(expectedOutput)}\n\nInstructions:\n\n{description}");
            if (testCases[0].inputs != null)
            {
                TestCase @case;
                if (testCases[0].expectedOutput is bool)
                {
                    @case = testCases.First(x => (bool)x.expectedOutput);
                    Console.WriteLine($"\nExample: {{ {ForDisplay(@case.inputs)} }} => {ForDisplay(@case.expectedOutput)}");

                    @case = testCases.First(x => !(bool)x.expectedOutput);
                    Console.WriteLine($"\nExample: {{ {ForDisplay(@case.inputs)} }} => {ForDisplay(@case.expectedOutput)}");
                }
                else
                {
                    @case = testCases[0];
                    Console.WriteLine($"\nExample: {{ {ForDisplay(@case.inputs)} }} => {ForDisplay(@case.expectedOutput)}");
                }
            }
            if (!string.IsNullOrWhiteSpace(specialNotes)) Console.WriteLine($"\n{specialNotes}");
        }

        private static string CollectionToString(IEnumerable<object> array)
        {
            string result = string.Empty;

            foreach (var x in array)
            {
                result += $"{ForDisplay(x)}, ";
            }

            return result[..^2];
        }

        private static string ForDisplay(object x)
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