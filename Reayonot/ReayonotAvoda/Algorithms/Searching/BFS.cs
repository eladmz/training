using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace ReayonotAvoda.Algorithms.Searching
{
    class BFS
    {
        void search(Node root)
        {
            if (root == null) return;

            Queue queue = new Queue();
            root.marked = true;
            queue.Enqueue(root); // Add to the end of queue

            while(queue.Count != 0) {
                Node n = queue.Dequeue; // Remove from the front of the queue
                visit(n);

                foreach(Node adjNode in n.adjacent){
                    if (adjNode.marked == false)
                    {
                        adjNode.marked == true;
                        queue.Enqueue(adjNode);
                    }
                }
            }
        }
    }
}
