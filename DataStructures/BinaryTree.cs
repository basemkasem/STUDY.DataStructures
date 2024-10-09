namespace DataStructures;

public class BinaryTree<TData> where TData : IComparable<TData>
{
    private TreeNode _root;

    public void Balance()
    {
        List<TData> nodes = new List<TData>();
        InOrderToArray(_root, nodes);
        _root = RecursiveBalance(0, nodes.Count -1 , nodes);
    }

    private void InOrderToArray(TreeNode node, List<TData> nodes)
    {
        if (node == null) return;
        
        InOrderToArray(node.Left, nodes);
        nodes.Add(node.Data);
        InOrderToArray(node.Right, nodes);
    }

    private TreeNode RecursiveBalance(int start, int end, List<TData> nodes)
    {
        if (start > end) return null;
        
        int mid = (start + end) / 2;
        TreeNode newNode = new TreeNode(nodes[mid]);
        newNode.Left = RecursiveBalance(start, mid - 1, nodes);
        newNode.Right = RecursiveBalance(mid + 1, end, nodes);
        
        return newNode;
    }

    public void BSInsert(TData data)
    {
        TreeNode newNode = new TreeNode(data);
        if (_root == null)
        {
            _root = newNode;
            return;
        }
        TreeNode currentNode = _root;

        while (currentNode != null)
        {
            if (currentNode.Data.CompareTo(data) > 0)
            {
                if (currentNode.Left == null)
                {
                    currentNode.Left = newNode;
                    break;
                }
                else
                {
                    currentNode = currentNode.Left;
                }
            }
            else
            {
                if (currentNode.Right == null)
                {
                    currentNode.Right = newNode;
                    break;
                }
                else
                {
                    currentNode = currentNode.Right;
                }
            
            }
        }
    }

    public bool IsExists(TData data)
    {
      return BSFind(data) != null;
    }

    NodeAndParent FindNodeAndParent(TData data)
    {
        TreeNode currentNode = _root;
        TreeNode parent = null;
        NodeAndParent nodeAndParentInfo = null;
        bool left  = false;
        while (currentNode != null)
        {
            if (currentNode.Data.CompareTo(data) == 0)
            {
                nodeAndParentInfo = new NodeAndParent() { _node = currentNode , _parent = parent, isLeft = left };
                break;
            }
            else if (currentNode.Data.CompareTo(data) > 0)
            {
                parent = currentNode;
                left = true;
                currentNode = currentNode.Left;
            }
            else
            {
                parent = currentNode;
                left = false;
                currentNode = currentNode.Right;
            }
        }
        return nodeAndParentInfo;
    }
    private TreeNode BSFind(TData data)
    {
        TreeNode currentNode = _root;
        while (currentNode != null)
        {
            if (currentNode.Data.CompareTo(data) == 0)
            {
                return currentNode;
            }
            else if (currentNode.Data.CompareTo(data) > 0)
            {
                currentNode = currentNode.Left;
            }
            else
            {
                currentNode = currentNode.Right;
            }
        }
        return null;
    }

    public void BSDelete(TData data)
    {
        NodeAndParent nodeAndParentInfo = FindNodeAndParent(data);
        if (nodeAndParentInfo == null) return;
        if (nodeAndParentInfo._node.Left != null && nodeAndParentInfo._node.Right != null)
        {
            BSDeleteHasChild(nodeAndParentInfo._node);
        }
        else if (nodeAndParentInfo._node.Left != null ^ nodeAndParentInfo._node.Right != null)
        {
            BsDeleteHasOneChild(nodeAndParentInfo._node);
        }
        else
        {
            BSDeleteLeaf(nodeAndParentInfo);
        }
    }

    private void BSDeleteLeaf(NodeAndParent nodeAndParentInfo)
    {
        if (nodeAndParentInfo._parent == null)
        {
            _root = null;
        }
        else 
        {
            if (nodeAndParentInfo.isLeft)
            {
                nodeAndParentInfo._parent.Left = null;
            }
            else
            {
                nodeAndParentInfo._parent.Right = null; 
            }
        }

    }
    private void BSDeleteHasChild(TreeNode nodeToDelete)
    {
        TreeNode currentNode = nodeToDelete.Right;
        TreeNode parentNode = null;
        while (currentNode.Left != null)
        {
            parentNode = currentNode;
            currentNode = currentNode.Left;
        }

        if (parentNode != null)
        {
            parentNode.Left = currentNode.Right;
        }
        else
        {
            nodeToDelete.Right = currentNode.Right;
        }
        nodeToDelete.Data = currentNode.Data;
    }

    private void BsDeleteHasOneChild(TreeNode nodeToDelete)
    {
        TreeNode nodeToReplace = null;
        if (nodeToDelete.Left != null)
        {
            nodeToReplace = nodeToDelete.Left;
        }
        else
        {
            nodeToReplace = nodeToDelete.Right;
        }
        
        nodeToDelete.Data = nodeToReplace.Data;
        nodeToDelete.Left = nodeToReplace.Left;
        nodeToDelete.Right = nodeToReplace.Right;
    }
    
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
    
    //TODO: Douplication Handling: (1) Don't Allow. (2) Allow (Applied). (3) Add counter. 
    
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

    class NodeAndParent
    {
        internal TreeNode _node;
        internal TreeNode _parent;
        internal bool isLeft;
    }
}