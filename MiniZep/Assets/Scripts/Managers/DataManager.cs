using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class DataManager
{
    public Dictionary<string, ItemData> Items = new();

    public void Initialize()
    {
        Items = LoadJson<ItemDataLoader, string, ItemData>("ItemData").MakeData();
    }

    private TLoader LoadJson<TLoader, Tkey, TValue>(string path) where TLoader : ILoadData<Tkey, TValue>
    {
        TextAsset textAsset = Main.Resource.Load<TextAsset>(path);
        return JsonConvert.DeserializeObject<TLoader>(textAsset.text);
    }
}
