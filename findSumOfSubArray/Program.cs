using System.IO;

namespace SubArray_Sums
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<int> numbers = new List<int>() { 5, 10, 10 };
            //List<List<int>> queries = new List<List<int>>();
            //queries.Add(new List<int> { 1,2,5});

            List<int> numbers = new List<int>() { -5, 0 };
            List<List<int>> queries = new List<List<int>>();
            queries.Add(new List<int> { 2, 2, 20 });
            queries.Add(new List<int> { 1, 2, 10 });


            List<long> result = findSum(numbers, queries);
            Console.WriteLine(String.Join("\n", result));

        }

        public static List<long> findSum(List<int> numbers, List<List<int>> queries)
        {
            List<long> sumArray = new List<long>();
            List<int> numOfZeros = new List<int>();
            List<long> result = new List<long>();


            long sum = 0;
            sumArray.Add(sum);
            foreach (int number in numbers)
                sumArray.Add(sum += number);

            //Console.WriteLine($"[{string.Join(' ', sumArray)}]");

            int pre = 0;
            numOfZeros.Add(pre);
            foreach (int number in numbers)
                numOfZeros.Add(pre += (number == 0 ? 1 : 0));

            //Console.WriteLine($"[{string.Join(' ', numOfZeros)}]");


            for (int i = 0; i < queries.Count; i++)
            {
                int l = queries[i][0], r = queries[i][1], x = queries[i][2];
                long res = (sumArray[r] - sumArray[l - 1]) + (long)(x * (long)(numOfZeros[r] - numOfZeros[l - 1]));
                result.Add(res);
            }

            return result;
        }

    }
}
