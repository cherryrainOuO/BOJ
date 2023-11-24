using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace BOJ
{
    internal class Boj
    {
        public static bool[] visited;
        public static List<Node> cutVertexs = new List<Node>();
        public static int count = 1;

        public class Node
        {
            public int origin;
            public List<Node> target = new List<Node>();
            public int pre;

            public Node(int _o)
            {
                origin = _o;
            }

            public void AddEdge(Node _t)
            {
                target.Add(_t);
            }
        }

        public static int DFS(Node n, bool isRoot)
        {

            n.pre = count++;
            int retval = n.pre;
            visited[n.origin] = true;

            int treeChild = 0; // target.Count 로 하면 안됨 (dfs 트리 기준 루트의 child를 세야됨)

            for (int i = 0; i < n.target.Count; i++)
            {
                if (!visited[n.target[i].origin])
                {
                    treeChild++;
                    int s = DFS(n.target[i], false);

                    if (!isRoot && s >= n.pre)
                    {
                        cutVertexs.Add(n);
                    }

                    retval = Math.Min(retval, s);
                }
                else
                {
                    retval = Math.Min(retval, n.target[i].pre);
                }
            }

            if (isRoot && treeChild >= 2)
                cutVertexs.Add(n);

            return retval;
        }

        public static void Main()
        {

            var ve = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            var nodes = new Node[ve[0] + 1];
            visited = new bool[ve[0] + 1];
            for (int i = 1; i <= ve[0]; i++)
                nodes[i] = new Node(i);

            for (int i = 0; i < ve[1]; i++)
            {
                var ot = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                nodes[ot[0]].AddEdge(nodes[ot[1]]);
                nodes[ot[1]].AddEdge(nodes[ot[0]]);
            }

            for (int i = 1; i <= ve[0]; i++)
            {
                if (!visited[i])
                    DFS(nodes[i], true);
            }

            var sortingSol = cutVertexs.Distinct().OrderBy(a => a.origin).ToArray();

            Console.WriteLine(sortingSol.Length);
            foreach (var i in sortingSol)
                Console.Write(i.origin + " ");

        }
    }
}


