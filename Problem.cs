using System;
using System.Linq;
using System.Reflection;

namespace CodingRange
{
    public class Problem
    {
        private readonly string _name;
        private readonly string _description;
        private readonly string _expectedParameters;
        private readonly string _expectedOutput;
        private readonly TestCase[] _testCases;
        private readonly string _specialNotes;

        public Problem(string name, string description, string expectedParameters, string expectedOutput, TestCase[] testCases, string specialNotes = null)
        {
            _name = name;
            _description = description;
            _expectedParameters = expectedParameters;
            _expectedOutput = expectedOutput;
            _testCases = testCases;
            _specialNotes = specialNotes;
        }

        public void Evaluate(MethodInfo method)
        {
            Console.WriteLine("\nOutput:\n");

            foreach (var @case in _testCases)
            {
                object result;

                try
                {
                    result = method.Invoke(new Workspace(), @case.inputs);
                }
                catch (TargetParameterCountException)
                {
                    Console.WriteLine($"Error! Incorrect number of parameters. Problem \"{_name}\" expects {@case.inputs?.Length ?? 0} inputs.");
                    return;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine($"Error! An ArgumentException was thrown... This may be due to an error in your method signature. Does it match \"{_expectedParameters}\"?");
                    throw;
                }

                if (!result.Equals(@case.expectedOutput))
                {
                    @case.DisplayDiscrepancy(result);
                    return;
                }
            }

            Console.WriteLine($"SUCCESS!\n\nAll {_testCases.Length} cases passed successfully.\nHave your tutor evaluate your code before moving on to the next problem.");
        }

        public void Display()
        {
            int id = ProblemList.List.FindIndex(x => x._name == _name);

            Console.WriteLine($"Problem {id}: {_name}\nExpected method parameters: {_expectedParameters}\nExpected output type: {DisplayHelper.ForDisplay(_expectedOutput)}\n\nInstructions:\n\n{_description}");
            if (_testCases[0].inputs != null)
            {
                if (_testCases[0].expectedOutput is bool)
                {
                    _testCases.First(x => (bool)x.expectedOutput).Display();
                    _testCases.First(x => !(bool)x.expectedOutput).Display();
                }
                else
                {
                    _testCases[0].Display();
                }
            }

            if (!string.IsNullOrWhiteSpace(_specialNotes)) Console.WriteLine($"\n{_specialNotes}");
        }
    }
}