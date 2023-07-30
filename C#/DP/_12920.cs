using System;
using System.Collections.Generic;

namespace BOJ
{
    internal class Boj
    {
        public static void Main()
        {
            var nm = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            var item = new List<Tuple<int, int>>();
            item.Add(new Tuple<int, int>(0, 0));

            for (int i = 1; i <= nm[0]; i++)
            {
                var arr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

                for (int j = 0; arr[2] > 0; j++)
                {
                    var pow = (int)Math.Min(Math.Pow(2, j), arr[2]);

                    item.Add(new Tuple<int, int>(arr[0] * pow, arr[1] * pow));

                    arr[2] -= pow;
                }
            }


            var dp = new int[item.Count + 1, nm[1] + 1];

            for (int i = 1; i <= item.Count; i++)
            {
                for (int j = 1; j <= nm[1]; j++)
                {
                    if (j - item[i - 1].Item1 < 0)
                        dp[i, j] = dp[i - 1, j];
                    else
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i - 1, j - item[i - 1].Item1] + item[i - 1].Item2);

                }
            }

            Console.WriteLine(dp[item.Count, nm[1]]);

        }
    }
}
