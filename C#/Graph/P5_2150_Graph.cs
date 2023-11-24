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
            public List<Node> reverseLink = new List<Node>();
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

            public void ReverseLink()
            {
                for(int i=0; i<target.Count; i++)
                {
                    target[i].reverseLink.Add(this);
                }
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

        public static void SCC(Node n, List<int> list)
        {
            visited[n.origin] = 1;
            sorted.Remove(n.origin);

            for (int i = 0; i < n.reverseLink.Count; i++)
            {
                if (visited[n.reverseLink[i].origin] == 0)
                {
                    SCC(n.reverseLink[i], list);

                }
            }

            list.Add(n.origin);
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

            for (int i = 1; i <= ve[0]; i++)
            {
                nodes[i].ReverseLink();
            }

            visited = new int[ve[0] + 1];

            List<List<int>> sccComponents = new List<List<int>>();
            while(sorted.Count > 0)
            {
                List<int> sccComponent = new List<int>();
                
                SCC(nodes[sorted[0]], sccComponent);
                sccComponent = sccComponent.OrderBy(a => a).ToList();
                sccComponents.Add(sccComponent);
            }

            builder.Append(sccComponents.Count + "\n");

            sccComponents = sccComponents.OrderBy(a => a[0]).ToList();

            foreach (var component in sccComponents)
            {
                foreach(var i in component)
                    builder.Append(i + " ");
                builder.Append("-1\n");
            }

            Console.WriteLine(builder);

        }
    }
}


