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

        public class Node
        {
            public int origin;
            public List<Node> target = new List<Node>();
            //public bool mark = false;

            public Node(int _o)
            {
                origin = _o;
            }

            public void AddEdge(Node _t)
            {
                target.Add(_t);
                //target = target.OrderBy(a => a.origin).ToList();
            }
        }
        public static bool DFS(Node n, int group)
        {
            visited[n.origin] = group;


            for (int i = 0; i < n.target.Count; i++)
            {
                if (visited[n.target[i].origin] == 0)
                {
                    bool flag = DFS(n.target[i], -group);

                    if (!flag)
                        return false;
                }
                else if (visited[n.target[i].origin] == group)
                    return false;

            }

            return true;
        }

        public static void Main()
        {
            StringBuilder builder = new StringBuilder();
            var k = int.Parse(Console.ReadLine());

            for (int t = 0; t < k; t++)
            {
                var ve = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

                var nodes = new Node[ve[0] + 1];
                visited = new int[ve[0] + 1];
                for (int i = 1; i <= ve[0]; i++)
                    nodes[i] = new Node(i);

                for (int i = 0; i < ve[1]; i++)
                {
                    var ot = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                    nodes[ot[0]].AddEdge(nodes[ot[1]]);
                    nodes[ot[1]].AddEdge(nodes[ot[0]]);
                }

                bool flag = true;
                for (int i = 1; i <= ve[0]; i++)
                {
                    if (visited[i] == 0)
                        flag = DFS(nodes[i], 1);

                    if (!flag) break;
                }

                builder.Append(flag ? "YES\n" : "NO\n");

            }

            Console.WriteLine(builder);

        }
    }
}


