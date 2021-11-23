using System;

namespace CodingRange
{
    public struct TestCase
    {
        public readonly object[] inputs;
        public readonly object expectedOutput;

        public TestCase(object[] inputs, object expectedOutput)
        {
            this.inputs = inputs;
            this.expectedOutput = expectedOutput;
        }

        public void Display() => Console.WriteLine($"\nExample: {{ {DisplayHelper.ForDisplay(inputs)} }} => {DisplayHelper.ForDisplay(expectedOutput)}");

        public void DisplayDiscrepancy(object result)
        {
            Console.WriteLine("Error!");
            if (inputs is not null && inputs.Length > 0) Console.WriteLine($"Inputs: {{ {DisplayHelper.ForDisplay(inputs)} }}");
            Console.WriteLine($"Got: {DisplayHelper.ForDisplay(result)}\nExpected: {DisplayHelper.ForDisplay(expectedOutput)}");
        }
    }
}