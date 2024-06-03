class Program
{
    //static void RecursiveFunction(int count)
    //{
    //    if (count == 5)
    //    {
    //        return;
    //    }
    //    Console.WriteLine($"count: {count}");
    //    RecursiveFunction(count + 1);
    //}
    //static void Main(string[] args)
    //{
    //    RecursiveFunction(0);
    //}

    static void Main(string[] args)
    {
        Tree<string> tree = new Tree<string>("A");
        tree.AddChild("B");
        tree.Children[0].AddChild("E");
        tree.Children[0].AddChild("F");
        tree.Children[0].AddChild("G");

        tree.AddChild("C");
        tree.Children[1].AddChild("H");
        tree.Children[1].AddChild("I");
        tree.AddChild("D");
        tree.Children[2].AddChild("J");

        //전위순회.
        //tree.PreorderTraverse(node => { Console.WriteLine($"{node.Data}"); });
        tree.PreorderTraverse(node => { Console.WriteLine($"{node.Data}"); });

        tree.PostorderTraverse(node => { Console.WriteLine($"{node.Data}"); });

        //if(tree.Find("J",out Node<string> outNode))
        //{
        //    Console.WriteLine($"검색 성공. 부모: {outNode.Parent.Data} 값: {outNode.Data}");
        //}

        if (tree.Delete("B"))
        {
            Console.WriteLine("삭제성공");
            tree.PreorderTraverse(node => { Console.WriteLine($"{node.Data}"); });
        }
        else
        {
            Console.WriteLine("삭제 실패");
        }
    }
    static void PrintNode<T>(Node<T> node)
    {
        Console.WriteLine($"{node.Data}");
    }
}
