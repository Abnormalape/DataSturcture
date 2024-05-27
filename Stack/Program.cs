using System;
class Program
{
    static Random random;
    static float GetRandomInRandge(float min, float max)
    {
        if (random == null)
        {
            {
                random = new Random();
            }
        }
        float randomNumber = (float)random.NextDouble();
        randomNumber *= (max - min);
        randomNumber += min;

        // 난수 반환.
        return randomNumber;
    }

    static void Main(string[] args)
    {
        ExpStack<float> stack = new ExpStack<float>();

        //Console.WriteLine("첫번째 게임 종료 - 현재 경험치 145.5f");
        //stack.Push(145.5f);

        //Console.WriteLine("두번째 게임 종료 - 현재 경험치 183.25f");
        //stack.Push(183.25f);

        //Console.WriteLine("세번째 게임 종료 - 현재 경험치 162.3f");
        //stack.Push(162.3f);

        for (int ix = 0; ix < 10; ix++)
        {
            float exp = GetRandomInRandge(100.0f, 150.0f);
            Console.WriteLine($"{ix + 1}번째 게임 종료 - 현재 경험치 {exp}");
            stack.Push(exp);
        }


        int count = stack.Count;
        for (int ix = 0; ix < count; ++ix)
        {
            if (stack.Pop(out float value))
            {
                Console.WriteLine($"현재 경험치 : {value}");
            }
        }
        Console.ReadKey();
    }
}

