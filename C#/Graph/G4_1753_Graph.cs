using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BOJ
{
    internal class Boj
    {
        public class TRI
        {
            public int u;
            public int v;
            public int w;
            public TRI()
            {
           
            }
            public TRI(int _u, int _v, int _w)
            {
                u = _u;
                v = _v;
                w = _w;
            }
        }

        public class PQ
        {
            public int n = 0;
            public TRI[] arr = new TRI[300001];

            public TRI Delete()
            {
                TRI ret = arr[1];
                int i, j;

                if(n == 1)
                {
                    n = 0;
                    return ret;
                }

                arr[1] = arr[n];
                i = 1;
                n--;

                while (true)
                {
                    if(i * 2 > n)
                        break;
                    
                    else if(i * 2 + 1 > n)
                    {
                        if (arr[i * 2].w < arr[i].w)
                        {
                            (arr[i * 2], arr[i]) = (arr[i], arr[i * 2]);
                            i *= 2;
                        }
                        else 
                            break;
                    }

                    else
                    {
                        if (arr[i].w > arr[i * 2].w && arr[i].w > arr[i * 2 + 1].w)
                        {
                            if (arr[i * 2].w < arr[i * 2 + 1].w)
                                j = i * 2;
                            else
                                j = i * 2 + 1;

                            (arr[i], arr[j]) = (arr[j], arr[i]);
                            i = j;
                        }
                        else if (arr[i].w > arr[i * 2].w && arr[i].w <= arr[i * 2 + 1].w)
                        {
                            j = i * 2;
                            (arr[i], arr[j]) = (arr[j], arr[i]);
                            i = j;
                        }
                        else if (arr[i].w <= arr[i * 2].w && arr[i].w > arr[i * 2 + 1].w)
                        {
                            j = i * 2 + 1;
                            (arr[i], arr[j]) = (arr[j], arr[i]);
                            i = j;
                        }
                        else
                            break;
                    }
                }

                return ret;
            }
            public void Insert(TRI x)
            {
                int i = n + 1;
                arr[n + 1] = x;

                n++;

                while(i>1 && arr[i].w < arr[i / 2].w)
                {
                    (arr[i], arr[i / 2]) = (arr[i / 2], arr[i]);
                    i /= 2;
                }
            }
            public bool IsEmpty() { return n == 0; }

            
        }
        
        public static void Main()
        {
            var bulider = new StringBuilder();

            var ve = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            var source = int.Parse(Console.ReadLine());

            var edges = new List<Tuple<int, int>>[300001];
            var redSet = new int[20001];

            for(int i = 0; i < 300001; i++)
            {
                edges[i] = new List<Tuple<int, int>>();
            }

            for(int i=0; i < ve[1]; i++)
            {
                using (var sr = new StringReader(Console.ReadLine()))
                {
                    var arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

                    edges[arr[0]].Add(new Tuple<int, int>(arr[1], arr[2])); // 방향 그래프!
                    //edges[arr[1]].Add(new Tuple<int, int>(arr[0], arr[2]));
                }
            }

            PQ pq = new PQ();

            for (int i = 1; i <= ve[0]; i++) redSet[i] = 10000000;

            int c = source;
            redSet[c] = 0;


            for(int i = 0; i < edges[c].Count; i++)
            {
                TRI x = new TRI(c, edges[c][i].Item1, redSet[c] + edges[c][i].Item2);

                pq.Insert(x);
            }


            while (!pq.IsEmpty())
            {
                TRI y = pq.Delete();

                if (redSet[y.v] < 10000000)
                {
                    if (redSet[y.v] == y.w)
                    {
                        // 중복
                    }
                    else
                    {
                        // 무시
                    }
                }
                else
                {
                    c = y.v;
                    redSet[c] = y.w;
                    //

                    for(int i = 0; i < edges[c].Count; i++)
                    {
                        TRI x = new TRI(c, edges[c][i].Item1, redSet[c] + edges[c][i].Item2);

                        pq.Insert(x);
                    }
                }

            }



            for (int i = 1; i <= ve[0]; i++)
            {
                if (redSet[i] == 10000000)
                    bulider.Append("INF\n");
                else
                    bulider.Append(redSet[i] + "\n");
            }

            Console.WriteLine(bulider);
        }

    }
}


