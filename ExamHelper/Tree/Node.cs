namespace ExamHelper
{
    public readonly struct Node
    {
        public int Value { get; }
        public int? LeftChild { get; }
        public int? RightChild { get; }

        public Node(int value, int? leftChild, int? rightChild) 
        {
            Value = value;
            LeftChild = leftChild;
            RightChild = rightChild;
        }
    }
}
