namespace mergesort
{
    public class IntMergeSort
    {
        public int[] MergeSort(int[] A, int p, int r)
        {
            if (p < r)
            {
                var q = (p + r) / 2;
                MergeSort(A, p, q);
                MergeSort(A, q + 1, r);
                Merge(A, p, q, r);
            }

            return A;
        }

        private void Merge(int[] A, int p, int q, int r)
        {
            var n1 = q - p + 1;
            var n2 = r - q;

            var L = new int[n1 + 1];
            var R = new int[n2 + 1];

            for (int i = 1; i < n1; i++)
            {
                L[i] = A[p + i - 1];
            }

            for (int j = 1; j < n2; j++)
            {
                R[j] = A[q + j];
            }

            L[n1 + 1] = int.MaxValue;
            R[n2 + 1] = int.MaxValue;

            var ci = 1;
            var cj = 1;

            for (int k = p; k < r; k++)
            {
                if (L[ci] <= R[ci])
                {
                    A[k] = L[ci];
                    ci++;
                }
                else
                {
                    A[k] = R[cj];
                    cj++;
                }
            }
        }
    }
}