using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerrankSolutions.CrackingTheCodeInterview
{
    class Node
    {
        public int data = 1;
        public Dictionary<char, Node> children = new Dictionary<char, Node>();
        public Node InsertChildren(char letter)
        {
            Node childNode;
            var hasValue = children.TryGetValue(letter, out childNode);
            if (hasValue)
            {
                childNode.data++;
            }
            else
            {
                childNode = new Node();
                children.Add(letter, childNode);
            }
            return childNode;
        }
    }
    public class TriesContacts
    {
        public int[] Solve(int n, string[] orders)
        {
            var results = new List<int>();
            Node root = new Node();
            for (int i = 0; i < n; i++)
            {
                var order = orders[i].Split(' ');
                string contact = order[1];
                var currNode = root;
                if (order[0] == "add")
                {
                    // add word
                    for (int j = 0; j < contact.Length; j++)
                    {
                        currNode = currNode.InsertChildren(contact[j]);
                    }
                } else if (order[0] == "find")
                {
                    // find partial
                    var found = true;
                    var times = int.MaxValue;
                    for (int j = 0; j < contact.Length; j++)
                    {
                        var hasValue = currNode.children.TryGetValue(contact[j], out currNode);
                        if (!hasValue)
                        {
                            found = false;
                            break;
                        }
                        else
                        {
                            times = Math.Min(times, currNode.data);
                        }
                    }
                    times = found ? times : 0;
                    Console.WriteLine(times);
                    results.Add(times);
                }
            }
            return results.ToArray();
        }

    }
}
