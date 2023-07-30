using System;
using System.Linq;

namespace BOJ
{
    internal class Boj
    {
        public static void Main()
        {
            var t = int.Parse(Console.ReadLine());

            for (int k = 0; k < t; k++)
            {
                var n = int.Parse(Console.ReadLine());
                var coin = Array.ConvertAll(Console.ReadLine().Split(), int.Parse).OrderBy(l => l).ToArray();
                var m = int.Parse(Console.ReadLine());

                var dp = new int[coin.Length + 1, m + 1];

                for (int i = 1; i <= coin.Length; i++)
                {
                    dp[i, 0] = 1;
                }

                for (int i = 1; i <= coin.Length; i++)
                {
                    for (int j = 1; j <= m; j++)
                    {

                        dp[i, j] = (j - coin[i - 1] >= 0) ? dp[i, j - coin[i - 1]] + dp[i - 1, j] : dp[i - 1, j];
                    }
                }

                Console.WriteLine(dp[coin.Length, m]);

            }
        }
    }
}
