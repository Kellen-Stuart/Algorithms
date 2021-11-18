using System;

namespace DataStructures
{
    public class UnionFind
    {
        // The number of elements in this union find
        public int Size { get; }
        
        // The size of each component
        public int[] Sz { get; }
        
        // Id[i] points to the parent of i, if Id[i] = i then i is the root node
        public int[] Id { get; }
        
        public int NumComponents { get; set;  }
        
        public UnionFind(int size)
        {
            if (size <= 0)
                throw new ArgumentException("Size <= 0 is not allowed");

            Size = size;
            NumComponents = size;
            Id = new int[size];
            Sz = new int[size];

            for (var i = 0; i < size; i++)
            {
                Id[i] = i;
                Sz[i] = 1;
            }
        }
        
        // return where or not the elements 'p' and
        // 'q' are in the same components/set
        public bool Connected(int p, int q) => Find(p) == Find(q);

        public int ComponentSize(int p) => Sz[Find(p)];

        public int Find(int p)
        {
            var root = p;
            
            while (root != Id[root])
                root = Id[root];

            while (p != root)
            {
                var next = Id[p];
                Id[p] = root;
                p = next;
            }

            return root;
        }

        // Unify the components/sets containing elements 'p' and 'q'
        public void Unify(int p, int q)
        {
            // root1 =  1
            var root1 = Find(p);
            // root2 = 0
            var root2 = Find(q);
            
            // If the elements are in the same group you cannot unify them again...
            if (root1 == root2)
                return;
            
            // Merge smaller component/set into the larger one
            if (Sz[root1] < Sz[root2])
            {
                //
                Sz[root2] += Sz[root1];
                Id[root1] = root2;
                Sz[root1] = 0;
            }
            else
            {
                
                // Sz[0] += Sz[2]
                Sz[root1] += Sz[root2];
                Id[root2] = root1;
                Sz[root2] = 0;
            }

            NumComponents--;
        }
    }
}