using System;
using NUnit.Framework;
using HackerrankSolutions;

namespace HackerrankSolutions.Tests.CrackingTheCodeInterview
{
    class HeapsFindTheMedian : BaseTest<HackerrankSolutions.CrackingTheCodeInterview.HeapsFindTheMedian>
    {
        [Test, Timeout(3000)]
        [TestCase(10, new []{1, 2, 3, 4, 5, 6, 7, 8, 9, 10}, ExpectedResult = new[] { 1.0, 1.5, 2.0, 2.5, 3.0, 3.5, 4.0, 4.5, 5.0, 5.5 })]
        [TestCase(9, new [] { 94455, 20555, 20535, 53125, 73634, 148, 63772, 17738, 62995 }, ExpectedResult = new[] { 94455.0, 57505.0, 20555.0, 36840.0, 53125.0, 36840.0, 53125.0, 36840.0, 53125.0 })]
        public double[] Solve(int a, int[] b)
        {
            return Solution.Solve(a, b);
        }
    }
}
