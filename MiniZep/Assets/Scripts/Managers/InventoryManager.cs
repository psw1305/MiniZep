using System;
using System.Collections.Generic;

public class InventoryManager
{
    public event EventHandler OnInventoryChanged;

    public List<InventoryItem> ItemList { get; private set; }
    private int _listMaxCount = 16;

    public InventoryManager() 
    {
        ItemList = new List<InventoryItem>();
    }

    public void AddItem(InventoryItem item, bool inventoryCheck = true)
    {
        if (ItemList.Count <= _listMaxCount)
        {
            ItemList.Add(item);

            if (inventoryCheck)
                OnInventoryChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public void RemoveItem(InventoryItem item, bool inventoryCheck = true) 
    {
        ItemList.Remove(item);

        if (inventoryCheck)
            OnInventoryChanged?.Invoke(this, EventArgs.Empty);
    }
}
