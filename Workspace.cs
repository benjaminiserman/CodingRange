class Workspace
{
    #region Controls

    int problemNumber = 4; // The ID of the current problem you're working on. When you've completed your current problem, increment this by one.
    bool displayProblem = true; // Should CodingRange display problem details?
    bool evaluateAnswer = true; // Should CodingRange run & evaluate Method?

    #endregion

    int Method(int x) // This method MUST be called Method (case-sensitive) for CodingRange to pick it up.
    {
        return x;
    }
}