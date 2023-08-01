using System;
using System.Linq;

namespace BOJ
{
    internal class Boj
    {
        public static void Main()
        {
            var s = Console.ReadLine();
            var t = Console.ReadLine();

            for(int i=0; ; i++)
            {
                //Console.WriteLine(s + " " + t);
                if (t.Length == s.Length) break;

                if (t[t.Length - 1] == 'A')
                {
                    string temp = "";

                    for (int j = 0; j < t.Length - 1; j++)
                    {
                        temp += t[j];
                    }

                    t = temp;
                }
                else if(t[t.Length - 1] == 'B')
                {
                    string temp = "";

                    for (int j = 0; j < t.Length - 1; j++)
                    {
                        temp += t[j];
                    }

                    var k = temp.ToCharArray().Reverse().ToArray();

                    t = new string(k);
                }
            }

            Console.WriteLine(s == t ? 1 : 0);
        }

    }
}
