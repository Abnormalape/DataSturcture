using System;
class Program
{
    static int GetSimpleStringHash(string keyInput)
    {
        int hash = 0;
        foreach (char c in keyInput)
        {
            // 문자열 내부 각 문자의 ASCII 숫자 값을 더하기.
            hash += (int)c;
        }

        return hash;
    }
    static void Main(string[] args)
    {
        //string input = "Hello World";
        //int hash = GetSimpleStringHash(input);

        //Console.WriteLine($"{input}에 대한 해시: {hash}");

        //Console.ReadKey();
        //======================================================



        HashTable<string, string> table = new HashTable<string, string>();

        // 데이터 추가.
        // Add가 왜 문제가 생기는건지 알 수 가 없네
        table.Add("Ronnie", "010-12345678");
        table.Add("Ronnie", "010-37610942");
        table.Add("Kevin", "010-32979287");
        table.Add("Baker", "010-29871982");
        table.Add("Taejun", "010-39487298");

        //검색.
        if(table.Find("Ronnie",out Pair<string, string> pair))
        {
            Console.WriteLine($"Search Result: {pair.Key}, {pair.Value}");
        }

        // 삭제.
        table.Delete("Ronnie");
        table.Delete("Kevin");

        // 출력.
        table.Print();

        Console.ReadKey();
    }
}

