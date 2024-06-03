public class BinaryTree<T>
{
    //루트노드.
    private Node<T> root;
    // 왼쪽 자손 노드.
    public Node<T> Left
    {
        get
        {
            return root.Left;
        }
    }

    // 오른쪽 자손 노드.
    public Node<T> Right
    {
        get
        {
            return root.Right;
        }
    }

    //메시지.

    //생성자.
    public BinaryTree(T data)
    {
        root = new Node<T>(data);
    }
    //왼쪽자손추가.
    public void AddLeftChild(T data, Node<T> parent = null)
    {
        AddLeftChild(new Node<T>(data), parent);
    }
    public void AddLeftChild(Node<T> child, Node<T> parent = null)
    {
        //부모 노드 지정.
        child.Parent = parent == null ? root : parent;
        //위에서 지정한 부모의 왼쪽 자손으로 새 노드를 추가.
        child.Parent.AddLeftChild(child);
    }
    //오른쪽자손추가.
    public void AddRightChild(T data, Node<T> parent = null)
    {
        AddRightChild(new Node<T>(data), parent);
    }
    public void AddRightChild(Node<T> child, Node<T> parent = null)
    {
        //부모 노드 지정.
        child.Parent = parent == null ? root : parent;
        //위에서 지정한 부모의 오른쪽 자손으로 새 노드를 추가.
        child.Parent.AddRightChild(child);
    }

    //순회 전중후.
    public void PreorderTravers(int depth = 0)
    {
        PreorderTraverseRecursive(root, depth);
    }
    private void PreorderTraverseRecursive(Node<T> node, int depth = 0)
    {
        // 종료(탈출) 조건 확인.
        if (node == null)
        {
            return;
        }
        // 출력.
        for (int ix = 0; ix < depth; ++ix)
        {
            Console.Write("  ");
        }
        Console.WriteLine($"{node.Data}");
        // 왼쪽 자손 방문.
        PreorderTraverseRecursive(node.Left, depth + 1);
        // 오른쪽 자손 방문.
        PreorderTraverseRecursive(node.Right, depth + 1);
    }

    public void PostorderTravers(int depth = 0)
    {
        PostorderTraverseRecursive(root, depth);
    }
    private void PostorderTraverseRecursive(Node<T> node, int depth = 0)
    {
        // 종료(탈출) 조건 확인.
        if (node == null)
        {
            return;
        }
        // 출력.
        
        // 왼쪽 자손 방문.
        PostorderTraverseRecursive(node.Left, depth + 1);
        // 오른쪽 자손 방문.
        PostorderTraverseRecursive(node.Right, depth + 1);

        for (int ix = 0; ix < depth; ++ix)
        {
            Console.Write("  ");
        }
        Console.WriteLine($"{node.Data}");
    }


    //탐색.
    public bool Find(T data, out Node<T> outNode)
    {
        return FindRecursive(data, root, out outNode);
    }
    //검색 재귀 메소드.
    //T data: 검색할 값.
    //Node<T> ndoe: 현재 검색 대상 노드.
    //out Node<T> outNode: 검색 성공시 노드.
    private bool FindRecursive(T data, Node<T> node, out Node<T> outNode)
    {
        //탈출조건확인.
        if (node == null)
        {
            outNode = null;
            return false;
        }
        //전위 순회와 같은 방식으로 검색을 진행.
        if (node.Data.Equals(data))
        {
            outNode = node;
            return true;
        }
        //재귀적으로 검색을 이어서 진행.
        bool result = FindRecursive(data, node.Left, out outNode);
        if (result) { return true; }
        //재귀적으로 검색을 다시 진행.
        result = FindRecursive(data, node.Right, out outNode);
        if (result) { return true; }
        //검색실패
        outNode = null; return result;
    }

    //삭제.
    public bool DeleteNode(T data)
    {
        //삭제노드 검색.
        bool result = Find(data, out Node<T> deleteNode);
        //성공시 삭제.
        if(result == true)
        {
            deleteNode.Destroy();
            return true;
        }
        //실패시 실패.
        Console.WriteLine("삭제노드 검색 실패");
        return false;
    }
}
