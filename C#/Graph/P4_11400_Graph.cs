using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOJ
{
    internal class Boj
    {
        public static bool[] visited;
        public static List<Tuple<int, int>> cutEdges = new List<Tuple<int, int>>();
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

        public static int DFS(Node n, Node parent)
        {

            n.pre = count++;
            int retval = n.pre;
            visited[n.origin] = true;

            //int treeChild = 0; // target.Count 로 하면 안됨 (dfs 트리 기준 루트의 child를 세야됨)

            for (int i = 0; i < n.target.Count; i++)
            {
                if (n.target[i] == parent) continue;
                // 부모 체크도 허용하면 밑에
                // Math.Min(retval, n.target[i].pre) 때문에 항상 s == n.pre 되버림.
                // 이러면 cut edge 체크 못함!!!

                if (!visited[n.target[i].origin])
                {
                    //treeChild++;

                    int s = DFS(n.target[i], n);


                    if (s > n.pre)
                    {

                        int a = n.origin;
                        int b = n.target[i].origin;

                        if (a > b) (a, b) = (b, a);

                        cutEdges.Add(new Tuple<int, int>(a, b));
                    }

                    retval = Math.Min(retval, s);
                }
                else
                {
                    retval = Math.Min(retval, n.target[i].pre);
                }
            }

            /*
            if (isRoot && treeChild >= 2)
                cutVertexs.Add(n);
            */

            return retval;
        }

        public static void Main()
        {
            StringBuilder sb = new StringBuilder();
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
                    DFS(nodes[i], null);
            }

            var sortingSol = cutEdges.OrderBy(a => a.Item1).ThenBy(b => b.Item2).ToArray();

            sb.Append(sortingSol.Length + "\n");
            foreach (var i in sortingSol)
                sb.Append(i.Item1 + " " + i.Item2 + "\n");

            Console.WriteLine(sb);

        }
    }
}


