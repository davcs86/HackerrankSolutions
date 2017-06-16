using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackerrankSolutions.CrackingTheCodeInterview.HeapsAux;

namespace HackerrankSolutions.CrackingTheCodeInterview
{
    public class HeapsFindTheMedian
    {
        private static MaxHeap leftList = new MaxHeap();
        private static MinHeap rightList = new MinHeap();
        private static double _median;
        //static private int size = 0;
        static int GetOperation()
        {
            int minCount = leftList.Values.Count;
            int maxCount = rightList.Values.Count;
            if (minCount == maxCount) return 0;
            return minCount < maxCount ? 1 : -1;
        }
        static double GetAverage()
        {
            int minVal = leftList.GetTop();
            int maxVal = rightList.GetTop();
            return (minVal + maxVal) / 2.0;
        }
        static void InsertNextNumber(int n)
        {
            //size++;
            var operation = GetOperation();
            switch (operation)
            {
                case 0:
                    if (n < _median)
                    {
                        leftList.Add(n);
                        _median = leftList.GetTop();
                    }
                    else
                    {
                        rightList.Add(n);
                        _median = rightList.GetTop();
                    }
                    break;
                case 1:
                    // rightList is larger
                    if (n < _median)
                    {
                        leftList.Add(n);
                    }
                    else
                    {
                        int maxVal = rightList.GetTop();
                        rightList.DeleteTop();
                        leftList.Add(maxVal);
                        rightList.Add(n);
                    }
                    _median = GetAverage();
                    break;
                case -1:
                    // leftList is larger
                    if (n < _median)
                    {
                        int minVal = leftList.GetTop();
                        leftList.DeleteTop();
                        rightList.Add(minVal);
                        leftList.Add(n);
                    }
                    else
                    {
                        rightList.Add(n);
                    }
                    _median = GetAverage();
                    break;
            }
        }
        public double[] Solve(int n, int[] numbers)
        {
            var results = new List<double>();
            for (int i = 0; i < n; i++)
            {
                int newValue = numbers[i];
                InsertNextNumber(newValue);
                Console.WriteLine("[{0}], {1}", String.Join(" ", leftList.Values), newValue);
                Console.WriteLine("[{0}], {1}", String.Join(" ", rightList.Values), newValue);
                Console.WriteLine("{0:0.0}", _median);
                results.Add(_median);
            }
            return results.ToArray();
        }
    }
}
