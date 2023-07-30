using System;

namespace BOJ
{
    internal class Boj
    {
        public static void Main()
        {
            var nk = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var item = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            var dp = new int[nk[0] + 1, nk[1] + 1];

            for(int i=1; i <= nk[1]; i++)            
                dp[0, i] = 101;                
            
            for (int i = 1; i <= nk[0]; i++)
            {
                for (int j = 1; j <= nk[1]; j++)
                {
                    if (j - item[i-1] < 0)                   
                        dp[i, j] = dp[i - 1, j];                    
                    else                   
                        dp[i, j] = Math.Min(dp[i-1, j], dp[i - 1, j - item[i - 1]] + 1);
                    

                }
            }

            Console.WriteLine(dp[nk[0], nk[1]] == 101 ? -1 : dp[nk[0], nk[1]]);

        }
    }
}
