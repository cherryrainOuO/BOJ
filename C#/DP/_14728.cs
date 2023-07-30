using System;

namespace BOJ
{
    internal class Boj
    {
        public static void Main()
        {
            var nt = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            var item = new Tuple<int, int>[nt[0] + 1];

            item[0] = new Tuple<int, int>(0, 0);

            for (int i = 1; i <= nt[0]; i++)
            {
                var muga = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                item[i] = new Tuple<int, int>(muga[0], muga[1]);
            }

            var dp = new int[nt[0] + 1, nt[1] + 1];

            for (int i = 1; i <= nt[0]; i++)
            {
                for (int j = 1; j <= nt[1]; j++)
                {
                    if (j < item[i].Item1)
                        dp[i, j] = dp[i - 1, j];
                    else
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i - 1, j - item[i].Item1] + item[i].Item2);

                }
            }

            Console.WriteLine(dp[nt[0], nt[1]]);

        }
    }
}
