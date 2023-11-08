using System.Text;

namespace CustomStringCollectionLib;

public class CustomStringCollection
{
    private readonly string[] _strings;
    public int NumberOfStrings { get; private set; }

    // Pre: None
    // Note: The array's size may be larger than the number of elements
    // in the array!
    public CustomStringCollection(int size)
    {
        _strings = new string[size];
        NumberOfStrings = 0;
    }

    // Pre: None
    // Post: 
    // 1. NumberOfStrings == NumberOfStrings@Pre + 1
    public void Add(string item)
    {
        _strings[NumberOfStrings++] = item;
    }

    // Pre: index >= 0 and index < NumberOfStrings
    // Post: 
    //    If Pre then returns the string at the given index
    //    If Not Pre then an IndexOutOfRangeException is thrown
    public string Get(int index)
    {
        return _strings[index];
    }

    // For example, if the array contains Z,A,B,D,E this method
    // reorders the array to A,B,D,E,Z
    // Uses the selection sort algorithm
    public void Sort()
    {
        int minIndex;
        string minValue;
        for (int frontIndex = 0; frontIndex < NumberOfStrings - 1; frontIndex++)
        {
            minIndex = frontIndex;
            minValue = _strings[minIndex];
            for (int i = frontIndex + 1; i < NumberOfStrings; i++)
            {
                if (_strings[i].CompareTo(minValue) < 0)
                {
                    minValue = _strings[i];
                    minIndex = i;
                }
            }
            _strings[minIndex] = _strings[frontIndex];
            _strings[frontIndex] = minValue;
        }
    }

    // Uses the binary search algorithm to return the index of the item 
    // being sought. -1 is returned if the item is not found.
    public int Search(string item)
    {
        var position = -1;
        var left = 0;
        var right = NumberOfStrings - 1;
        var found = false;
        int middle;
        while (!found && left <= right)
        {
            middle = (left + right) / 2;
            if (_strings[middle] == item)
            {
                found = true;
                position = middle;
            }
            else if (_strings[middle].CompareTo(item) > 0)
            {
                right = middle - 1;
            }
            else
            {
                left = middle + 1;
            }
        }
        return position;
    }

    // For example, if the array contains Z,A,B,D,E this method
    // should return "{Z,A,B,D,E}" 
    //However, returned "{Z,A,B,D,E,}"
    // -- Bugged --
    public override string ToString()
    {
        var sb = new StringBuilder("{");
        for (int i = 0; i < NumberOfStrings; i++)
        {
            sb.Append(_strings[i]);
            if (i < NumberOfStrings - 1) // <-- Changed(-1)
            {
                sb.Append(',');
            }
        }
        sb.Append('}'); 
        return sb.ToString();
    }

}