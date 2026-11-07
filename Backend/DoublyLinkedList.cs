namespace Backend;

public class DoublyLinkedList<T> where T : IComparable<T>
{
    private DoubleNode<T>? _head;
    private DoubleNode<T>? _tail;

    public DoublyLinkedList()
    {
        _head = null; // This line can be removed
        _tail = null; // This line can be removed
    }

    // METHODS
    //  Option 1 - Add elements
    public void Add(T data)
    {
        var newNode = new DoubleNode<T>(data);

        // Empty List
        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
            return;
        }

        if (data.CompareTo(_head.Data) <= 0)
        {
            newNode.Next = _head;
            _head.Prev = newNode;
            _head = newNode;
            return;
        }

        var current = _head;
        while (current.Next != null && current.Next.Data!.CompareTo(data) < 0)
        {
            current = current.Next;
        }

        newNode.Next = current.Next;
        newNode.Prev = current;

        if (current.Next != null)
        {
            current.Next.Prev = newNode;
        }
        else
        {
            _tail = newNode; 
        }

        current.Next = newNode;
    }

    
    // Option 2 - Show forward
    public override string ToString()
    {
        var output = string.Empty;
        var current = _head;
        while (current != null)
        {
            output += $"{current.Data} <-> ";
            current = current.Next;
        }
        return $"{output} null";
    }


    // Option 3 - Show backward
    public string ToStringReverse()
    {
        var output = string.Empty;
        var current = _tail;
        while (current != null)
        {
            output += $"{current.Data} <-> ";
            current = current.Prev;
        }
        return $"{output} null";
    }

    // Option 4 - Sort in descending order
    public void SortDescending()
    {
        if (_head == null) return;

        DoubleNode<T>? current = _head;
        DoubleNode<T>? temp = null;

        while (current != null)
        {
            temp = current.Prev;
            current.Prev = current.Next;
            current.Next = temp;
            current = current.Prev;
        }

        if (temp != null)
        {
            _tail = _head;
            _head = temp.Prev;
        }
    }

    // Option 5 - Show Modes
    public List<T> GetModes()
    {
        var modes = new List<T>();
        if (_head == null) return modes;

        var frequencies = GetFrequencies();
        int maxCount = 0;

        foreach (var pair in frequencies)
        {
            if (pair.Value > maxCount)
                maxCount = pair.Value;
        }
        foreach (var pair in frequencies)
        {
            if (pair.Value == maxCount)
                modes.Add(pair.Key);
        }

        return modes;
    }

    // Option 6 - Show graphic
    public string GenerateGraph()
    {
        if (_head == null) return "Lista vacía";

        var frequencies = GetFrequencies();
        var graph = string.Empty;

        foreach (var pair in frequencies)
        {
            string asterisks = new string('*', pair.Value);
            graph += $"{pair.Key} {asterisks}\n";
        }

        return graph;
    }

    // Option 7 - Existence
    public bool Contains(T data)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Data!.Equals(data))
            {
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    // Option 8 - 
    public bool RemoveOne(T data)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Data!.Equals(data))
            {
                RemoveNode(current);
                return true; 
            }
            current = current.Next;
        }
        return false;
    }

    
    public int RemoveAll(T data)
    {
        int count = 0;
        var current = _head;
        while (current != null)
        {
            var nextNode = current.Next; 
            if (current.Data!.Equals(data))
            {
                RemoveNode(current);
                count++;
            }
            current = nextNode;
        }
        return count;
    }

    private void RemoveNode(DoubleNode<T> node)
    {
        // 
        if (node.Prev == null && node.Next == null)
        {
            _head = null;
            _tail = null;
            return;
        }

        // 
        if (node.Prev == null)
        {
            _head = node.Next;
            if (_head != null) _head.Prev = null;
            return;
        }

        // 
        if (node.Next == null)
        {
            _tail = node.Prev;
            if (_tail != null) _tail.Next = null;
            return;
        }

        // 
        node.Prev.Next = node.Next;
        node.Next.Prev = node.Prev;
    }

    private Dictionary<T, int> GetFrequencies()
    {
        var counts = new Dictionary<T, int>();
        var current = _head;
        while (current != null)
        {
            if (counts.ContainsKey(current.Data!))
                counts[current.Data!]++;
            else
                counts[current.Data!] = 1;

            current = current.Next;
        }
        return counts;
    }
}
