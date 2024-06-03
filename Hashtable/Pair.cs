using System;
public class Pair<TKey, TValue>
{
    private TKey key;
    private TValue value;
    public TKey Key { get { return key; } }
    public TValue Value { get { return value; } }

    public Pair()
    {
        key = default(TKey);
        value = default(TValue);
    }
    public Pair(TKey key, TValue value)
    {
        this.key = key;
        this.value = value;
    }
}
