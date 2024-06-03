using System;
using System.Net.WebSockets;
using System.Runtime.InteropServices;



public class HashTable<TKey, TValue>
{
    //필드

    //버킷 카운트 - 소수로 하는것이 유리함.
    private const int bucketCount = 19;
    //저장소
    private LinkedList<Pair<TKey, TValue>>[] table;
    //메시지

    //생성
    public HashTable()
    {
        table = new LinkedList<Pair<TKey, TValue>>[bucketCount];

        for (int ix = 0; ix < bucketCount; ix++)
        {
            table[ix] = new LinkedList<Pair<TKey, TValue>>(); // table[0~18] 생성
        }
    }

    //데이터 추가
    //이거 어느 해쉬 테이블이냐 이거
    public void Add(TKey key, TValue value)
    {
        // 저장할 배열의 위치 결정 - 해시 함수.
        int bucketIndex = GenerateHash(key) % bucketCount; // bucketindex는 19로 나눈 나머지 : -18 ~ 18의 정수

        // 저장할 위치에 이미 같은 데이터가 있지 않은지 검증.
        LinkedList<Pair<TKey, TValue>> list = table[bucketIndex]; // table[bucketindex]는 table[0~18], 근데 이게 어떻게 outRange가 나와?


        // 데이터가 있는지 확인.
        foreach (LinkedList<Pair<TKey, TValue>>.Node node in list)
        {
            // 링크드리스트에 같은 키를 가진 데이터가 있는 지 확인 후 있다면 오류.
            if (node.Data.Key.Equals(key))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("오류: 이미 동일한 데이터가 저장되어 있습니다.");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
        }

        // 문제가 없다면, 링크드 리스트에 추가.
        list.AddToLast(new Pair<TKey, TValue>(key, value));
    }
    //데이터 삭제
    public bool Delete(TKey key)
    {
        //배열위치찾기.
        int bucketIndex = GenerateHash(key) % bucketCount;
        //배열위치가져오기.
        var list = table[bucketIndex];

        
        //검색.
        foreach (LinkedList<Pair<TKey,TValue>>.Node node in list)
        {
            if (node.Data.Key.Equals(key))
            {
                list.DeleteNode(node.Data);
                Console.WriteLine($"Key: {key} has Deleted");
                return true;
            }
        }
        //삭제 혹은 실패.
        Console.WriteLine($"Error: No Data Found");
        return false;
    }

    //검색1 - 키로 검색, value반환
    public bool Find(TKey key, out TValue outValue)
    {
        //배열위치찾기.
        int bucketIndex = GenerateHash(key) % bucketCount;
        //배열위치가져오기.
        var list = table[bucketIndex];

        if (list.Count == 0)
        {
            Console.WriteLine("Error: No Data Found");

            outValue = default(TValue);
            return false;
        }

        
        //검색.
        foreach (LinkedList<Pair<TKey, TValue>>.Node node in list)
        {
            if (node.Data.Key.Equals(key))
            {
                outValue = node.Data.Value;
                return true;
            }
        }
        //삭제 혹은 실패.
        Console.WriteLine($"Error: No Data Found");
        outValue = default(TValue);
        return false;
    }


    //검색2 - 키로 검색 Pair<key, value>반환    
    public bool Find(TKey key, out Pair<TKey,TValue> outValue)
    {
        //배열위치찾기.
        int bucketIndex = GenerateHash(key) % bucketCount;
        //배열위치가져오기.
        var list = table[bucketIndex];

        if (list.Count == 0)
        {
            Console.WriteLine("Error: No Data Found");

            outValue = default(Pair<TKey, TValue>);
            return false;
        }


        //검색.
        foreach (LinkedList<Pair<TKey, TValue>>.Node node in list)
        {
            if (node.Data.Key.Equals(key))
            {
                outValue = node.Data;
                return true;
            }
        }
        //삭제 혹은 실패.
        Console.WriteLine($"Error: No Data Found");
        outValue = default(Pair<TKey, TValue>);
        return false;
    }

    //출력
    public void Print()
    {
        foreach(var list in table)
        {
            if (list.Count == 0)
            {
                continue;
            }
            foreach (LinkedList<Pair<TKey,TValue>>.Node node in list)
            {
                Console.WriteLine($"Key: {node.Data.Key} \n Value: {node.Data.Value}");
            }
        }
    }
    //메소드 - 해시생성
    private int GenerateHash(TKey key)
    {
        int hash = 0;
        char[] chars = key.ToString().ToCharArray();

        for (int i = 0; (i < chars.Length); i++)
        {
            hash = hash * 31 + chars[i];
        }

        return Math.Abs(hash); // 여기서 음수처리
    }
}
