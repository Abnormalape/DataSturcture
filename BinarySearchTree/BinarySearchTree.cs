using System.Runtime.CompilerServices;
using System.Security.AccessControl;

public class BinarySearchTree
{
    private Node root;

    //생성.
    public BinarySearchTree()
    {
        root = null;
    }

    //삽입.
    //규칙 - 중복 허용 불가
    //어디에 추가할까?
    //1. 루트가 null 이면 루트에 지정
    //2. 비교 노트보다 값이 작으면 왼쪽 하위트리로 이동
    //3. 크다면 오른쪽으로
    public bool Insert(int data)
    {
        // 중복된 값이 있는지 확인.
        if (Find(data))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("오류: 이미 중복된 값이 있어 데이터를 추가하지 못했습니다.");
            Console.ForegroundColor = ConsoleColor.White;
            return false;
        }

        // 루트가 null이면 루트로 지정.
        if (root == null)
        {
            root = new Node(data);
            return true;
        }

        // 2와 3의 경우를 위해 재귀적으로 확인하면서 노드 추가.
        root = InsertRecursive(root, null, data);
        return true;
    }

    //재귀적으로 삽입을 처리하는 함수
    //node 현재 비교를 진행할 노드
    //parent node의 부모노드
    //data 삽입하려는 데이터
    public Node InsertRecursive(Node node, Node parent, int data)
    {
        if (node == null) { Node newNode = new Node(data); newNode.Parent = parent; return newNode; }
        //추가하려는 값이 작으면 왼쪽, 크면 오른쪽 서브트리로 탐색
        if (node.Data > data)
        {
            node.Left = InsertRecursive(node.Left, node, data);
        }
        else if (node.Data < data)
        {
            node.Right = InsertRecursive(node.Right, node, data);
        }
        return node;
    }

    //삭제.
    public void Delete(int data)
    {
        DeleteRecursive(root , data);
    }
    private Node DeleteRecursive(Node node, int data)
    {
        //1 - 왼쪽에서 가장 큰값을 삭제노드의 위치와 변경.
        //2 - 오른쪽에서 가장 작은값을 삭제노드의 위치와 변경.

        if (node == null)
        {
            Console.WriteLine("오류 : 삭제노드 찾지못함.");
            return null;
        }
        //경우1 - 삭제값이 지금 값보다 작은 경우 왼쪽으로.
        if(node.Data > data)
        {
            node.Left = DeleteRecursive(node.Left, data);
        }
        //경우2 - 삭제값이 지금 값보다 큰 경우 오른쪽으로.
        else if (node.Data < data)
        {
            node.Right = DeleteRecursive(node.Right, data);
        }
        //경우3 - 삭제값이 현재값인 경우{
        else
        {
            //3-1 : 자식이 둘.
            if(node.Left != null && node.Right != null)
            {
                node.Data = SearchMinNode(node.Right).Data;
                node.Right = DeleteRecursive(node.Right, node.Data);
                //왼쪽에서 가장 큰값으로 대치해도 된다.
            }

            //3-2 : 자식이 하나.
            else if(node.Left != null || node.Right != null)
            {
                if(node.Left != null)
                {
                    return node.Left;
                }
                if(node.Right != null)
                {
                    return node.Right;
                }
            }
            //3-3 : 자식이 없음.
            else 
            {
                return null;
                //(node.Left == null && node.Right == null)
            }
        }
        return node;
    }
    private Node SearchMinNode(Node node)
    {
        while(node.Left != null)
        {
            node = node.Left;
        }

        return node;
    }

    //탐색.
    public bool Find(int data)
    {
        return FindRecursive(root, data);

    }
    private bool FindRecursive(Node node, int data)
    {
        if (node == null) { return false; }

        if (node.Data.Equals(data))
        {
            return true;
        }

        if (node.Data > data)
        {
            return FindRecursive(node.Left, data);
        }
        else
        {
            return FindRecursive(node.Right, data);
        }
    }
    //중위 순회.

    public void InorderTravers()
    {
        InorderTraversRecursive(root);
    }
    private void InorderTraversRecursive(Node node)
    {
        if (node == null) { return; }

        InorderTraversRecursive(node.Left);
        Console.Write($"{node.Data} ");
        InorderTraversRecursive(node.Right);
    }
}

