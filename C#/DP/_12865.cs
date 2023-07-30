using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BOJ
{
    internal class Boj
    {
        public static void Main()
        {
            var nk = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            var arr = new List<Tuple<int, int>>();
            arr.Add(new Tuple<int, int>(0, 0));

            for (int i = 1; i <= nk[0]; i++)
            {
                int[] str;
                using (var sr = new StringReader(Console.ReadLine()))
                    str = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

                arr.Add(new Tuple<int, int>(str[0], str[1]));
            }

            arr = arr.OrderBy(n => n.Item1).ToList();

            var dp = new int[nk[0] + 1, nk[1] + 1];

            for (int i = 1; i <= nk[0]; i++)
            {
                for (int j = 1; j <= nk[1]; j++)
                {
                    if (arr[i].Item1 <= j)
                    {
                        dp[i, j] = Math.Max(arr[i].Item2 + dp[i - 1, j - arr[i].Item1],
                                            dp[i - 1, j]);

                    }
                    else
                    {
                        dp[i, j] = dp[i - 1, j];
                    }
                }
            }

            Console.WriteLine(dp[nk[0], nk[1]]);
        }
    }
}
