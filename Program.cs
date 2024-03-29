﻿using System;
using System.Linq;
using System.Reflection;

namespace CodingRange
{
    internal class Program
    {
        private static void Main()
        {
            Workspace workspace = new();

			// all this reflection is done so we can hide visiblity modifiers from new students for the time being
			var method = typeof(Workspace).GetMethod("Method", (BindingFlags)(-1)); 

            var problemNumber = (int)typeof(Workspace)
                .GetField("problemNumber", (BindingFlags)(-1))
                .GetValue(workspace);
            var displayProblem = (bool)typeof(Workspace)
                .GetField("displayProblem", (BindingFlags)(-1))
                .GetValue(workspace);
            var evaluateAnswer = (bool)typeof(Workspace)
                .GetField("evaluateAnswer", (BindingFlags)(-1))
                .GetValue(workspace);

            if (problemNumber == ProblemList.List.Count)
            {
                Console.WriteLine("It seems you've completed all available problems! Ask Ben if you want more.");
                return;
            }
            else if (problemNumber < 0 
                || problemNumber > ProblemList.List.Count)
            {
                Console.WriteLine($"Invalid problem number added! Problems range from (0-{ProblemList.List.Count - 1})");
                return;
            }

            if (displayProblem)
            {
                ProblemList.List[problemNumber].Display();
            }

            if (evaluateAnswer)
            {
                ProblemList.List[problemNumber].Evaluate(method);
            }
            else if (ProblemList.List[problemNumber].IsInteractive)
            {
                Console.WriteLine("Running in INTERACTIVE mode.");
                var types = ProblemList.List[problemNumber].GetParameterTypes();
                var parameters = (from t in types select Activator.CreateInstance(t)).ToArray();

                method.Invoke(workspace, parameters);
            }
            
            if (!displayProblem && !evaluateAnswer)
			{
				Console.WriteLine("Nothing to display. Enable either displayProblem or evaluateAnswer.");
			}
		}
    }
}