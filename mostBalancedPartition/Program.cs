namespace mostBalancedPartition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<int> parent = new() { -1, 0, 0, 1, 1, 2 };
            //List<int> filesSize = new() { 1, 2, 2, 1, 1, 1 };

            List<int> parent = new() { -1, 0, 1, 2 };
            List<int> filesSize = new() { 1, 4, 3, 4 };

            //List<int> parent = new() { -1, 0, 0, 0 };
            //List<int> filesSize = new() { 10, 11, 10, 10 };

            int result = mostBalancedPartition(parent, filesSize);
            Console.WriteLine(result);
        }

        public static int mostBalancedPartition(List<int> parent, List<int> files_size)
        {
            int n = parent.Count;
            List<int>[] children = new List<int>[n];

            for (int i = 0; i < n; i++)
                children[i] = new List<int>();

            for (int i = 1; i < n; i++)
                children[parent[i]].Add(i);

            //Console.Write("[ ");
            //for (int i = 0; i < n; i++)
            //    Console.Write($"[{string.Join(' ' , children[i])}], ");
            //Console.Write("]");

            int[] size_sums = new int[n];

            int SizesumsRec(int i)
            {
                if (size_sums[i] != 0)
                    return size_sums[i];
                size_sums[i] = files_size[i] + children[i].Sum(c => SizesumsRec(c));
                return size_sums[i];
            }



            SizesumsRec(0);

            //Console.WriteLine($"[{string.Join(' ', size_sums)}]");

            int minDiff = int.MaxValue;
            for (int i = 1; i < n; i++)
                minDiff = Math.Min(minDiff, Math.Abs(size_sums[0] - 2 * size_sums[i]));

            return minDiff;
        }

    }
}
