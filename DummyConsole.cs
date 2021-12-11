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

        public DummyConsole()
        {
            _interactive = true;
        }

        public DummyConsole(params string[] inputs)
        {
            _inputsCopy = inputs;

            foreach (string s in inputs)
            {
                _inputs.Enqueue(s);
            }
        }

        public void WriteLine(object x) => Write($"{x}\n");

        public void Write(object x)
        {
            _output.Append(x);
            Console.Write(x);
        }

        public string ReadLine() => _interactive ? Console.ReadLine() : _inputs.Dequeue();

        public void DisplayExample()
        {
            Console.WriteLine("Example Inputs:");
            foreach (string s in _inputsCopy) Console.WriteLine(s);
            Console.WriteLine("Should Output:");
            // $$$
        }

        public bool Grade(string expectedOutput, DummyRandom dummyRandom = null)
        {
            if (_output[^1] == '\n')
            {
                Console.WriteLine();
                _output.Remove(_output.Length - 1, 1);
            }

            if (expectedOutput != _output.ToString())
            {
                Console.WriteLine("Error!\n");
                Console.WriteLine("Inputs:");
                foreach (string s in _inputsCopy) Console.WriteLine(s);
                if (dummyRandom is not null)
                {
                    Console.WriteLine($"Random Values: {DisplayHelper.ForDisplay((int[])typeof(DummyRandom).GetProperty("Outputs", (BindingFlags)(-1)).GetValue(dummyRandom), false)}");
                }
                //Console.WriteLine("Got:");
                //foreach (string s in _outputs) Console.WriteLine(s);
                Console.WriteLine("Expected:");
                Console.WriteLine(expectedOutput);

                return false;
            }

            return true;
        }
    }
}