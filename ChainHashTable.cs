namespace dsa_project1;

public class KeyValue
{
    public string Key;
    public string Value;
    public KeyValue(string key, string value)
    {
        Key = key;
        Value = value;
    }
}
public class ChainHashTable
{
    private int _indexCount;
    private List<LinkedList<KeyValue>> _list;
    private int _keysValuesCount;
    public ChainHashTable(int indexCount)
    {
        _indexCount = indexCount;
        _keysValuesCount = 0;
        _list = new List<LinkedList<KeyValue>>();
        for (int i = 0; i < _indexCount; i++)
            _list.Add(new LinkedList<KeyValue>());
    }
    public int HashFunction(string key)
    {
        int hashCode = key.GetHashCode();
        hashCode %= _indexCount;
        if (hashCode < 0)
            hashCode += _indexCount;
        return hashCode;
    }
    public void WriteList()
    {
        Console.Clear();
        foreach (var linkedList in _list)
        {
            Console.Write($"{_list.IndexOf(linkedList)}: ");
            var pairs = linkedList.Select(kv => $"{kv.Key}-{kv.Value}");
            Console.Write(string.Join(" ", pairs));
            Console.WriteLine();
        }
    }
    public void AddKeyValue(string key, string value)
    {
        int index = HashFunction(key);
        var linkedList = _list[index];
        linkedList.AddLast(new KeyValue(key, value));
        _keysValuesCount++;

        if (_keysValuesCount > _indexCount * 0.75)
        {
            IncreaseList(_indexCount * 5);
        }
    }
    public void DeleteKeyValue(string key)
    {
        int index = HashFunction(key);
        for (int i = 0; i < _list.ElementAt(index).Count; i++)
        {
            if (_list.ElementAt(index).ElementAt(i).Key == key)
            {
                _list.RemoveAt(i);
            }
        }

        _keysValuesCount--;
    }
    public KeyValue[] LookForKeyValue(string key)
    {
        int index = HashFunction(key);
        LinkedList<KeyValue> linkedList = _list.ElementAt(index);

        if (linkedList.Count == 0)
        {
            return Array.Empty<KeyValue>();
        }

        List<KeyValue> result = linkedList
            .Where(kv => kv.Key == key)
            .ToList();

        return result.ToArray();
    }
    public void IncreaseList(int indexCount)
    {
        List<KeyValue> temp = new List<KeyValue>();
        for (var i = 0; i < _list.Count; i++)
        {
            var linkedList = _list[i];
            temp.AddRange(linkedList);
        }
        _indexCount = indexCount;
        _keysValuesCount = 0;
        _list = new List<LinkedList<KeyValue>>(_indexCount);
        for (int i = 0; i < _indexCount; i++)
            _list.Add(new LinkedList<KeyValue>());
        for (var i = 0; i < temp.Count; i++)
        {
            var keyValue = temp[i];
            AddKeyValue(keyValue.Key, keyValue.Value);
        }
    }
    
}