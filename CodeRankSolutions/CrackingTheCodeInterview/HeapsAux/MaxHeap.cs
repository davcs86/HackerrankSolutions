namespace HackerrankSolutions.CrackingTheCodeInterview.HeapsAux
{
    class MaxHeap : MinHeap
    {
        protected override bool Comparer(int a, int b)
        {
            return a < b;
        }
    }
}