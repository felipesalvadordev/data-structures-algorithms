using System;
using System.Collections.Generic;

namespace Data_Structures_Algorithms.ProblemSolvingPatterns.Recursion
{
    internal class BinaryTreeRightSideViewBFS
    {
        List<int> visibleElements = new List<int>();
        public void Test()
        {
            /*
           *     1
           *    / \
           *   2   3
           *    \   \
           *     5   4   
           *     
           *  Output: [1,3,4]
           */


            //TreeNode root = new TreeNode(1)
            //{
            //    left = new TreeNode(2) { right = new TreeNode(5)},
            //    right = new TreeNode(3) { left = new TreeNode(4)}
            //};


            TreeNode root = new TreeNode(1)
            {
                left = new TreeNode(2) { left = new TreeNode(4) { left = new TreeNode(5) } },
                right = new TreeNode(3) { left = null, right = null }
            };

            /*
            *        1
            *       / \
            *      2   3
            *     /    
            *    4           
            *   /
            *  5
            *  
            *  Output: [1,3,4,5]
            */

            DFS(root, 0);

            foreach (var element in visibleElements)
            {
                Console.WriteLine(element);
            }
        }

        private void DFS(TreeNode node, int depth)
        {
            if (node == null)
                return;

            if (visibleElements.Count == depth)//To insert only one element per height
                visibleElements.Add(node.val);

            DFS(node.right, depth + 1);//Insert all elements in right first
            DFS(node.left, depth + 1);
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
