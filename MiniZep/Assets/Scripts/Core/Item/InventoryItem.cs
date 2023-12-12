using UnityEngine;
using static Unity.VisualScripting.Member;

public class InventoryItem
{
    public ItemData BaseData { get; private set; }
    public Sprite ItemImage { get; private set; }
    public string Key { get; private set; }
    public bool IsEquipped { get; private set; }

    public InventoryItem(string key)
    {
        Key = key;
        if (Key == string.Empty) return;

        BaseData = Main.Data.Items[Key];
        ItemImage = Main.Resource.Load<Sprite>($"{BaseData.itemStringKey}.sprite");
    }

    public static InventoryItem Empty = new(string.Empty);

    public void Equipped()
    {
        IsEquipped = true;

        Main.Player.HP.AddModifier(new StatModifier(BaseData.itemStatHP, StatModType.Flat, this));
        Main.Player.ATK.AddModifier(new StatModifier(BaseData.itemStatATK, StatModType.Flat, this));
        Main.Player.DEF.AddModifier(new StatModifier(BaseData.itemStatDEF, StatModType.Flat, this));
        Main.Player.CRIT.AddModifier(new StatModifier(BaseData.itemStatCRIT, StatModType.Flat, this));
    }


    public void Unequipped()
    {
        IsEquipped = false;

        Main.Player.HP.RemoveAllModifiersFromSource(this);
        Main.Player.ATK.RemoveAllModifiersFromSource(this);
        Main.Player.DEF.RemoveAllModifiersFromSource(this);
        Main.Player.CRIT.RemoveAllModifiersFromSource(this);
    }
}
