class Program
{
    static void Main(string[] args)
    {
        BinarySearchTree tree = new BinarySearchTree();

        tree.Insert(10);
        tree.Insert(13240);
        tree.Insert(-342);
        tree.Insert(76);
        tree.Insert(67);
        tree.Insert(-438);
        tree.Insert(9);
        tree.Insert(1);
        tree.Insert(384);
        tree.Insert(-6);
        tree.Insert(3);
        tree.Insert(12);
        tree.Insert(68);
        tree.Insert(-2435);

        tree.InorderTravers();

        int a = 76;
        tree.Delete(a);
        Console.WriteLine("76 삭제후");
        tree.InorderTravers();


    }
}

