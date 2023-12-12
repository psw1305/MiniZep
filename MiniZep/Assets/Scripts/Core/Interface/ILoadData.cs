using System.Collections.Generic;

public interface ILoadData<TKey, TValue>
{
    Dictionary<TKey, TValue> MakeData();
}
