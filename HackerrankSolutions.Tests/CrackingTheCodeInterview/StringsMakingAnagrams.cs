using System;
using NUnit.Framework;
using HackerrankSolutions;

namespace HackerrankSolutions.Tests.CrackingTheCodeInterview
{
    [TestFixture]
    public class StringsMakingAnagrams: BaseTest<HackerrankSolutions.CrackingTheCodeInterview.StringsMakingAnagrams>
    {
        [Test, Timeout(3000)]
        [TestCase("abc", "cde", ExpectedResult=4)]
        [TestCase("abc", "bcd", ExpectedResult=2)]
        public int Solve(string a, string b)
        {
            return Solution.Solve(a, b);
        }
    }
}
