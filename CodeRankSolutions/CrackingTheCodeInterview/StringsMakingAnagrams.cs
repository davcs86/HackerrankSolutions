using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HackerrankSolutions.CrackingTheCodeInterview
{
    public class StringsMakingAnagrams
    {
        private static Dictionary<string, int> _stringToDict(string s)
        {
            return s.ToCharArray().GroupBy(t => t.ToString(), t => 1).ToDictionary(t => t.Key, t => t.Count());
        }
        public int Solve(string a, string b)
        {
            var a1 = _stringToDict(a);
            var b1 = _stringToDict(b);
            var total = a.Length + b.Length;
            foreach (KeyValuePair<string, int> it in a1)
            {
                int countB1;
                var hasValue = b1.TryGetValue(it.Key, out countB1);
                if (hasValue)
                {
                    total -= Math.Min(countB1, it.Value)*2;
                }
            }
            return total;
        }

    }
}
