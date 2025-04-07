using System;

namespace Data_Structures_Algorithms.ProblemSolvingPatterns.Recursion
{
    internal class SearchInABinaryTree
    {
        //Time: O(logN) in average and O(N) in worst case.
        //Space: O(logN) in average and O(N) in worst case for the call stack.
        static TreeNode nodeElementFound = null;
        public void Test()
        {
            var val = 2;
            TreeNode root = new TreeNode(4)
            {
                left = new TreeNode(2) { right = new TreeNode(3), left = new TreeNode(1) },
                right = new TreeNode(7)//Result 2,1,3
            };

            //var val = 63; //Result: 63, null, 84
            //TreeNode root = new TreeNode(18)
            //{
            //    left = new TreeNode(2),
            //    right = new TreeNode(22)
            //    {
            //        right = new TreeNode(63) { right = new TreeNode(84) }
            //    }
            //};


            DFS(root, val);
            if (nodeElementFound == null)
            {
                Console.WriteLine($"Number {val} doest not exist in the tree");
            }
            else
            {
                Console.WriteLine(nodeElementFound.val + " " + nodeElementFound.right?.val + " " + nodeElementFound.left?.val);
            }
        }

        public void DFS(TreeNode node, int val)
        {
            if (nodeElementFound != null)
            {
                return;
            }

            if (node != null && node.val == val)
            {
                nodeElementFound = node;
                return;
            }

            if (node == null || (node.left == null && node.right == null))
            {
                nodeElementFound = null;
                return;
            }

            DFS(node.right, val);
            DFS(node.left, val);
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
