using System;
using System.Collections.Generic;

public class InventoryManager
{
    public event EventHandler OnInventoryChanged;

    public List<InventoryItem> Inventory { get; private set; }

    private int invenMaxCount = 16;

    public InventoryManager() 
    {
        Inventory = new List<InventoryItem>();
    }

    public void AddItem(InventoryItem item, bool inventoryCheck = true)
    {
        if (Inventory.Count <= invenMaxCount)
        {
            Inventory.Add(item);

            if (inventoryCheck)
                OnInventoryChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public void RemoveItem(InventoryItem item, bool inventoryCheck = true) 
    {
        Inventory.Remove(item);

        if (inventoryCheck)
            OnInventoryChanged?.Invoke(this, EventArgs.Empty);
    }
}
