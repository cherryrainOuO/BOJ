using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BOJ
{
    internal class Boj
    {        
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var m = int.Parse(Console.ReadLine());
            var DP = new List<long>[n+1, n+1];
            
            for(int i=0; i<=n; i++)
            {
                for(int j=0; j<=n; j++)
                {
                    DP[i, j] = new List<long>();
                    if (i == j) DP[i, j].Add(0);
                    else DP[i, j].Add(100000000000);
                }
            }

            
            for (int i = 0; i < m; i++)
            {
                using (var sr = new StringReader(Console.ReadLine()))
                {
                    var abc = Array.ConvertAll(sr.ReadLine().Split(' '), long.Parse);
                    DP[abc[0], abc[1]].Add(abc[2]);
                }
            }

            for(int k=1; k<=n; k++)
            {
                for(int i=1; i<=n; i++)
                {
                    for (int j=1; j<=n; j++)
                    {
                        DP[i, j].Add(Math.Min(DP[i, j].Min(), DP[i, k].Min() + DP[k, j].Min()));
                    }
                }
            }

            for(int i=1; i<=n ; i++)
            {
                for(int j=1; j<=n; j++)
                {
                    if (DP[i, j].Min() == 100000000000)
                        Console.Write("0 ");
                    else 
                        Console.Write(DP[i, j].Min() + " ");
                }
                Console.WriteLine();
            }

        }
    }
}


