namespace TextBasedAdventureGameV2.DataStructure;

public class TreeNode<T>
{
    public T Value { get; }
    public TreeNode<T> Parent { get; }
    public List<TreeNode<T>> Children { get; }

    public TreeNode(T value, TreeNode<T> parent)
    {
        Value = value;
        Parent = parent;
        Children = new List<TreeNode<T>>();
    }

    public TreeNode<T> Add(T value)
    {
        var node = new TreeNode<T>(value, this);
        Children.Add(node);
        return node;
    }
}
