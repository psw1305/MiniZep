using System;
using System.Collections.Generic;
using UnityEngine;

public enum EquipSlot
{
    Weapon,
    Armor,
    Helmet,
    Shoes,
}


public class Equipment
{
    private readonly Dictionary<EquipSlot, GameObject> equipped = new();
    public IReadOnlyDictionary<EquipSlot, GameObject> Equipped => equipped;

    public Equipment()
    {
        //var slots = Enum.GetValues<EquipSlot>();

        //foreach (var slot in slots)
        //{
        //    if (equipped.GetValueOrDefault(slot) != null) continue;
        //    //equipped[slot] = GameObject.Empty;
        //}
    }

    public void Equip(EquipSlot slot, GameObject data)
    {
        equipped.TryGetValue(slot, out var item);

        // 같은 장비를 착용중 인가?
        if (item == data)
        {
            Unequip(slot);
            return;
        }

        // 해당 장비창이 비어있지 않은가?
        //if (!equipped[slot].IsEmptyItem())
        //{
        //    Unequip(slot);
        //}

        //equipped[slot] = data;
        //equipped[slot].IsEquip = true;
    }

    public void Unequip(EquipSlot slot)
    {
        //equipped[slot].IsEquip = false;
        //equipped[slot] = Gear.Empty;
    }
}
