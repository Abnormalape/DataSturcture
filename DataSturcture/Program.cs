

using System.Diagnostics;
using System.Runtime.ExceptionServices;

class Program
{
    //static char ToLower(char upperCase)
    //{
    //    int i = upperCase + 32;
    //    return (char)i;
    //}
    //static char ToUpper(char lowerCase)
    //{
    //    int i = lowerCase - 32;
    //    return (char)i;
    //}
    static void Main(string[] args)
    {
        
        // 크기가 10인 배열 객체 생성.
        Array<int> array = new Array<int>(10);

        
        // 값 설정.
        for (int ix = 0; ix < array.Length; ++ix)
        {
            array[ix] = ix + 1;
        }

        // 값 읽고 출력.
        for (int ix = 0; ix < array.Length; ++ix)
        {
            Console.Write($"[{ix}] = {array[ix]} ");
            //array.SetData(ix, ix + 1);
        }

        Console.WriteLine();

        // 그냥 종료되지 말라고 추가하는 의미 없는 코드.
        Console.ReadKey();
    }
}
