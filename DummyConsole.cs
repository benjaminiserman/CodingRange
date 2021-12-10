using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingRange
{
    public class DummyConsole
    {
        private readonly Queue<string> _inputs = new();
        private readonly List<string> _outputs = new();
        private readonly StringBuilder _currentLine = new();

        private readonly bool _interactive = false;

        public DummyConsole()
        {
            _interactive = true;
        }

        public DummyConsole(string[] inputs)
        {
            foreach (string s in inputs)
            {
                _inputs.Enqueue(s);
            }
        }

        public void WriteLine(object x) => Write($"{x}\n");

        public void Write(object x)
        {
            string s = x.ToString();
            string[] split = s.Split('\n');

            _currentLine.Append(split[0]);

            FinWrite(_currentLine.ToString());
            _currentLine.Clear();

            foreach (string y in split[1..^1])
            {
                FinWrite(y);
            }

            if (s[^1] == '\n')
            {
                FinWrite(split[^1]);
            }
            else _currentLine.Append(s[^1]);

            void FinWrite(string s)
            {
                _outputs.Add(s);
                Console.WriteLine(s);
            }
        }

        public void ReadLine() => _inputs.Dequeue();

        private List<string> Output()
        {
            string sb = _currentLine.ToString();

            if (sb != string.Empty)
            {
                _outputs.Add(sb);
            }

            return _outputs;
        }

        public bool Grade(string[] expectedOutput)
        {
            bool equal = _outputs.Count == expectedOutput.Length && !_outputs.Zip(expectedOutput, (x, y) => x == y).Any(x => !x);

            if (!equal)
            {
                Console.WriteLine("Error!");
                Console.WriteLine("Inputs:");
                foreach (string s in _inputs) Console.WriteLine(s);
                Console.WriteLine("Got:");
                foreach (string s in _outputs) Console.WriteLine(s);
                Console.WriteLine("Expected:");
                foreach (string s in expectedOutput) Console.WriteLine(s);
            }

            return equal;
        }
    }
}