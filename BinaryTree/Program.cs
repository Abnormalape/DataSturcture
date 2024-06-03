using System.Security.Cryptography;

public class Program
{
    static void Main(string[] args)
    {
        BinaryTree<string> tree = new BinaryTree<string>("1");

        tree.AddLeftChild("2");
        tree.Left.AddLeftChild("4");
        tree.Left.AddRightChild("5");

        tree.AddRightChild("3");
        tree.Right.AddLeftChild("6");
        tree.Right.AddRightChild("7");

        
        tree.PostorderTravers();
           
        Console.WriteLine("찾을 값을 입력 하세요");
        string C = Console.ReadLine();


        if (tree.Find(C, out Node<string> node))
        {
            Console.WriteLine($"검색성공. 부모 : {node.Parent!.Data}, 값 : {node.Data}");
        }
        else
        {
            Console.WriteLine($"검색에 실패 했습니다.");
        }

        Console.WriteLine("삭제할 값을 입력 하세요");
        string D = Console.ReadLine();

        tree.DeleteNode(D);

        tree.PreorderTravers();

    }
}