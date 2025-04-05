using System;
using System.Collections.Generic;

namespace Data_Structures_Algorithms.Data_Structures.Queues
{
    internal class MaximumDepthOfBinaryTree
    {
        public void Test()
        {
            /*
            *     1
            *    / \
            *   2   3
            *      / 
            *     4           
            */

            TreeNode root = new TreeNode(1)
            {
                left = new TreeNode(2),
                right = new TreeNode(3) { left = new TreeNode(4)}
            };

            var maxDepth = MaxDepth(root);
            Console.WriteLine(maxDepth);
        }

        //Breadth First Search
        public int MaxDepth(TreeNode root)
        {
            Queue<TreeNode> q = new Queue<TreeNode>();
            if (root != null)
            {
                q.Enqueue(root);
            }

            int level = 0;
            while (q.Count > 0)
            {
                int size = q.Count;
                for (int i = 0; i < size; i++)
                {
                    TreeNode node = q.Dequeue();
                    if (node.left != null)
                    {
                        q.Enqueue(node.left);
                    }
                    if (node.right != null)
                    {
                        q.Enqueue(node.right);
                    }
                }
                level++;
            }
            return level;
        }
    }
}
