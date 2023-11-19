using System;
using System.Reflection;
using System.Security.AccessControl;

namespace BOJ
{
    internal class BOJ
    {
        public static void Main()
        {
            var str1 = Console.ReadLine();
            var str2 = Console.ReadLine();
            var str3 = Console.ReadLine();

            var dp = new int[str1.Length + 1, str2.Length + 1, str3.Length + 1];


            for (int i = 1; i <= str1.Length; i++)
            {

                for (int j = 1; j <= str2.Length; j++)
                {
                    for(int k=1; k <= str3.Length; k++)
                    {
                        if ((str1[i - 1] == str2[j - 1]) && (str2[j - 1] == str3[k - 1]))
                        {
                            dp[i, j, k] = dp[i - 1, j - 1, k - 1] + 1;
                        }
                        else if((str1[i - 1] != str2[j - 1]) && (str2[j - 1] == str3[k - 1]))
                        {
                            dp[i, j, k] = Math.Max(dp[i - 1, j, k], dp[i, j - 1, k-1]);
                        }
                        else if ((str1[i - 1] == str2[j - 1]) && (str2[j - 1] != str3[k - 1]))
                        {
                            dp[i, j, k] = Math.Max(dp[i, j, k-1], dp[i-1, j - 1, k]);
                        }
                        else if ((str1[i - 1] != str2[j - 1]) && (str1[i - 1] == str3[k - 1]))
                        {
                            dp[i, j, k] = Math.Max(dp[i, j-1, k], dp[i - 1, j, k-1]);
                        }
                        else
                        {
                            dp[i, j, k] = Math.Max(Math.Max(dp[i - 1, j, k], dp[i, j - 1, k]), dp[i, j, k-1]);
                        }
                            
                    }
            }


            //foreach(int i in dp) { Console.WriteLine(i + " "); }

            Console.WriteLine(dp[str1.Length, str2.Length, str3.Length]);
        }
    }
}
