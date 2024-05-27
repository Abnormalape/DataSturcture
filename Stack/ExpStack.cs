using System;

public class ExpStack<T>
{
	private int count = 0;
	private const int maxCapacity = 100;
	private float[] data;

	public ExpStack()
	{
        this.count = 0;
        this.data = new float[maxCapacity];
    }
    

    public bool Push(float item)
	{
		if(IsFull)
		{
			Console.WriteLine("Error : ");
			return false;
		}
		data[count] = item;
		count++;

		return true;
	}

	public bool Pop(out T outValue)
	{
		if(IsEmpty)
		{
			Console.WriteLine("Error : ");
			outValue = default(T);
			return false;
		}

		count--;
		outValue = default(T); // 여기 놓침
		return true;
	}

	public bool IsFull
	{
		get;
		set;
	}
	public bool IsEmpty
	{
		get
		{
			return count == 0;
		}
	}

	public int Count
	{
		get
		{
			return count;
		}
	}

	
}