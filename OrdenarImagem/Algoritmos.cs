using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenarImagem
{
    internal class Algoritmos
    {
        // //////////////////////////////////////////////////////
        private const bool ASCENDING = true;

        private readonly string PIVOT_FIRST = "Primeiro";
        private readonly string PIVOT_LAST = "Último";
        private readonly string PIVOT_MEDIAN3 = "Mediana";
        private readonly string PIVOT_MID = "Médio";
        private readonly string PIVOT_RANDOM = "Aleatório";
        private string g_quicksort_pivot;
        private ArrayItem[] vetor;

        public bool mostrar;

        //public Algoritmos(System.Windows.Forms.PictureBox pic)
        //{
        //p = pic;
        //}

        public Algoritmos(ArrayItem[]? v)
        {
            if (v == null)
                vetor = Array.Empty<ArrayItem>();
            else
                vetor = v;

            g_quicksort_pivot = "";
        }

        private void Swap(int a, int b)
        {
            ArrayItem c;
            c = vetor[a];
            vetor[a] = vetor[b];
            vetor[b] = c;
            vetor[a].Indice = a;
            vetor[b].Indice = b;
            vetor[a].Mudou = true;
            vetor[b].Mudou = true;
            Application.DoEvents();
        }

        private static int Comp(int v1, int v2)
        {
            return (v1 == v2 ? 0 : v1 < v2 ? -1 : +1);
        }

        private static int GreatestPowerOfTwoLessThan(int n)
        {
            int k = 1;
            while (k < n)
            {
                k <<= 1;
            }

            return k >> 1;
        }

        public void SetVetor(ArrayItem[]? v)
        {
            if (v == null)
                vetor = Array.Empty<ArrayItem>();
            else
                vetor = v;
        }


        #region Algoritmos de Ordenação
        // //////////////////////////////////////////////////////
        public void BinaryInsertionSort()
        {
            for (int i = 1; i < vetor.Length; ++i)
            {
                int key = vetor[i].Valor;
                int lo = 0, hi = i;
                while (lo < hi)
                {
                    int mid = (lo + hi) / 2;
                    if (key <= vetor[mid].Valor)
                    {
                        hi = mid;
                    }
                    else
                    {
                        lo = mid + 1;
                    }
                }
                // item has to go into position lo

                int j = i - 1;
                while (j >= lo)
                {
                    Swap(j, j + 1);
                    j--;
                }
                ////ChecaSegmentos();
            }
        }
        // //////////////////////////////////////////////////////
        public void BitonicSort()
        {
            BitonicSort(0, vetor.Length, ASCENDING);
        }

        private void Bitonic_compare(int i, int j, bool dir)
        {
            if (dir == (vetor[i].CompareTo(vetor[j]) == 1))
            {
                Swap(i, j);
            }
        }

        private void BitonicMerge(int lo, int n, bool dir)
        {
            if (n > 1)
            {
                int m = GreatestPowerOfTwoLessThan(n);
                for (int i = lo; i < lo + n - m; i++)
                {
                    Bitonic_compare(i, i + m, dir);
                }

                BitonicMerge(lo, m, dir);
                BitonicMerge(lo + m, n - m, dir);
            }
        }

        private void BitonicSort(int lo, int n, bool dir)
        {
            if (n > 1)
            {
                int m = n / 2;
                BitonicSort(lo, m, !dir);
                BitonicSort(lo + m, n - m, dir);
                BitonicMerge(lo, n, dir);
            }
        }
        // //////////////////////////////////////////////////////
        public void BubbleSort()
        {
            ////ChecaSegmentos();
            for (int i = 0; i < vetor.Length - 1; ++i)
            {
                for (int j = 0; j < vetor.Length - 1 - i; ++j)
                {
                    if (vetor[j].CompareTo(vetor[j + 1]) == 1)
                    {
                        Swap(j, j + 1);
                    }
                }
            }
        }
        // //////////////////////////////////////////////////////
        public void BubbleSort2()
        {
            int i;
            int j;
            int max;
            int maxidx = 0;
            for (i = vetor.Length - 1; i >= 0; i--)
            {
                max = 0;
                for (j = 0; j < i; j++)
                {

                    if (max < vetor[j].Valor)
                    {
                        max = vetor[j].Valor;
                        maxidx = j;
                    }
                }
                if (vetor[i].CompareTo(vetor[maxidx]) == -1)
                {
                    Swap(i, maxidx);
                }
            }
            //ChecaSegmentos();
        }
        // //////////////////////////////////////////////////////
        public void BubbleSort3()
        {
            int i;
            //int j;
            int max;
            int maxidx = 0;
            int minidx = vetor.Length - 1;
            int min;
            int inicio = 0;
            int final = vetor.Length;

            while (inicio < final)
            {
                max = 0;
                min = vetor.Max().Valor + 1;
                for (i = inicio; i < final; i++)
                {
                    if (max < vetor[i].Valor)
                    {
                        max = vetor[i].Valor;
                        maxidx = i;
                    }
                    if (min > vetor[i].Valor)
                    {
                        min = vetor[i].Valor;
                        minidx = i;
                    }
                }
                if (vetor[final - 1].CompareTo(vetor[maxidx]) == -1)
                {
                    Swap(maxidx, final - 1);

                    if ((final - 1) == minidx)
                    {
                        minidx = maxidx;
                    }
                }
                if (vetor[inicio].CompareTo(vetor[minidx]) == 1)
                {
                    Swap(minidx, inicio);
                }
                final--;
                inicio++;
            }
        }
        // //////////////////////////////////////////////////////
        public void CocktailShakerSort()
        {
            int lo = 0;
            int hi = vetor.Length - 1;
            int mov = lo;

            //ChecaSegmentos();
            while (lo < hi)
            {
                for (int i = hi; i > lo; --i)
                {
                    if (vetor[i - 1].CompareTo(vetor[i]) == 1)
                    {
                        Swap(i - 1, i);
                        mov = i;
                    }
                }
                lo = mov;

                for (int i = lo; i < hi; ++i)
                {
                    if (vetor[i].CompareTo(vetor[i + 1]) == 1)
                    {
                        Swap(i, i + 1);
                        mov = i;
                    }
                }
                hi = mov;
            }
        }
        // //////////////////////////////////////////////////////
        public void CombSort()
        {
            const double shrink = 1.3;

            bool swapped = false;
            int gap = vetor.Length;
            //ChecaSegmentos();
            while ((gap > 1) || swapped)
            {
                if (gap > 1)
                {
                    gap = (int)((float)gap / shrink);
                }

                swapped = false;

                for (int i = 0; gap + i < vetor.Length; ++i)
                {
                    if (vetor[i].CompareTo(vetor[i + gap]) == 1)
                    {
                        Swap(i, i + gap);
                        swapped = true;
                    }
                }
            }
        }
        // //////////////////////////////////////////////////////
        public void CountingSort()
        {
            int max = vetor.Length - 1;
            int mc = vetor.Max().Valor;
            long[] cnt = new long[mc + 1];
            ArrayItem[] b = new ArrayItem[max + 1];
            long idx;

            //ChecaSegmentos();
            cnt.Initialize();
            int j;
            for (j = 0; j <= max; j++)
            {
                int l = vetor[j].Valor;
                cnt[l]++;
                b[j] = vetor[j];
            }
            for (int i = 1; i <= mc; i++)
            {
                cnt[i] = cnt[i] + cnt[i - 1];
            }
            for (j = max; j >= 0; j--)
            {
                idx = vetor[j].Valor;
                b[cnt[idx] - 1] = vetor[j];
                cnt[idx]--;
            }
            for (j = 0; j <= max; j++)
            {
                vetor[j] = b[j];
                vetor[j].Indice = j;
                vetor[j].Mudou = true;
                Application.DoEvents();
            }
        }
        // //////////////////////////////////////////////////////
        public void CycleSort()
        {
            int cycle_start;
            ArrayItem tmp;
            Color c;
            int tmpidx;
            //ChecaSegmentos();
            for (cycle_start = 0; cycle_start < vetor.Length - 1; cycle_start++)
            {
                ArrayItem item = vetor[cycle_start];
                int pos = cycle_start;

                for (int i = cycle_start + 1; i < vetor.Length; i++)
                {
                    if (vetor[i].Valor < item.Valor)
                    {
                        pos++;
                    }
                }

                if (pos != cycle_start)
                {
                    while (item.Valor == vetor[pos].Valor)
                    {
                        pos++;
                    }

                    tmp = vetor[pos];
                    vetor[pos] = item;
                    vetor[pos].Indice = pos;
                    vetor[pos].Mudou = true;
                    Application.DoEvents();
                    item = tmp;
                    item.Mudou = false;

                    while (pos != cycle_start)
                    {
                        pos = cycle_start;
                        for (int i = cycle_start + 1; i < vetor.Length; i++)
                        {
                            if (vetor[i].Valor < item.Valor)
                            {
                                pos++;
                            }

                        }
                        while (item.Valor == vetor[pos].Valor)
                        {
                            pos++;
                        }
                        tmp = vetor[pos];
                        vetor[pos] = item;
                        vetor[pos].Indice = pos;
                        vetor[pos].Mudou = true;
                        Application.DoEvents();
                        item = tmp;
                        item.Mudou = false;
                    }
                }
            }
        }
        // //////////////////////////////////////////////////////
        public void FlashSort(int length)
        {

            int m = (int)((0.2 * length) + 2);
            int min, max, maxIndex;
            min = max = vetor[0].Valor;
            maxIndex = 0;

            for (int i = 1; i < length - 1; i += 2)
            {
                int small;
                int big;
                int bigIndex;

                if (vetor[i].Valor < vetor[i + 1].Valor)
                {
                    small = vetor[i].Valor;
                    big = vetor[i + 1].Valor;
                    bigIndex = i + 1;
                }
                else
                {
                    big = vetor[i].Valor;
                    bigIndex = i;
                    small = vetor[i + 1].Valor;
                }

                if (big > max)
                {
                    max = big;
                    maxIndex = bigIndex;
                }

                if (small < min)
                {
                    min = small;
                }
            }
            if (vetor[length - 1].Valor < min)
            {
                min = vetor[length - 1].Valor;
            }
            else if (vetor[length - 1].Valor > max)
            {
                max = vetor[length - 1].Valor;
                maxIndex = length - 1;
            }

            if (max == min)
            {
                return;
            }

            int[] L = new int[m + 1];

            for (int t = 1; t <= m; t++)
            {
                L[t] = 0;
            }
            double c = (m - 1.0) / (max - min);
            int K;
            for (int h = 0; h < length; h++)
            {
                K = ((int)((vetor[h].Valor - min) * c)) + 1;
                L[K] += 1;
            }
            for (K = 2; K <= m; K++)
            {
                L[K] = L[K] + L[K - 1];
            }
            Swap(maxIndex, 0);
            int j = 0;
            K = m;
            int numMoves = 0;
            while (numMoves < length)
            {
                while (j >= L[K])
                {
                    j++;
                    K = ((int)((vetor[j].Valor - min) * c)) + 1;
                }
                int evicted = vetor[j].Valor;
                while (j < L[K])
                {
                    K = ((int)((evicted - min) * c)) + 1;
                    int location = L[K] - 1;
                    (evicted, vetor[location].Valor) = (vetor[location].Valor, evicted);
                    L[K] -= 1;
                    numMoves++;
                }
            }
            InsertSort();
        }

        public void FlashSort()
        {

            FlashSort(vetor.Length);

        }
        // //////////////////////////////////////////////////////
        public void GnomeSort()
        {
            //ChecaSegmentos();
            for (int i = 1; i < vetor.Length;)
            {
                if (vetor[i].CompareTo(vetor[i - 1]) >= 0)
                {
                    ++i;
                }
                else
                {
                    Swap(i, i - 1);
                    if (i > 1)
                    {
                        --i;
                    }
                }
            }
        }
        /// ////////////////////////////////////////////////////////////////////////////////////////
        public void HeapSort()
        {
            int n = vetor.Length, i = n / 2;
            //ChecaSegmentos();

            while (true)
            {
                if (i > 0)
                {
                    // build heap, sift A[i] down the heap
                    i--;
                }
                else
                {

                    // pop largest element from heap: swap front to back, and sift
                    // front A[0] down the heap
                    n--;
                    if (n == 0)
                    {
                        return;
                    }

                    Swap(0, n);
                }

                int parent = i;
                int child = i * 2 + 1;

                // sift operation - push the value of A[i] down the heap
                while (child < n)
                {
                    if (child + 1 < n && (vetor[child + 1].CompareTo(vetor[child]) == 1))
                    {
                        child++;
                    }
                    if (vetor[child].CompareTo(vetor[parent]) == 1)
                    {
                        Swap(parent, child);
                        parent = child;
                        child = parent * 2 + 1;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
        // //////////////////////////////////////////////////////
        public void InsertSort()
        {
            //ChecaSegmentos();
            for (int i = 1; i < vetor.Length; ++i)
            {
                int key = vetor[i].Valor;

                int j = i - 1;
                while (j >= 0 && vetor[j].Valor > key)
                {
                    Swap(j, j + 1);
                    j--;
                }
            }
        }
        // //////////////////////////////////////////////////////
        public void InsertSort2()
        {
            for (int i = 1; i < vetor.Length; ++i)
            {
                ArrayItem tmp;
                    ArrayItem key = vetor[i];
                key.Mudou = false;
                int j = i - 1;
                while (j >= 0 && (tmp = vetor[j]).Valor > key.Valor)
                {
                    tmp.Mudou = false;
                    vetor[j + 1] = tmp;
                    vetor[j + 1].Mudou = true;
                    Application.DoEvents();
                    j--;
                }
                vetor[j + 1] = key;
                vetor[j + 1].Mudou = true;
                Application.DoEvents();
            }
        }
        // //////////////////////////////////////////////////////
        public void OddEvenSort()
        {
            bool sorted = false;
            while (!sorted)
            {
                sorted = true;

                for (int i = 1; i < vetor.Length - 1; i += 2)
                {
                    if (vetor[i].CompareTo(vetor[i + 1]) == 1)
                    {
                        Swap(i, i + 1);
                        sorted = false;
                    }
                }

                for (int i = 0; i < vetor.Length - 1; i += 2)
                {
                    if (vetor[i].CompareTo(vetor[i + 1]) == 1)
                    {
                        Swap(i, i + 1);
                        sorted = false;
                    }
                }
            }
        }
        // //////////////////////////////////////////////////////
        private void Flip(int k)
        {
            int left = 0;
            while (left < k)
            {
                Swap(k, left);
                k--;
                left++;
            }
        }

        private int MaxIndex(int k)
        {
            int index = 0;
            for (int i = 0; i < k; i++)
            {
                if (vetor[i].CompareTo(vetor[index]) == 1)
                {
                    index = i;
                }
            }
            return index;
        }

        public void PancakeSort(int n)
        {
            int maxdex;
            while (n > 1)
            {
                maxdex = MaxIndex(n);
                if (maxdex != n)
                {
                    Flip(maxdex);
                    Flip(n - 1);
                }
                n--;
            }
        }

        public void PancakeSort()
        {
            //ChecaSegmentos();
            PancakeSort(vetor.Length);
        }
        // //////////////////////////////////////////////////////
        public void pigeonholeSort()
        {
            int min = vetor[0].Valor;
            int max = vetor[0].Valor;
            int range, i, j, index;
            int n = vetor.Length;

            for (int a = 0; a < n; a++)
            {
                if (vetor[a].Valor > max)
                {
                    max = vetor[a].Valor;
                }
                if (vetor[a].Valor < min)
                {
                    min = vetor[a].Valor;
                }
            }

            range = max - min + 1;
            int[] pigeonHoles = new int[range];

            for (i = 0; i < n; i++)
            {
                pigeonHoles[vetor[i].Valor - min]++;
            }

            index = 0;

            for (j = 0; j < range; j++)
            {
                while (pigeonHoles[j]-- > 0)
                {
                    vetor[index++].Valor = j + min;
                    Application.DoEvents();
                }
            }
            return;
        }
        // //////////////////////////////////////////////////////
        public void SetQuickSortPivot(string q)
        {
            g_quicksort_pivot = q;
        }

        public void QuickSortDualPivot()
        {
            QuickSortDualPivotYaroslavskiy(0, vetor.Length - 1);
        }

        public void QuickSortLL()
        {
            QuickSortLL(0, vetor.Length);
        }

        public void QuickSortLR()
        {
            QuickSortLR(0, vetor.Length - 1);
        }

        public void QuickSortTernaryLR()
        {
            QuickSortTernaryLR(0, vetor.Length - 1);
        }

        private void QuickSortDualPivotYaroslavskiy(int left, int right)
        {
            //ChecaSegmentos();

            if (right > left)
            {
                if (vetor[left].CompareTo(vetor[right]) == 1)
                {
                    Swap(left, right);
                }

                int p1 = vetor[left].Valor;
                int q = vetor[right].Valor;

                int l = left + 1;
                int g = right - 1;
                int k = l;

                while (k <= g)
                {
                    if (vetor[k].Valor < p1)
                    {
                        Swap(k, l);
                        ++l;
                    }
                    else if (vetor[k].Valor >= q)
                    {
                        while (vetor[g].Valor > q && k < g)
                        {
                            --g;
                        }

                        Swap(k, g);
                        --g;

                        if (vetor[k].Valor < p1)
                        {
                            Swap(k, l);
                            ++l;
                        }
                    }
                    ++k;
                }
                --l;
                ++g;
                Swap(left, l);
                Swap(right, g);

                QuickSortDualPivotYaroslavskiy(left, l - 1);
                QuickSortDualPivotYaroslavskiy(l + 1, g - 1);
                QuickSortDualPivotYaroslavskiy(g + 1, right);
            }
        }

        private int QuickSortSelectPivot(int lo, int hi)
        {
            Random rnd = new();
            if (g_quicksort_pivot == PIVOT_FIRST)
            {
                return lo;
            }

            if (g_quicksort_pivot == PIVOT_LAST)
            {
                return hi - 1;
            }

            if (g_quicksort_pivot == PIVOT_MID)
            {
                return (lo + hi) / 2;
            }

            if (g_quicksort_pivot == PIVOT_RANDOM)
            {
                return lo + (rnd.Next() % (hi - lo));
            }

            if (g_quicksort_pivot == PIVOT_MEDIAN3)
            {
                int mid = (lo + hi) / 2;

                // cases if two are equal
                if (vetor[lo].CompareTo(vetor[mid]) == 0)
                {
                    return lo;
                }

                if (vetor[lo].CompareTo(vetor[hi - 1]) == 0 || vetor[mid].CompareTo(vetor[hi - 1]) == 0)
                {
                    return hi - 1;
                }

                // cases if three are different
                return vetor[lo].CompareTo(vetor[mid]) == -1
                    ? (vetor[mid].CompareTo(vetor[hi - 1]) == -1 ? mid : (vetor[lo].CompareTo(vetor[hi - 1]) == -1 ? hi - 1 : lo))
                    : (vetor[mid].CompareTo(vetor[hi - 1]) == 1 ? mid : (vetor[lo].CompareTo(vetor[hi - 1]) == -1 ? lo : hi - 1));
            }

            return lo;
        }

        private void QuickSortLL(int lo, int hi)
        {
            if (lo + 1 < hi)
            {
                int mid = QuickSortLLPartition(lo, hi);

                QuickSortLL(lo, mid);
                QuickSortLL(mid + 1, hi);
            }
        }

        private int QuickSortLLPartition(int lo, int hi)
        {

            // pick pivot and move to back
            int p1 = QuickSortSelectPivot(lo, hi);

            int pivot = vetor[p1].Valor;
            Swap(p1, hi - 1);
            int i = lo;

            for (int j = lo; j < hi - 1; ++j)
            {
                if (vetor[j].Valor <= pivot)
                {
                    Swap(i, j);
                    ++i;
                }
            }

            Swap(i, hi - 1);
            return i;
        }

        private void QuickSortLR(int lo, int hi)
        {
            // pick pivot and watch
            int p1 = QuickSortSelectPivot(lo, hi + 1);

            int pivot = vetor[p1].Valor;

            //Pausa();

            int i = lo, j = hi;

            while (i <= j)
            {
                while (vetor[i].Valor < pivot)
                {
                    i++;
                }

                while (vetor[j].Valor > pivot)
                {
                    j--;
                }

                if (i <= j)
                {
                    Swap(i, j);

                    // follow pivot if it is swapped
                    if (p1 == i)
                    {
                        p1 = j;
                    }
                    else if (p1 == j)
                    {
                        p1 = i;
                    }

                    i++;
                    j--;
                }
            }

            if (lo < j)
            {
                QuickSortLR(lo, j);
            }

            if (i < hi)
            {
                QuickSortLR(i, hi);
            }
        }

        private void QuickSortTernaryLR(int lo, int hi)
        {
            if (hi <= lo)
            {
                return;
            }

            int cmp;

            // pick pivot and swap to back
            int piv = QuickSortSelectPivot(lo, hi + 1);
            Swap(piv, hi);

            int pivot = vetor[hi].Valor;

            // schema: |p ===  |i <<< | ??? |j >>> |q === |piv
            int i = lo;
            int j = hi - 1;
            int p1 = lo;
            int q = hi - 1;

            for (; ; )
            {
                // partition on left
                while (i <= j && ((cmp = Comp(vetor[i].Valor, pivot)) <= 0))
                {
                    if (cmp == 0)
                    {
                        Swap(i, p1++);
                    }
                    ++i;
                }

                // partition on right
                while (i <= j && ((cmp = Comp(vetor[j].Valor, pivot)) >= 0))
                {
                    if (cmp == 0)
                    {
                        Swap(j, q--);
                    }
                    --j;
                }

                if (i > j)
                {
                    break;
                }

                // swap item between < > regions
                Swap(i++, j--);
            }

            // swap pivot to right place
            Swap(i, hi);

            int num_less = i - p1;
            int num_greater = q - j;

            // swap equal ranges into center, but avoid swapping equal elements
            j = i - 1; i += 1;

            int pe = lo + Math.Min(p1 - lo, num_less);
            for (int k = lo; k < pe; k++, j--)
            {
                Swap(k, j);
            }

            int qe = hi - 1 - Math.Min(hi - 1 - q, num_greater - 1); // one already greater at end
            for (int k = hi - 1; k > qe; k--, i++)
            {
                Swap(i, k);
            }
            //Pausa();

            QuickSortTernaryLR(lo, lo + num_less - 1);
            QuickSortTernaryLR(hi - num_greater + 1, hi);
        }
        // //////////////////////////////////////////////////////
        public void RadixSortLSD()
        {
            // radix and base calculations
            const int RADIX = 4;

            uint pmax = (uint)Math.Ceiling(Math.Log(vetor.Max().Valor + 1) / Math.Log(RADIX));
            //ChecaSegmentos();
            for (uint p1 = 0; p1 < pmax; ++p1)
            {
                int base1 = (int)Math.Pow(RADIX, p1);

                // count digits and copy data
                int[] count = new int[RADIX];
                count.Initialize();
                ArrayItem[] copy = new ArrayItem[vetor.Length];
                copy.Initialize();

                for (int i = 0; i < vetor.Length; ++i)
                {
                    copy[i] = vetor[i];
                    int r = copy[i].Valor / base1 % RADIX;
                    count[r]++;
                }

                // exclusive prefix sum
                int[] bkt = new int[RADIX + 1];
                bkt.Initialize();
                for (int z = 0; z < count.Length; z++)
                {
                    for (int y = 0; y <= z; y++)
                    {
                        bkt[z + 1] += count[y];
                    }
                }

                // mark bucket boundaries
                for (int i = 0; i < bkt.Length - 1; ++i)
                {
                    if (bkt[i] >= vetor.Length)
                    {
                        continue;
                    }
                }

                // redistribute items back into array (stable)
                for (int i = 0; i < vetor.Length; ++i)
                {
                    int r = copy[i].Valor / base1 % RADIX;
                    int rb = bkt[r]++;
                    vetor[rb] = copy[i];
                    vetor[rb].Indice = rb;
                    vetor[rb].Mudou = true;
                    Application.DoEvents();

                }
            }
        }
        // //////////////////////////////////////////////////////
        private void RadixSortMSD(int lo, int hi, int depth)
        {
            // radix and base calculations
            const uint RADIX = 4;

            uint pmax = (uint)Math.Floor(Math.Log(vetor.Max().Valor + 1) / Math.Log(RADIX));

            uint base1 = (uint)Math.Pow(RADIX, pmax - depth);

            // count digits
            //std::vector<size_t> count(RADIX, 0);
            int[] count = new int[RADIX];
            count.Initialize();

            for (int i = lo; i < hi; ++i)
            {
                uint r = (uint)vetor[i].Valor / base1 % RADIX;
                count[r]++;
            }

            // inclusive prefix sum
            //std::vector<size_t> bkt(RADIX, 0);
            //std::partial_sum(count.begin(), count.end(), bkt.begin());
            int[] bkt = new int[RADIX];
            bkt.Initialize();
            for (int z = 0; z < count.Length; z++)
            {
                for (int y = 0; y <= z; y++)
                {
                    bkt[z] += count[y];
                }
            }

            // mark bucket boundaries
            for (int i = 0; i < bkt.Length; ++i)
            {
                if (bkt[i] == 0)
                {
                    continue;
                }
            }

            // reorder items in-place by walking cycles
            for (int i = 0, j; i < (hi - lo);)
            {
                while ((j = --bkt[(vetor[lo + i].Valor / base1 % RADIX)]) > i)
                {
                    Swap(lo + i, lo + j);
                }
                //Pausa();
                i += count[(vetor[lo + i].Valor / base1 % RADIX)];
            }

            // no more depth to sort?
            if (depth + 1 > pmax)
            {
                return;
            }

            // recurse on buckets
            int sum = lo;
            for (int i = 0; i < RADIX; ++i)
            {
                if (count[i] <= 1)
                {
                    continue;
                }

                RadixSortMSD(sum, sum + count[i], depth + 1);
                sum += count[i];
            }
        }

        public void RadixSortMSD()
        {
            RadixSortMSD(0, vetor.Length, 0);
        }
        // //////////////////////////////////////////////////////
        public void SelectionSort()
        {
            for (int i = 0; i < vetor.Length - 1; ++i)
            {
                int jMin = i;
                for (int j = i + 1; j < vetor.Length; ++j)
                {
                    if (vetor[j].CompareTo(vetor[jMin]) == -1)
                    {
                        jMin = j;
                    }
                }

                Swap(i, jMin);
            }
        }
        // //////////////////////////////////////////////////////
        public void ShellSort()
        {
            int[] incs = { 1391376, 463792, 198768, 86961, 33936, 13776, 4592, 1968, 861, 336, 112, 48, 21, 7, 3, 1 };
            //ChecaSegmentos();
            for (int k = 0; k < 16; k++)
            {
                for (int h = incs[k], i = h; i < vetor.Length; i++)
                {
                    ArrayItem v = vetor[i];
                    int j = i;
                    while (j >= h && vetor[j - h].Valor > v.Valor)
                    {
                        vetor[j] = vetor[j - h];
                        vetor[j].Indice = j;
                        vetor[j].Mudou = true;
                        Application.DoEvents();

                        j -= h;
                    }
                    vetor[j] = v;
                    vetor[j].Indice = j;
                    vetor[j].Mudou = true;
                    Application.DoEvents();
                }
            }
        }
        // //////////////////////////////////////////////////////
        private void Merge(int lo, int mid, int hi)
        {
            ArrayItem[] outA;

            //ChecaSegmentos();
            // mark merge boundaries

            // allocate output
            outA = new ArrayItem[hi - lo];
            //std::vector < value_type > out(hi - lo);

            // merge
            int i = lo; int j = mid; int o = 0; // first and second halves
            while (i < mid && j < hi)
            {
                // copy out for fewer time steps
                ArrayItem ai = vetor[i];
                ArrayItem aj = vetor[j];
                if (ai.Valor < aj.Valor)
                {
                    ++i;
                    outA[o++] = ai;
                }
                else
                {
                    ++j;
                    outA[o++] = aj;
                }
            }

            // copy rest
            while (i < mid)
            {
                outA[o++] = vetor[i++];
            }

            while (j < hi)
            {
                outA[o++] = vetor[j++];
            }

            // copy back
            for (i = 0; i < hi - lo; ++i)
            {
                int zzz = lo + i;
                vetor[zzz] = outA[i];
                vetor[zzz].Indice = zzz;
                vetor[zzz].Mudou = true;
                Application.DoEvents();
            }
        }

        private void MergeSort(int lo, int hi)
        {
            if (lo + 1 < hi)
            {
                int mid = (lo + hi) / 2;

                MergeSort(lo, mid);
                MergeSort(mid, hi);

                Merge(lo, mid, hi);
            }
        }

        public void MergeSort()
        {
            MergeSort(0, vetor.Length);
        }
        // //////////////////////////////////////////////////////
        private void SlowSort(int i, int j)
        {
            //ChecaSegmentos();
            if (i >= j)
            {
                return;
            }

            int m = (i + j) / 2;

            SlowSort(i, m);
            SlowSort(m + 1, j);

            if (vetor[m].CompareTo(vetor[j]) == 1)
            {
                Swap(m, j);
            }
            SlowSort(i, j - 1);
        }
        public void SlowSort()
        {
            SlowSort(0, vetor.Length - 1);
        }
 
        // //////////////////////////////////////////////////////
        const int NUMBER_OF_BUCKETS = 128;

        private int MaximoDigitos()
        {
            int max = int.MinValue;
            int temp = 0;
            for (int i = 0; i < vetor.Length; i++)
            {
                temp = (int)(Math.Log(vetor[i].Valor) / Math.Log(NUMBER_OF_BUCKETS)) + 1;
                if (temp > max)
                    max = temp;
            }
            return max;
        }

        private int Digitos(int i, int d)
        {
            return (i / d) % NUMBER_OF_BUCKETS;
        }

        private void AmericanSort(int inicio, int tam, int divisor)
        {
            int[] contagem = new int[NUMBER_OF_BUCKETS];
            int[] offset = new int[NUMBER_OF_BUCKETS];
            int digitos = 0;
            //passo 1
            for (int i = inicio; i < tam; i++)
            {
                int d = vetor[i].Valor;
                digitos = Digitos(d, divisor);
                contagem[digitos]++;
            }
            offset[0] = inicio;
            for (int i = 1; i < NUMBER_OF_BUCKETS; i++)
            {
                offset[i] = contagem[i - 1] + offset[i - 1];
            }
            //passo 2
            for (int b = 0; b < NUMBER_OF_BUCKETS; b++)
            {
                while (contagem[b] > 0)
                {
                    int origem = offset[b];
                    int fonte = origem;
                    int num = vetor[fonte].Valor;
                    Color clr = vetor[fonte].Cor;
                    do
                    {
                        digitos = Digitos(num, divisor);
                        int destino = offset[digitos];
                        offset[digitos]++;
                        contagem[digitos]--;
                        int temp = vetor[destino].Valor;
                        vetor[destino].Cor = clr;
                        vetor[destino].Valor = num;
                        vetor[destino].Indice = destino;
                        vetor[destino].Mudou = true;
                        Application.DoEvents();
                        num = temp;
                        fonte = destino;
                    } while (fonte != origem);
                    /*if (mostrar)
                    {
                        Application.DoEvents();
                    }*/

                }
            }
            if (divisor > 1)
            {
                for (int i = 0; i < NUMBER_OF_BUCKETS; i++)
                {
                    int comeco = (i > 0) ? offset[i - 1] : inicio;
                    int final = offset[i];
                    if (final - comeco > 1)
                        AmericanSort(comeco, final, divisor / NUMBER_OF_BUCKETS);
                }
            }
        }
        public void AmericanSort()
        {
            int digitos = MaximoDigitos();
            int max = 1;
            for (int i = 0; i < digitos - 1; i++)
            {
                max *= NUMBER_OF_BUCKETS;
            }
            AmericanSort(0, vetor.Length, max);
        }
        // //////////////////////////////////////////////////////
        public void SandpaperSort()
        {
            for (int i = 0; i < vetor.Length - 1; i++)
            {
                for (int j = i + 1; j < vetor.Length; j++)
                {
                    if (vetor[i].Valor > vetor[j].Valor)
                    {
                        Swap(i, j);
                    }
                }
            }
        }
        // //////////////////////////////////////////////////////

        public void DiamondSort()
        {
            int n = 1;
            for (; n < vetor.Length; n *= 2) ;

            int m = 4;
            for (; m <= n; m *= 2)
            {
                for (int k = 0; k < m / 2; k++)
                {
                    int cnt = k <= m / 4 ? k : m / 2 - k;
                    for (int j = 0; j < vetor.Length; j += m)
                    {
                        if (j + cnt + 1 < vetor.Length)
                        {
                            for (int i = j + cnt; i + 1 < Math.Min(vetor.Length, j + m - cnt); i += 2)
                            {
                                if (vetor[i].Valor > vetor[i + 1].Valor)
                                {
                                    Swap(i, i + 1);
                                }
                            }
                        }
                    }
                }
            }
            m /= 2;
            for (int k = 0; k <= m / 2; k++)
            {
                for (int i = k; i + 1 < Math.Min(vetor.Length, m - k); i += 2)
                {
                    if (vetor[i].Valor > vetor[i + 1].Valor)
                    {
                        Swap(i, i + 1);
                    }
                }
            }
        }
        // //////////////////////////////////////////////////////
        #endregion
        public override string ToString()
        {
            return vetor.ToString();
        }
    }
}
