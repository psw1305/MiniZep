using UnityEngine.EventSystems;

public class UI_Popup_ItemInfo : UI_Popup
{
    #region Enums

    enum Texts
    {
        Text_Item_Name,
        Text_Item_Desc,
        Text_Item_Stat_Hp,
        Text_Item_Stat_Atk, 
        Text_Item_Stat_Def,
        Text_Item_Stat_Crit,
    }

    enum Images
    {
        Image_Item,
    }

    enum Buttons
    {
        Btn_Equip,
        Btn_Unequip,
        Btn_Exit,
    }

    #endregion

    #region Fields

    private UI_Popup_Inventory _inventory;
    private InventoryItem _item;

    #endregion

    #region Initialize

    void Start()
    {
        Init();
    }

    public override bool Init()
    {
        if (!base.Init()) return false;

        BindText(typeof(Texts));
        BindImage(typeof(Images));
        BindButton(typeof(Buttons));

        GetButton((int)Buttons.Btn_Equip).gameObject.BindEvent(OnEquipped);
        GetButton((int)Buttons.Btn_Unequip).gameObject.BindEvent(OnUnequipped);
        GetButton((int)Buttons.Btn_Exit).gameObject.BindEvent(OnPopupExit);

        Refresh();

        return true;
    }

    private void Refresh()
    {
        if (_item == null) return;

        Init();

        GetText((int)Texts.Text_Item_Name).text = _item.BaseData.itemName;
        GetText((int)Texts.Text_Item_Desc).text = _item.BaseData.itemDesc;
        GetText((int)Texts.Text_Item_Stat_Hp).text = _item.BaseData.itemStatHP.ToString();
        GetText((int)Texts.Text_Item_Stat_Atk).text = _item.BaseData.itemStatATK.ToString();
        GetText((int)Texts.Text_Item_Stat_Def).text = _item.BaseData.itemStatDEF.ToString();
        GetText((int)Texts.Text_Item_Stat_Crit).text = _item.BaseData.itemStatCRIT.ToString();
        GetImage((int)Images.Image_Item).sprite = _item.ItemImage;

        CheckEquipButton();
    }

    public void SetItemInfo(UI_Item uiItem)
    {
        _item = uiItem.Item;
        _inventory = FindObjectOfType<UI_Popup_Inventory>();
        Refresh();
    }

    #endregion

    #region Methods

    private void CheckEquipButton()
    {
        if (_item.IsEquipped)
        {
            GetButton((int)Buttons.Btn_Equip).gameObject.SetActive(false);
            GetButton((int)Buttons.Btn_Unequip).gameObject.SetActive(true);
        }
        else
        {
            GetButton((int)Buttons.Btn_Unequip).gameObject.SetActive(false);
            GetButton((int)Buttons.Btn_Equip).gameObject.SetActive(true);
        }
    }

    #endregion

    #region OnButtons

    public void OnEquipped(PointerEventData data)
    {
        Main.Player.Equipment.Equip((int)_item.BaseData.itemType, _item);
        CheckEquipButton();
        _inventory.RefreshItem();
    }

    public void OnUnequipped(PointerEventData data)
    {
        Main.Player.Equipment.Unequip((int)_item.BaseData.itemType);
        CheckEquipButton();
        _inventory.RefreshItem();
    }

    public void OnPopupExit(PointerEventData data)
    {
        Main.UI.ClosePopupUI(this);
    }

    #endregion
}
