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
    }
}
