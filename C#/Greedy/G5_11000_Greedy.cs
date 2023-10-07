using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BOJ
{
    internal class Boj
    {
        public class Schedule
        {
            public long s;
            public long t;

            public Schedule(long _s, long _t) { s = _s; t = _t; }
            public Schedule() { }
        }
        public class PQ
        {
            public int n = 0;

            public Schedule[] arr = new Schedule[200001];

            public Schedule Delete()
            {
                Schedule ret = arr[1];
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
                        if (arr[i * 2].s < arr[i].s)
                        {
                            (arr[i * 2], arr[i]) = (arr[i], arr[i * 2]);
                            i *= 2;
                        }
                        else 
                            break;
                    }

                    else
                    {
                        if (arr[i].s > arr[i * 2].s && arr[i].s > arr[i * 2 + 1].s)
                        {
                            if (arr[i * 2].s < arr[i * 2 + 1].s)
                                j = i * 2;
                            else
                                j = i * 2 + 1;

                            (arr[i], arr[j]) = (arr[j], arr[i]);
                            i = j;
                        }
                        else if (arr[i].s > arr[i * 2].s && arr[i].s <= arr[i * 2 + 1].s)
                        {
                            j = i * 2;
                            (arr[i], arr[j]) = (arr[j], arr[i]);
                            i = j;
                        }
                        else if (arr[i].s <= arr[i * 2].s && arr[i].s > arr[i * 2 + 1].s)
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
            public void Insert(Schedule x)
            {
                int i = n + 1;
                arr[n + 1] = x;

                n++;

                while(i>1 && arr[i].s < arr[i / 2].s)
                {
                    (arr[i], arr[i / 2]) = (arr[i / 2], arr[i]);
                    i /= 2;
                }
            }
            public bool IsEmpty() { return n == 0; }
        }

        public class PQ2
        {

            public int n = 0;

            public Schedule[] arr = new Schedule[200001];

            public Schedule Min()
            {
                return arr[1];
            }
            public int Size()
            {
                return n;
            }

            public Schedule Delete()
            {
                Schedule ret = arr[1];
                int i, j;

                if (n == 1)
                {
                    n = 0;
                    return ret;
                }

                arr[1] = arr[n];
                i = 1;
                n--;

                while (true)
                {
                    if (i * 2 > n)
                        break;

                    else if (i * 2 + 1 > n)
                    {
                        if (arr[i * 2].t < arr[i].t)
                        {
                            (arr[i * 2], arr[i]) = (arr[i], arr[i * 2]);
                            i *= 2;
                        }
                        else
                            break;
                    }

                    else
                    {
                        if (arr[i].t > arr[i * 2].t && arr[i].t > arr[i * 2 + 1].t)
                        {
                            if (arr[i * 2].t < arr[i * 2 + 1].t)
                                j = i * 2;
                            else
                                j = i * 2 + 1;

                            (arr[i], arr[j]) = (arr[j], arr[i]);
                            i = j;
                        }
                        else if (arr[i].t > arr[i * 2].t && arr[i].t <= arr[i * 2 + 1].t)
                        {
                            j = i * 2;
                            (arr[i], arr[j]) = (arr[j], arr[i]);
                            i = j;
                        }
                        else if (arr[i].t <= arr[i * 2].t && arr[i].t > arr[i * 2 + 1].t)
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
            public void Insert(Schedule x)
            {
                int i = n + 1;
                arr[n + 1] = x;

                n++;

                while (i > 1 && arr[i].t < arr[i / 2].t)
                {
                    (arr[i], arr[i / 2]) = (arr[i / 2], arr[i]);
                    i /= 2;
                }
            }
            public bool IsEmpty() { return n == 0; }
        }

        public static void Main()
        {

            var n = int.Parse(Console.ReadLine());


            PQ pq = new PQ(); // starttime 로 정렬
            
            for (int i=1; i<=n; i++)
            {
                using (var sr = new StringReader(Console.ReadLine()))
                {
                    var arr = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);

                    pq.Insert(new Schedule(arr[0], arr[1]));
                }
            }


            Schedule y = new Schedule();

            long min = long.MaxValue;

            PQ2 pq2 = new PQ2(); // endtime 으로 정렬

            if (!pq.IsEmpty())
            {
                y = pq.Delete();
                pq2.Insert(y);
            }

            while (!pq.IsEmpty())
            {
                y = pq.Delete();
                min = pq2.Min().t;
  
                if(min <= y.s)  
                    pq2.Delete();
                
                pq2.Insert(y);

            }

            Console.WriteLine(pq2.Size());

           
        }

    }
}


