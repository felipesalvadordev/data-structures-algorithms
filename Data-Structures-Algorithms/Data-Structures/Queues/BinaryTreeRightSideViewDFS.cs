using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures_Algorithms.Data_Structures.Queues
{
    internal class BinaryTreeRightSideViewDFS
    {
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


            TreeNode root = new TreeNode(1)
            {
                left = new TreeNode(2) { right = new TreeNode(5) },
                right = new TreeNode(3) { left = new TreeNode(4) }
            };


            //TreeNode root = new TreeNode(1)
            //{
            //    left = new TreeNode(2) { left = new TreeNode(4) { left = new TreeNode(5) } },
            //    right = new TreeNode(3) { left = null, right = null }
            //};

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

            var visibleElements = RightSideView(root);

            foreach (var element in visibleElements)
            {
                Console.WriteLine(element);
            }
        }
        public List<int> RightSideView(TreeNode root)
        {
            List<int> visibleElements = new List<int>();
            Queue<TreeNode> heightLevelQueue = new Queue<TreeNode>();
            heightLevelQueue.Enqueue(root);

            //Will iterate over the levels of the tree. The maximum of elements in the queue
            //will be 2 (right and left)
            while (heightLevelQueue.Count > 0)
            {
                TreeNode rightMostQueueElement = null;
                int qLen = heightLevelQueue.Count;

                for (int i = 0; i < qLen; i++)
                {
                    TreeNode node = heightLevelQueue.Dequeue();
                    if (node != null)
                    {
                        rightMostQueueElement = node;//The last one got from the queue is the rightmost
                        //Add the children of current node
                        heightLevelQueue.Enqueue(node.left);
                        //The right is the last inserted to be the rightMost value to be add
                        heightLevelQueue.Enqueue(node.right);
                    }
                }
                if (rightMostQueueElement != null)//The rightmost of queue that was dequeued
                {
                    visibleElements.Add(rightMostQueueElement.val);
                }
            }
            return visibleElements;
        }
    }
}
