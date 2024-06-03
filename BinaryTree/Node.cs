public class Node<T>
{
    public T Data { get; set; }

    //부모 노드.
    public Node<T> Parent { get; set; }

    //왼쪽 자손.
    public Node<T> Left { get; set; }
    //오른쪽 자손.
    public Node<T> Right { get; set; }

    //생성자
    public Node(T data = default(T))
    {
        this.Data = data;
        Parent = null;
        Left = null;
        Right = null;
    }


    //메시지(공개메소드) - 인터페이스(약속)

    //왼쪽 자손 추가.
    public void AddLeftChild(T data)
    {
        AddLeftChild(new Node<T>(data));
    }

    public void AddLeftChild(Node<T> child)
    {
        //부모를 내 노드로 지정
        child.Parent = this;
        //내 왼쪽 자손으로 새노드를 등록
        Left = child;
    }

    //오른쪽 자손 추가.
    public void AddRightChild(T data)
    {
        AddRightChild(new Node<T>(data));
    }

    public void AddRightChild(Node<T> child)
    {
        //부모를 내 노드로 지정
        child.Parent = this;
        //내 오늘쪽 자손으로 새노드를 등록
        Right = child;
    }

    //삭제.
    public void Destroy()
    {
        // 노드의 부모가 있는 경우 삭제를 진행.
        if(Parent != null)
        {
            //내가 부모의 왼쪽 자손일 경우.
            if(Parent.Left == this)
            {
                Parent.Left = null;
            }
            //내가 부모의 오른쪽 자손일 경우.
            if(Parent.Right == this)
            {
                Parent.Right = null;
            }
        }
        else
        {
            Console.WriteLine("루트 노드는 삭제가 불가능.");
        }
    }


    //순회 (전,중,후 - 부모가 언제 방문하는지)

    //검색,탐색 - Search Find Select


}

