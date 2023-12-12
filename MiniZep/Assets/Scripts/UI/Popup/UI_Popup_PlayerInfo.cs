using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Popup_PlayerInfo : UI_Popup
{
    #region Enums

    enum GameObjects
    {
        InventoryList,
        Equipment_Slot_Weapon,
        Equipment_Slot_Armor,
        Equipment_Slot_Helmet,
        Equipment_Slot_Shoes,
    }

    enum Texts
    {
        Text_Player_Name,
        Text_Player_Atk,
        Text_Player_Def,
        Text_Player_Hp,
        Text_Player_Crit,
        Text_Player_Cash,
    }

    enum Buttons
    {
        Btn_Exit,
    }

    #endregion

    #region Properties

    private List<UI_Item> _uiItemLists = new();

    #endregion

    #region MonoBehaviours

    void Start()
    {
        Init();
    }

    #endregion

    #region Initialize

    public override bool Init()
    {
        if (!base.Init()) return false;

        BindText(typeof(Texts));
        BindButton(typeof(Buttons));
        BindObject(typeof(GameObjects));

        GetButton((int)Buttons.Btn_Exit).gameObject.BindEvent(OnPopupExit);

        GetText((int)Texts.Text_Player_Name).text = Main.Player.Name;
        GetText((int)Texts.Text_Player_Cash).text = Main.Player.Cash.ToString();

        SetInventory();
        
        RefreshStat();

        return true;
    }

    public void RefreshStat()
    {
        GetText((int)Texts.Text_Player_Atk).text = Main.Player.ATK.Value.ToString();
        GetText((int)Texts.Text_Player_Def).text = Main.Player.DEF.Value.ToString();
        GetText((int)Texts.Text_Player_Hp).text = Main.Player.HP.Value.ToString();
        GetText((int)Texts.Text_Player_Crit).text = Main.Player.CRIT.Value.ToString();
    }

    public void RefreshItem(UI_Item uiItem)
    {
        uiItem.transform.SetParent(ItemEquipCheck(uiItem.Item));
        RefreshStat();
    }

    private void SetInventory()
    {
        foreach (var invenItem in Main.Inventory.ItemList)
        {
            UI_Item uiItem = Main.Resource.InstantiatePrefab("UI_Item.prefab", ItemEquipCheck(invenItem)).GetComponent<UI_Item>();
            uiItem.SetInfo(invenItem);
            _uiItemLists.Add(uiItem);
        }
    }

    private Transform ItemEquipCheck(InventoryItem item)
    {
        // 장착중인 아이템이 아닌 경우 => 인벤토리 리스트 Transform으로 설정
        if (!item.IsEquipped) return GetObject((int)GameObjects.InventoryList).transform;

        return item.BaseData.itemType switch
        {
            ItemType.Weapon => GetObject((int)GameObjects.Equipment_Slot_Weapon).transform,
            ItemType.Armor => GetObject((int)GameObjects.Equipment_Slot_Armor).transform,
            ItemType.Helmet => GetObject((int)GameObjects.Equipment_Slot_Helmet).transform,
            ItemType.Shoes => GetObject((int)GameObjects.Equipment_Slot_Shoes).transform,
            _ => GetObject((int)GameObjects.InventoryList).transform,
        };
    }

    #endregion

    #region OnButtons

    public void OnPopupExit(PointerEventData data)
    {
        Main.UI.ClosePopupUI(this);
    }

    #endregion
}
