using System;

public class Node<T>
{
    public T Data { get; set; }

    public Node<T> Parent { get; set; }

    public List<Node<T>> Children { get; set; }

    public int Count
    {
        get
        {
            int count = 1;
            foreach (Node<T> child in Children)
            {
                count += child.Count;
            }

            return count;
        }
    }

    public Node()
    {
        Data = default(T);
        Parent = null;
        Children = new List<Node<T>>();
    }

    public Node(T data)
    {
        Data = data;
        Parent = null;
        Children = new List<Node<T>>();
    }

    public void AddChild(T data)
    {
        Node<T> newChild = new Node<T>(data);
        newChild.Parent = this;
        Children.Add(newChild);
    }

    public void AddChild(Node<T> child)
    {
        child.Parent = this;
        Children.Add(child);
    }

    public void Destroy()
    {
        // 부모의 자식 목록에서 나를 제거.
        if (Parent != null)
        {
            Parent.Children.Remove(this);
        }
    }
}