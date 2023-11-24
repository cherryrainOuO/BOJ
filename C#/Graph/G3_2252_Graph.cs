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
        public static List<int> sorted = new List<int>();

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

            sorted.Add(n.origin);

        }

        public static void Main()
        {
            StringBuilder builder = new StringBuilder();
            
            var ve = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            var nodes = new Node[ve[0] + 1];
            visited = new int[ve[0] + 1];
            for (int i = 1; i <= ve[0]; i++)
                nodes[i] = new Node(i);

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
            
            foreach(var i in sorted)
            {
                builder.Append(i + " ");
            }

            Console.WriteLine(builder);

        }
    }
}


