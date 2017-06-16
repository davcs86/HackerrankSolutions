using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using HackerrankSolutions;

namespace HackerrankSolutions.Tests.CrackingTheCodeInterview
{
    /// <summary>
    /// Summary description for TiesContacts
    /// </summary>
    [TestFixture]
    public class TriesContacts: BaseTest<HackerrankSolutions.CrackingTheCodeInterview.TriesContacts>
    {
        [Test, Timeout(3000)]
        [TestCase(4, 
            new [] { "add hack", "add hackerrank", "find hac", "find hak" }, 
            ExpectedResult = new [] {2, 0}
            )]
        public int[] Solve(int a, string[] b)
        {
            return Solution.Solve(a, b);
        }
    }
}
