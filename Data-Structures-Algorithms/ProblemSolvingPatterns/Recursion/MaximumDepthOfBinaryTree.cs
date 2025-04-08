using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Data_Structures_Algorithms.ProblemSolvingPatterns.Recursion
{
    internal class MaximumDepthOfBinaryTree
    {
        //Depth-first search to traverse down the tree until we reach a null value. At that point,
        //return the current depth.
        public void Test()
        {
            /*
            *               3
            *              / \
            *             9  20
            *            /   / \  
            *           10  15  7 
            *                    \
            *                     8
            */

            TreeNode root = new TreeNode(3)
            {
                left = new TreeNode(9) { left = new TreeNode(10) },
                right = new TreeNode(20) { left = new TreeNode(15), right = new TreeNode(7) { right = new TreeNode(8) } }
            };

            var maxDepth = Traverse(root, 0);
            Console.WriteLine(maxDepth);
        }


        //public int MaxDepth(TreeNode root)
        //{
        //    return Traverse(root, 0);
        //}

        //Depth-first search (DFS)
        public int Traverse(TreeNode currentNode, int currentDepth)
        {
            if (currentNode == null)
                return currentDepth;

            currentDepth++;
            return Math.Max(Traverse(currentNode.left, currentDepth), Traverse(currentNode.right, currentDepth));
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
    }
}
