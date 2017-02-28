using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReayonotAvoda.Algorithms.Searching
{
    class DFS
    {
        void search(Node root)
        {
            if (root == null) return;
            visit(root);
            root.visited = true;
            foreach (Node n in root.adjacent)
            {
                if (n.visited == false)
                {
                    search(n);
                }
            }
        }
    }
}
