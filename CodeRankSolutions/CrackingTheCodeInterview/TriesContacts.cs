using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerrankSolutions.CrackingTheCodeInterview
{

    public class TriesContacts
    {
        static readonly ConcurrentDictionary<string, int> Letters = new ConcurrentDictionary<string, int>();

        static int _countCoincidences(string token)
        {
            int count;
            Letters.TryGetValue(token, out count);
            return count;
        }
        
        static void _addToLetters(char[] token)
        {
            for (var i = 0; i < token.Length; i++)
            {
                string str = "";
                for (var j = i; j < token.Length; j++)
                {
                    str += token[j].ToString();
                    Letters.AddOrUpdate(str, d => 1, (d, u) => u + 1);
                }
            }
        }

        static void _addToLetters(string token)
        {
            _addToLetters(token.ToCharArray());
        }

        public int[] Solve(int n, string[] orders)
        {
            var results = new List<int>();
            for (int i = 0; i < n; i++)
            {
                var order = orders[i].Split(' ');
                if (order[0] == "add")
                {
                    _addToLetters(order[1]);
                } else if (order[0] == "find")
                {
                    results.Add(_countCoincidences(order[1]));
                }
            }
            return results.ToArray();
        }

    }
}
