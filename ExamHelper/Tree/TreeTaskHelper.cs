using System;

namespace ExamHelper
{
    public static class TreeTaskHelper
    {
        public static string Execute(int[] tree, TreeTask task) 
        {
            switch (task)
            {
                case TreeTask.HowManyEdgesDoNotMeetMaxBinaryHeapCondition:
                    return HowManyEdgesDoNotMeetMaxBinaryHeapCondition(tree);
                case TreeTask.HowManyEdgesDoNotMeetMinBinaryHeapCondition:
                    return HowManyEdgesDoNotMeetMinBinaryHeapCondition(tree);
                case TreeTask.IsMaxBinaryHeap:
                    return IsMaxBinaryHeap(tree);
                case TreeTask.IsMinBinaryHeap:
                    return IsMinBinaryHeap(tree);
            }

            throw new Exception();
        }

        private static string HowManyEdgesDoNotMeetMaxBinaryHeapCondition(int[] tree)
        {
            int edgesDoNotMeetDonditions = 0;

            TreeForEach(tree, (node, options) =>
            {
                if (node.Value < node.LeftChild) edgesDoNotMeetDonditions++;
                if (node.Value < node.RightChild) edgesDoNotMeetDonditions++;
            });

            return edgesDoNotMeetDonditions.ToString();
        }
        private static string HowManyEdgesDoNotMeetMinBinaryHeapCondition(int[] tree)
        {
            int edgesDoNotMeetDonditions = 0;

            TreeForEach(tree, (node, options) =>
            {
                if (node.Value > node.LeftChild) edgesDoNotMeetDonditions++;
                if (node.Value > node.RightChild) edgesDoNotMeetDonditions++;
            });

            return edgesDoNotMeetDonditions.ToString();
        }
        private static string IsMaxBinaryHeap(int[] tree)
        {
            bool isMaxBinaryHeap = true;

            TreeForEach(tree, (node, options) =>
            {
                if (node.Value < node.LeftChild || node.Value < node.RightChild) 
                {
                    options.ContinueRunning = false;
                    isMaxBinaryHeap = false;
                }
            });

            return isMaxBinaryHeap ? "Jā" : "Nē";
        }
        private static string IsMinBinaryHeap(int[] tree) 
        {
            bool isMaxBinaryHeap = true;

            TreeForEach(tree, (node, options) =>
            {
                if (node.Value > node.LeftChild || node.Value > node.RightChild)
                {
                    options.ContinueRunning = false;
                    isMaxBinaryHeap = false;
                }
            });

            return isMaxBinaryHeap ? "Jā" : "Nē";
        }

        private static void TreeForEach(int[] tree, Action<Node, LoopOptions> action, int nodeIndex = 0) 
        {
            LoopOptions options = new LoopOptions();
            while (nodeIndex < tree.Length && options.ContinueRunning) 
            {
                int? leftChild = nodeIndex * 2 < tree.Length ? tree[nodeIndex * 2] : null;
                int? rightChild = nodeIndex * 2 + 1 < tree.Length ? tree[nodeIndex * 2 + 1] : null;

                Node node = new Node(tree[nodeIndex], leftChild, rightChild);
                action(node, options);

                nodeIndex++;
            }
        }
    }
}
