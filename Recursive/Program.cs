class Program
{
    static void RecursiveFunction(int count)
    {
        if(count == 5)
        {
            return;
        }
        Console.WriteLine($"count: {count}");
        RecursiveFunction(count + 1);
    }
    static void Main(string[] args)
    {
        RecursiveFunction(0);
    }
}
