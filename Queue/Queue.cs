using System;

public class Queue<T>
{
    //필드.
    private T[] data;
    private int front = 0;
    private int rear = 0;
    private const int defaultCapacity = 100;
    private int capacity = 0;
    private int size = 0;

    //공개 프로퍼티.
    //큐에 저장된 요소의 수 반환.
    public int Size { get { return size; } }

    //큐가 비었는지 확인하는 프로퍼티.
    public bool IsEmpty { get { return front == rear; } }

    //큐가 가득 차 있는지 확인하는 프로퍼티.
    public bool IsFull { get { return ((rear + 1) % capacity) == front; } }

    //메시지 (공개메소드) - 인터페이스.


    //객체 생성 - 생성자.
    public Queue(int capacity = 0)
    {
        this.capacity = capacity;
        this.capacity = this.capacity <= 0 ? defaultCapacity : this.capacity;

        data = new T[this.capacity];
        size = 0;
        front = 0;
        rear = 0;
    }

    //데이터 삽입 - Enqueue.
    public bool Enqueue(T value)
    {
        if (IsFull)
        {
            Console.WriteLine("Error: No Space at Queue to Enqueue");
            return false;
        }

        rear = (rear + 1) % capacity;
        data[rear] = value;
        size++;
        return true;
    }

    //데이터 추출 - Dequeue.
    public bool Dequeue(out T value)
    {
        if (IsEmpty)
        {
            Console.WriteLine("Error: No Data at Queue to Dequeue");
            value = default(T);
            return false;
        }
        front = (front + 1) % capacity;
        value = data[front];
        data[front] = default(T);
        size--;
        return true;
    }

    //데이터를 삭제하지 않고, 제일 앞에 위치한 데이터를 반환하는 함수 Peek.
    public bool Peek(out T value)
    {
        if (IsEmpty)
        {
            Console.WriteLine("Error: No Data at Queue to Dequeue");
            value = default(T);
            return false;
        }
        value = data[(front + 1) % capacity];

        return true;
    }

    //데이터 출력 함수.
    public void Print()
    {
        if(IsEmpty)
        {
            Console.WriteLine("Error: No Data at Queue to Dequeue");
            return;
        }

        int max = (front < rear) ? rear : rear + capacity;
        for (int ix = front + 1; ix <= max; ix++)
        {
            Console.WriteLine($"{data[ix%capacity]}");
        }

        Console.WriteLine();
    }
}

