using System;
using DataStructures;

namespace Algorithms
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var values = new int[] { 7, 10, 115, 3, 75, 46 };
            var connections = new int[][]
            {
                new[] { 10, 115 },
                new[] { 10, 3 },
                new[] { 46, 75 }
            };

            var unionFind = new UnionFind(values.Length);

            foreach (var conn in connections)
                unionFind.Unify(Array.IndexOf(values, conn[0]), Array.IndexOf(values, conn[1]));

            var find = unionFind.Find(Array.IndexOf(values, 75));
        }
    }
}