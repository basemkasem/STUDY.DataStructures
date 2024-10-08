namespace DataStructures;

public class BinaryTree<TData> where TData : IComparable<TData>
{
    private TreeNode _root;

    public void Insert(TData data)
    {
        TreeNode newNode = new TreeNode(data);

        if (_root == null)
        {
            _root = newNode;
            return;
        }

        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(_root);
        while (q.HasData())
        {
            TreeNode currentNode = q.Dequeue();
            if (currentNode.Left == null)
            {
                currentNode.Left = newNode;
                break;
            }
            else
            {
                q.Enqueue(currentNode.Left);
            }

            if (currentNode.Right == null)
            {
                currentNode.Right = newNode;
                break;
            }
            else
            {
                q.Enqueue(currentNode.Right);
            }
        }
    }

    public int Height()
    {
        return InternalHeight(_root);
    }
    private int InternalHeight(TreeNode node)
    {
        if (node == null) return 0;
        return 1 + Math.Max(InternalHeight(node.Left), InternalHeight(node.Right));
    }

    public void PreOrderTraversal()
    {
        Console.Write("Pre order traversal: ");
        InternalPreOrderTraversal(_root);
        Console.WriteLine();
    }
    private void InternalPreOrderTraversal(TreeNode node)
    {
        if (node == null) return;
        Console.Write(node.Data + " -> ");
        InternalPreOrderTraversal(node.Left);
        InternalPreOrderTraversal(node.Right);
        
    }
    
    public void InOrderTraversal()
    {
        Console.Write("In order traversal: ");
        InternalInOrderTraversal(_root);
        Console.WriteLine();
    }
    private void InternalInOrderTraversal(TreeNode node)
    {
        if (node == null) return;
        InternalInOrderTraversal(node.Left);
        Console.Write(node.Data + " -> ");
        InternalInOrderTraversal(node.Right);
        
    }
    
    public void PostOrderTraversal()
    {
        Console.Write("Post order traversal: ");
        InternalPostOrderTraversal(_root);
        Console.WriteLine();
    }
    private void InternalPostOrderTraversal(TreeNode node)
    {
        if (node == null) return;
        InternalPostOrderTraversal(node.Left);
        InternalPostOrderTraversal(node.Right);
        Console.Write(node.Data + " -> ");
        
        
    }
    
    //TODO: Find(Data) -> Apply any traversal method
    //TODO: Delete(Data) -> 
    
    #region PrintMethods

    class NodeInfo
    {
        public TreeNode Node;
        public string Text;
        public int StartPos;

        public int Size
        {
            get { return Text.Length; }
        }

        public int EndPos
        {
            get { return StartPos + Size; }
            set { StartPos = value - Size; }
        }

        public NodeInfo Parent, Left, Right;
    }

    public void Print(int topMargin = 2, int LeftMargin = 2)
    {
        if (this._root == null) return;
        int rootTop = Console.CursorTop + topMargin;
        var last = new List<NodeInfo>();
        var next = this._root;
        for (int level = 0; next != null; level++)
        {
            var item = new NodeInfo { Node = next, Text = next.Data.ToString() };
            if (level < last.Count)
            {
                item.StartPos = last[level].EndPos + 1;
                last[level] = item;
            }
            else
            {
                item.StartPos = LeftMargin;
                last.Add(item);
            }

            if (level > 0)
            {
                item.Parent = last[level - 1];
                if (next == item.Parent.Node.Left)
                {
                    item.Parent.Left = item;
                    item.EndPos = Math.Max(item.EndPos, item.Parent.StartPos);
                }
                else
                {
                    item.Parent.Right = item;
                    item.StartPos = Math.Max(item.StartPos, item.Parent.EndPos);
                }
            }

            next = next.Left ?? next.Right;
            for (; next == null; item = item.Parent)
            {
                Print(item, rootTop + 2 * level);
                if (--level < 0) break;
                if (item == item.Parent.Left)
                {
                    item.Parent.StartPos = item.EndPos;
                    next = item.Parent.Node.Right;
                }
                else
                {
                    if (item.Parent.Left == null)
                        item.Parent.EndPos = item.StartPos;
                    else
                        item.Parent.StartPos += (item.StartPos - item.Parent.EndPos) / 2;
                }
            }
        }

        Console.SetCursorPosition(0, rootTop + 2 * last.Count - 1);
    }

    private void Print(NodeInfo item, int top)
    {
        SwapColors();
        Print(item.Text, top, item.StartPos);
        SwapColors();
        if (item.Left != null)
            PrintLink(top + 1, "┌", "┘", item.Left.StartPos + item.Left.Size / 2, item.StartPos);
        if (item.Right != null)
            PrintLink(top + 1, "└", "┐", item.EndPos - 1, item.Right.StartPos + item.Right.Size / 2);
    }

    private void PrintLink(int top, string start, string end, int startPos, int endPos)
    {
        Print(start, top, startPos);
        Print("─", top, startPos + 1, endPos);
        Print(end, top, endPos);
    }

    private void Print(string s, int top, int Left, int Right = -1)
    {
        Console.SetCursorPosition(Left, top);
        if (Right < 0) Right = Left + s.Length;
        while (Console.CursorLeft < Right) Console.Write(s);
    }

    private void SwapColors()
    {
        var color = Console.ForegroundColor;
        Console.ForegroundColor = Console.BackgroundColor;
        Console.BackgroundColor = color;
    }

    #endregion

    class TreeNode
    {
        public TData Data { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }

        public TreeNode(TData data)
        {
            Data = data;
        }
    }
}