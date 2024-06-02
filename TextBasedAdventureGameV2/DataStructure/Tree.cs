namespace TextBasedAdventureGameV2.DataStructure;

public class Tree<T>
{
    private Stack<TreeNode<T>> _stack = new Stack<TreeNode<T>>();
    public List<TreeNode<T>> Nodes { get; } = new List<TreeNode<T>>();

    public Tree<T> Begin(T value)
    {
        if (_stack.Count == 0)
        {
            var node = new TreeNode<T>(value, null);
            Nodes.Add(node);
            _stack.Push(node);
        }
        else
        {
            var node = _stack.Peek().Add(value);
            _stack.Push(node);
        }

        return this;
    }

    public Tree<T> Add(T value)
    {
        _stack.Peek().Add(value);

        return this;
    }

    public Tree<T> End()
    {
        _stack.Pop();

        return this;
    }

    public void PrintNode(TreeNode<T> node, int level)
    {
        Console.WriteLine("{0}{1}", new string(' ', level * 3), node.Value);
        level++;
        node.Children.ForEach(p => PrintNode(p, level));
    }
}
