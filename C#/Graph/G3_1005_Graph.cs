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
        public static int[] visited;
        public static List<Node> sorted;

        public class Node
        {
            public int origin;
            public List<Node> target = new List<Node>();
            public int weight;
            //public bool mark = false;

            public Node(int _o, int _weight)
            {
                origin = _o;
                weight = _weight;
            }

            public void AddEdge(Node _t)
            {
                target.Add(_t);
                //target = target.OrderBy(a => a.origin).ToList();
            }
        }
        public static void DFS(Node n)
        {
            visited[n.origin] = 1;


            for (int i = 0; i < n.target.Count; i++)
            {
                if (visited[n.target[i].origin] == 0)
                {
                    DFS(n.target[i]);

                }
            }

            sorted.Add(n);

        }

        public static void Main()
        {
            StringBuilder builder = new StringBuilder();
            
            var k = int.Parse(Console.ReadLine());
            for(int t = 0; t < k; t++)
            {
                var ve = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

                var weights = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

                var nodes = new Node[ve[0] + 1];

                visited = new int[ve[0] + 1];
                sorted = new List<Node>();

                for (int i = 1; i <= ve[0]; i++)
                    nodes[i] = new Node(i, weights[i-1]);

                for (int i = 0; i < ve[1]; i++)
                {
                    var ot = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                    nodes[ot[0]].AddEdge(nodes[ot[1]]);
                }
            
                for (int i = 1; i <= ve[0]; i++)
                {
                    if (visited[i] == 0)
                        DFS(nodes[i]);
                }

                sorted.Reverse();

                var w = int.Parse(Console.ReadLine());

                var dp = new long[ve[0] + 1];

                for (int i = 1; i <= ve[0]; i++)
                {
                    long temp = 0L;

                    for(int j = 1; j < i; j++)
                    {
                        if (sorted[j-1].target.Contains(sorted[i-1]))
                        {
                            temp = Math.Max(temp, dp[j]);
                        }
                    }

                    dp[i] = temp + sorted[i - 1].weight;
                }

                int idx = sorted.IndexOf(nodes[w]);
                builder.Append(dp[idx+1] + "\n");
            }

            Console.WriteLine(builder);
        }
    }
}


