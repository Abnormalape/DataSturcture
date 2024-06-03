using System;
public class LinkedList<T>
{
    class Node
    {
        // 데이터 필드.
        public T Data { get; set; }

        // 링크 필드.
        public Node Next { get; set; }

        public Node()
        {
            Data = default(T);
            Next = null;
        }

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }


    private Node head = null;

    private int count = 0;

    public int Count { get { return count; } }

    public LinkedList()
    {
        head = null;
        count = 0;
    }

    //연결 리스트 첫 부분에 데이터를 삽입하는 함수.
    public void AddToHead(T data)
    {
        //새 노드 생성.
        Node newNode = new Node(data);
        //생성한 노드 삽입.
        if (head == null)
        {
            head = newNode;
        }
        else
        {
            newNode.Next = head;
            head = newNode;
        }
        count++;
    }



    //연결 리스트 마지막에 데이터를 삽입하는 함수.
    public void AddToLast(T data)
    {
        Node newNode = new Node(data);

        //마지막 위치에 노드 삽입.

        //경우1. head가 없는 경우.
        if (head == null)
        {
            head = newNode;
        }
        //경우2. head가 있는 경우.
        else
        {
            Node current = head;

            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = newNode;
        }

        count++;
    }
    
    //값을 검색해서 노드를 삭제하는 함수.
    public bool DeleteNode(T data)
    {
        //경우1 - 리스트가 빈 경우.
        if (head == null)
        {
            Console.WriteLine("Error: Can not Delete, List is Empty.");
            return false;
        }

        Node current = head;
        Node trail = null;

        while(current != null)
        {
            if (current.Data.Equals(data))
            {
                break;
            }

            trail = current;
            current = current.Next;
        }
        //경우2 - 리스트가 비지 않으나, 값을 찾음.

        //경우2 - 1 : 그 노드가 head인 경우
        if(current != null && current == head)
        {
            head = head.Next;
        }
        //경우2 - 2 : 그 노드가 head가 아닌 경우
        else if (current != null  && current != head)
        {
            trail.Next = current.Next;
            current.Next = null;
        }
        //경우3 - 리스트가 비지 않고 값을 찾지 못함.
        else if (current == null)
        {
            Console.WriteLine($"Error: {data} Not Found");
            return false;
        }

        count--;
        return true;
    }
    //특정 값이 존재하는지 검색을 하는 함수.
    public bool Find(T data)
    {
        if(head == null)
        {
            Console.WriteLine("Error: Search Failed, List is Empty");
            return false;
        }

        Node current = head;
        Node trail = null;

        while(current != null)
        {
            if (current.Data.Equals(data))
            {
                break ;
            }

            trail = current;
            current = current.Next;
        }

        return false;
    }

    //데이터 출력 함수.
    public void Print()
    {
        if(head == null)
        {
            Console.WriteLine("Error: No Data to Print");
            return;
        }
        Node current = head;
        while (current != null)
        {
            Console.WriteLine($"{current.Data} ");
            current = current.Next;
        }
        Console.WriteLine();
    }

}

