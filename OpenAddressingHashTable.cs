using System.Diagnostics.CodeAnalysis;

public class OpenAddressingHashTable
{
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
    private int _collisionsCount = 0;
    private int _indexCount;
    private List<KeyValue> _list;
    private int _keysValuesCount;
    public OpenAddressingHashTable(int indexCount)
    {
        _indexCount = indexCount;
        _keysValuesCount = 0;
        _list = new List<KeyValue?>();
        for (int i = 0; i < _indexCount; i++)
        {
            _list.Add(null);
        }
    }
    public int HashFunction(string key)
    {
        int hashCode = key.GetHashCode();
        hashCode %= _indexCount;
        if (hashCode < 0)
            hashCode += _indexCount;
        return hashCode;
    }
    public void AddKeyValue(string key, string value)
    {
        int index = HashFunction(key);
        int counter = 0;
    
        while (_list.ElementAt(index) != null)
        {
            index = (++index % _indexCount);
            if (counter != 0)
            {
                _collisionsCount++;
            }
            counter++;
        }
        
        _list.Insert(index, new KeyValue(key, value));
        
        _keysValuesCount++;
        if (_indexCount * 0.75 < _keysValuesCount)
        {
            IncreaseList(_indexCount * 10);
        }
    }
    public KeyValue LookForKeyValue(string key)
    {
        int index = HashFunction(key);
        int counter = 0;
        while(true) 
        {
            index = (++index) % _indexCount;
            counter++;
            if (_list.ElementAt(index) != null && _list.ElementAt(index).Key == key) 
            {
                return _list.ElementAt(index);
            }
            if (counter > _indexCount)
            {
                KeyValue kv = new KeyValue(string.Empty, string.Empty);
                return kv;
            }
        }
    }
    public void DeleteKeyValue(string key)
    {
        int index = HashFunction(key);
        int counter = 0;
        while(true)
        {
            index = ++index % _indexCount;
            counter++;
            if (_list.ElementAt(index) != null && _list.ElementAt(index).Key == key)
            {
                _keysValuesCount--;
                _list.RemoveAt(index);
                return;
            }
            if (counter > _indexCount)
            {
                return;
            }
        }
    } 
    public void WriteList() 
    {
        for (int i = 0; i < _list.Count; i++)
        {
            Console.Write("{0}: ", i);
            KeyValue kv = _list.ElementAt(i);
            if (kv != null)
            {
                Console.Write($"{kv.Key}:{kv.Value}   ");
            }
            Console.WriteLine();
        }
        Console.WriteLine($"Total count of collisions: {_collisionsCount}");
    }
    public void IncreaseList(int indexCount)
    {
        List<KeyValue> temp = new List<KeyValue>();
        for (var i = 0; i < _list.Count; i++)
        {
            var keyValue = _list[i];
            if (keyValue != null)
                temp.Add(keyValue);
        }
        _indexCount = indexCount;
        _keysValuesCount = 0;
        _list = new List<KeyValue>();
        for (int i = 0; i < _indexCount; i++)
            _list.Add(null);
        for (var i = 0; i < temp.Count; i++)
        {
            var keyValue = temp[i];
            AddKeyValue(keyValue.Key, keyValue.Value);
        }
    }

}
