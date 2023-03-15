using System;

namespace CodingRange
{
    public readonly struct TestCase
    {
        public readonly object[] inputs;
        public readonly object expectedOutput;

        public TestCase(object[] inputs, object expectedOutput)
        {
            this.inputs = inputs;
            this.expectedOutput = expectedOutput;
        }

        public void DisplayExample()
        {
            var exampleInputs = DisplayHelper.ForDisplay(inputs, true);
            var exampleOutputs = DisplayHelper.ForDisplay(expectedOutput, false);

			Console.WriteLine($"\nExample: {exampleInputs} => {exampleOutputs}");
        }

        public void DisplayDiscrepancy(object result)
        {
            Console.WriteLine("Error!");
            if (inputs is not null && inputs.Length > 0)
			{
				Console.WriteLine($"Inputs: {DisplayHelper.ForDisplay(inputs, true)}");
			}

			Console.WriteLine($"Got: {DisplayHelper.ForDisplay(result, false)}");
            Console.WriteLine($"Expected: {DisplayHelper.ForDisplay(expectedOutput, false)}");
        }
    }
}