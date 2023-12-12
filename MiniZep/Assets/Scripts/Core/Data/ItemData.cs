using System;
using System.Collections.Generic;
using System.Linq;

public enum ItemType
{
    Weapon,
    Armor,
    Helmet,
    Shoes,
}

[Serializable]
public class ItemData
{
    public ItemType itemType;
    public string itemStringKey;
    public int itemStatHP;
    public int itemStatATK;
    public int itemStatDEF;
    public float itemStatCRIT;
    public string itemName;
    public string itemDesc;
}

[Serializable]
public class ItemDataLoader : ILoadData<string, ItemData>
{
    public List<ItemData> items = new();

    public Dictionary<string, ItemData> MakeData()
    {
        return items.ToDictionary(item => item.itemStringKey);
    }
}
