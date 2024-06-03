using System;
using System.Collections;
using System.Transactions;

class CustomList<T> : IEnumerator // customlist 프로젝트의 customlist를 대체해야 한다
{
    private T[] data;
    private int size = 0;
    private int capacity = 2;


    //여기부터//IEnumerator용 문장
    private int index = 0;
    private T current;

    public bool MoveNext()
    {
        if(index < size)
        {
            current = data[index];
            index++;
            return true;
        }
        return false;
    }
    public void Reset()
    {
        index = 0;
        current = default(T);
    }
    public object Current => throw new NotImplementedException();

    public IEnumerator GetEnumerator()
    {
        Reset();
        return this;
    }
    //여기까지//IEnumerator용 문장

    public CustomList()
    {
        data = new T[capacity];
        size = 0;
    }
    public T this[int index]
    {
        get
        {
            return data[index];
        }
        set
        {
            data[index] = value;
        }
    }

    public void Add(T newValure)
    {   //데이터를 저장하고 다음 빈칸으로
        if (size == capacity)
        {
            ReAllocate(capacity * 2);
        }

        data[size] = newValure;
        size++;
    }

    private void ReAllocate(int newCapacity)
    {
        // 큰 저장공간 확보.
        T[] newData = new T[newCapacity];
        for (int ix = 0; ix < size; ix++)
        {
            newData[ix] = data[ix];
        }

        data = newData;
    }

    public bool Remove(T deleteValue)
    {
        if (size == 0)
        {
            return false;
        }
        int targetIndex = -1;
        for (int ix = 0; ix < size; ix++)
        {
            if (data[ix] != null && data[ix].Equals(deleteValue) == true)
            {
                targetIndex = ix;
                break;
            }
        }
        return false;
    }
    public bool RemoveAt(int index)
    {
        if (size == 0 || index < 0 || index >= 0)
        {
            return false;
        }

        int listIndex = 0;
        for (int ix = 0; ix < size; ix++)
        {
            if (ix == index)
            {
                continue;
            }
            data[listIndex] = data[ix];
            listIndex++;
        }

        data[size] = default(T);
        size--;

        return true;
    }

    public int Count
    {
        get
        {
            return size;
        }
    }
}