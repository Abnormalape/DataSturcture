using System;
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

        for (int i = 0; i < bucketCount; i++)
        {
            table[i] = new LinkedList<Pair<TKey, TValue>>();
        }
    }

    //데이터 추가
    //이거 어느 해쉬 테이블이냐 이거
    public void Add(TKey key, TValue value)
    {
        // 저장할 배열의 위치 결정 - 해시 함수.
        int bucketIndex = GenerateHash(key) % bucketCount;

        // 저장할 위치에 이미 같은 데이터가 있지 않은지 검증.
        LinkedList<Pair<TKey, TValue>> list = table[bucketIndex];

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

        //배열위치가져오기.

        //검색.

        //삭제 혹은 실패.
        return false;
    }

    //검색1 - 키로 검색, value반환

    //검색2 - 키로 검색 Pair<key, value>반환    

    //출력

    //메소드 - 해시생성
    private int GenerateHash(TKey key)
    {
        int hash = 0;
        char[] chars = key.ToString().ToCharArray();

        for (int i = 0; (i < chars.Length); i++)
        {
            hash = hash *31 + chars[i];
        }

        return hash;
    }
}
