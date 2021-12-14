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

            foreach (string s in inputs)
            {
                _inputs.Enqueue(s);
            }
        }

        public void WriteLine(object x) => Write($"{x}\n");

        public void Write(object x)
        {
            if (_interactive) Console.Write(x);
            else _output.Append(x);
        }

        public string ReadLine() => _interactive ? Console.ReadLine() : _inputs.Dequeue();

        public void DisplayExample(string expectedOutput)
        {
            Console.WriteLine("\nExample Inputs:");
            foreach (string s in _inputsCopy) Console.WriteLine(s);
            Console.WriteLine("Should Output:");
            Console.WriteLine(expectedOutput);
        }

        public bool Grade(string expectedOutput)
        {
            if (_output[^1] == '\n')
            {
                //Console.WriteLine();
                _output.Remove(_output.Length - 1, 1);
            }

            if (expectedOutput != _output.ToString())
            {
                Console.WriteLine("Error!\n");

                if (DummyRandom is not null)
                {
                    Console.WriteLine($"Random Values: {DisplayHelper.ForDisplay((int[])typeof(DummyRandom).GetProperty("Outputs", (BindingFlags)(-1)).GetValue(DummyRandom), false)}");
                }

                Console.WriteLine("Inputs:");
                foreach (string s in _inputsCopy) Console.WriteLine(s);

                Console.WriteLine("Your Output:");
                Console.WriteLine(_output);

                Console.WriteLine("Expected Output:");
                Console.WriteLine(expectedOutput);

                return false;
            }

            return true;
        }
    }
}