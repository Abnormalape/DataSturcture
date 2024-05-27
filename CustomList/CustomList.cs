
class CustomList<T>
{
    private T[] data;
    private int size = 0;
    private int capacity = 2;
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