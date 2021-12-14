using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingRange
{
    public class DummyRandom
    {
        private readonly Random _random;
        private readonly (int, int, int)[] _outputs;
        private readonly Queue<(int, int, int)> _queue;

        private readonly bool _interactive = false;

        public DummyRandom()
        {
            _interactive = true;
            _random = new();
        }

        public DummyRandom(params (int, int, int)[] outputs)
        {
            _queue = new();
            _outputs = outputs;

            foreach (var x in outputs)
            {
                _queue.Enqueue(x);
            }
        }

        public int Next(int max) => Next(0, max);

        public int Next(int min, int max)
        {
            if (_interactive)
            {
                return _random.Next(min, max);
            }
            else if (_queue.Count == 0)
            {
                throw new Exception("Error! No more random values are available for this test case!");
            }
            else 
            {
                (int fMin, int fMax, int x) = _queue.Dequeue();

                if (fMin != min || fMax != max)
                {
                    throw new ArgumentException($"You called Next({min}, {max}) but backend expected Next({fMin}, {fMax})!");
                }

                return x;
            }
        }

        private int[] Outputs => (from x in _outputs select x.Item3).ToArray();
    }
}