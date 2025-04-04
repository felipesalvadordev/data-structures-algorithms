using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures_Algorithms.ProblemSolvingPatterns.Recursion
{
    internal class MaximumDepthOfBinaryTree
    {
        public void Test()
        {
            TreeNode root = new TreeNode(3)
            {
                left = new TreeNode(9),
                right = new TreeNode(20) { left = new TreeNode(15), right = new TreeNode(7) }
            };

            var maxDepth = MaxDepth(root);
            Console.WriteLine(maxDepth);
        }


        public int MaxDepth(TreeNode root)
        {
            return Traverse(root, 0);
        }

        //Depth-first search
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
