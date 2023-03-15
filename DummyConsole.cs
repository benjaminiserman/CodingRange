using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace CodingRange
{
    public class DummyConsole
    {
        private readonly Queue<string> _inputs = new();
        private readonly string[] _inputsCopy;
        private readonly StringBuilder _output = new();

        private readonly bool _interactive = false;

        public DummyRandom DummyRandom { private get; set; } = null;

        public DummyConsole()
        {
            _interactive = true;
        }

        public DummyConsole(params string[] inputs)
        {
            _inputsCopy = inputs;

            foreach (var s in inputs)
            {
                _inputs.Enqueue(s);
            }
        }

        public void WriteLine(object x) => Write($"{x}\n");

        public void Write(object x)
        {
            if (_interactive)
			{
				Console.Write(x);
			}
			else
			{
				_output.Append(x);
			}
		}

        public string ReadLine()
        {
            if (_interactive)
            {
                return Console.ReadLine();
            }
            
            if (_inputs.Count == 0)
            {
                Console.WriteLine("Error! No more input is available for this test case!");
                throw new Exception("Error! No more input is available for this test case!");
            }
            
            return _inputs.Dequeue();
        }

        public void DisplayExample(string expectedOutput)
        {
            Console.WriteLine("\nExample Inputs:");
            foreach (var s in _inputsCopy)
			{
				Console.WriteLine(s);
			}

			Console.WriteLine("Should Output:");
            Console.WriteLine(expectedOutput);
        }

        public bool Grade(TestCase testCase, object result, Type returnType)
        {
            if (_output.Length != 0 && _output[^1] == '\n')
			{
				_output.Remove(_output.Length - 1, 1);
			}

			if (returnType != testCase.expectedOutput.GetType())
			{
				if (returnType == typeof(void))
				{
					Console.WriteLine("Error! Method return type is void, but probably shouldn't be.");
				}
				else
				{
					Console.WriteLine("Error! Method return type isn't void, but probably should be.");
				}

				return false;
			}

			var matches = testCase.expectedOutput is string
				? Problem.IsEqual(testCase.expectedOutput, _output.ToString()) // remember, _output is StringBuilder
				: Problem.IsEqual(testCase.expectedOutput, result);

			if (!matches)
            {
                Console.WriteLine("Error!\n");

                if (DummyRandom is not null)
                {
                    Console.WriteLine($"Random Values: {DisplayHelper.ForDisplay((int[])typeof(DummyRandom).GetProperty("Outputs", (BindingFlags)(-1)).GetValue(DummyRandom), false)}");
                }

                Console.WriteLine("Inputs:");
                foreach (var s in _inputsCopy)
				{
					Console.WriteLine(s);
				}

				Console.WriteLine("Your Output:");
                if (testCase.expectedOutput is string)
				{
					Console.WriteLine(_output);
				}
				else
                {
                    if (_output.Length > 0)
                    {
                        Console.WriteLine("Debug:");
                        Console.WriteLine(_output);
                    }

                    Console.WriteLine($"Returned: {DisplayHelper.ForDisplay(result, false)}");
                }

                Console.WriteLine("Expected Output:");
                Console.WriteLine(testCase.expectedOutput is string 
                    ? testCase.expectedOutput 
                    : DisplayHelper.ForDisplay(testCase.expectedOutput, false));
            }

            return matches;
        }

        public void DisplayInputs() => Console.WriteLine(DisplayHelper.ForDisplay(_inputsCopy, false));
    }
}