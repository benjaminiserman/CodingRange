using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;

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

                object[] inputsCopy = new object[@case.inputs?.Length ?? 0];
                for (int i = 0; i < inputsCopy.Length; i++)
                {
                    if (@case.inputs[i] is ICloneable cloneable)
                    {
                        inputsCopy[i] = cloneable.Clone(); // please god tell me this works
                    }
                    else
                    {
                        inputsCopy[i] = @case.inputs[i];
                    }
                }    

                try
                {
                    result = method.Invoke(new Workspace(), inputsCopy);
                }
                catch (TargetParameterCountException)
                {
                    Console.WriteLine($"Error! Incorrect number of parameters. Problem \"{_name}\" expects {@case.inputs?.Length ?? 0} inputs.");
                    return;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine($"Error! An ArgumentException was thrown... This may be due to an error in your method signature. Does it match \"{_expectedParameters}\"?");
                    return;
                }

                if (@case.inputs[0] is DummyConsole dummy)
                {
                    if (!(bool)typeof(DummyConsole).GetMethod("Grade", (BindingFlags)(-1)).Invoke(dummy, new[] { @case.expectedOutput })) return;
                }
                else if (!IsEqual(result, @case.expectedOutput))
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

            Console.WriteLine($"Problem {id}: {_name}\nExpected method parameters: {_expectedParameters}\nExpected output type: {DisplayHelper.ForDisplay(_expectedOutput, false)}\n\nInstructions:\n\n{_description}");
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

        public bool IsInteractive => _testCases?[0].inputs?[0] is DummyConsole and not null;

        private bool IsEqual(object x, object y)
        {
            if (x.GetType() != y.GetType()) return false;
            if (x is string) return x == y;
            if (x is IEnumerable && y is IEnumerable)
            {
                string sx = JsonSerializer.Serialize(x);
                string sy = JsonSerializer.Serialize(y);

                return sx == sy;
            }
            return x.Equals(y);
        }
    }
}