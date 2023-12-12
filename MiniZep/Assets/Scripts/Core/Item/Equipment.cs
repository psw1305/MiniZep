using System;
using System.Collections.Generic;

public class Equipment
{
    private readonly Dictionary<int, InventoryItem> equipped = new();
    public IReadOnlyDictionary<int, InventoryItem> Equipped => equipped;

    public Equipment()
    {
        var slots = Enum.GetValues(typeof(ItemType));

        for (int slot = 0; slot < slots.Length; slot++)
        {
            if (equipped.GetValueOrDefault(slot) != null) continue;
            equipped[slot] = InventoryItem.Empty;
        }
    }

    public void Equip(int slot, InventoryItem item)
    {
        equipped.TryGetValue(slot, out var equipItem);

        // 같은 장비를 착용중 인가?
        if (equipItem == item)
        {
            Unequip(slot);
            return;
        }

        // 해당 장비창이 비어있지 않은가?
        if (!equipped[slot].IsEmptyItem())
        {
            Unequip(slot);
        }

        equipped[slot] = item;
        equipped[slot].Equipped();
    }

    public void Unequip(int slot)
    {
        equipped[slot].Unequipped();
        equipped[slot] = InventoryItem.Empty;
    }
}
