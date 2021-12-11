using System;
using System.Collections;
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
            Console.WriteLine("\nOutput:");
            if (_testCases[0].inputs.Length == 0 || _testCases[0].inputs[0] is not DummyConsole) Console.WriteLine();

            foreach (var testCase in _testCases)
            {
                object result;

                object[] inputsCopy = new object[testCase.inputs?.Length ?? 0];
                for (int i = 0; i < inputsCopy.Length; i++)
                {
                    if (testCase.inputs[i] is ICloneable cloneable)
                    {
                        inputsCopy[i] = cloneable.Clone(); // please god tell me this works
                    }
                    else
                    {
                        inputsCopy[i] = testCase.inputs[i];
                    }
                }    

                try
                {
                    result = method.Invoke(new Workspace(), inputsCopy);
                }
                catch (TargetParameterCountException)
                {
                    Console.WriteLine($"Error! Incorrect number of parameters. Problem \"{_name}\" expects {testCase.inputs?.Length ?? 0} inputs.");
                    return;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine($"Error! An ArgumentException was thrown... This may be due to an error in your method signature. Does it match \"{_expectedParameters}\"?");
                    return;
                }

                if ((testCase.inputs?.Length ?? 0) > 0 && testCase.inputs[0] is DummyConsole dummy)
                {
                    if (testCase.inputs.Length >= 2 && testCase.inputs[1] is DummyRandom random) dummy.DummyRandom = random;
                    if (!(bool)typeof(DummyConsole).GetMethod("Grade", (BindingFlags)(-1)).Invoke(dummy, new[] { testCase.expectedOutput })) return;
                }
                else if (!IsEqual(result, testCase.expectedOutput))
                {
                    testCase.DisplayDiscrepancy(result);
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
                    _testCases.First(x => (bool)x.expectedOutput).DisplayExample();
                    _testCases.First(x => !(bool)x.expectedOutput).DisplayExample();
                }
                else
                {
                    _testCases[0].DisplayExample();
                }
            }

            if (!string.IsNullOrWhiteSpace(_specialNotes)) Console.WriteLine($"\n{_specialNotes}");
        }

        public bool IsInteractive => _testCases?[0].inputs?[0] is DummyConsole and not null;

        public Type[] GetParameterTypes()
        {
            if (_testCases[0].inputs.Length == 0) return null;

            return (from x in _testCases[0].inputs select x.GetType()).ToArray();
        }

        private bool IsEqual(object x, object y)
        {
            if (x.GetType() != y.GetType()) return false;

#pragma warning disable IDE0038, IDE0020 // Use pattern matching // disabled to maintain parallel structure
            if (x is string) return x.Equals(y);
            else if (x is ICollection)
            {
                ICollection xCollection = (ICollection)x;
                ICollection yCollection = (ICollection)y;

                if (xCollection.Count != yCollection.Count) return false;

                return !xCollection.Cast<object>().Zip(yCollection.Cast<object>(), (a, b) => IsEqual(a, b)).Any(equal => !equal);
            }
            else if (x is float) return Math.Abs((float)x - (float)y) <= 0.0000001f;
            else if (x is double) return Math.Abs((double)x - (double)y) <= 0.0000001d;
            else if (x is decimal) return Math.Abs((decimal)x - (decimal)y) <= 0.0000001m;
#pragma warning restore IDE0038, IDE0020 // Use pattern matching

            return x.Equals(y);
        }
    }
}