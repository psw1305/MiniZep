using UnityEngine;
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
        Btn_Exit,
    }

    #endregion

    #region Properties

    public ItemData data;

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

        GetButton((int)Buttons.Btn_Exit).gameObject.BindEvent(OnEquip);
        GetButton((int)Buttons.Btn_Exit).gameObject.BindEvent(OnPopupExit);
        
        Refresh();

        return true;
    }

    private void Refresh()
    {
        if (data == null) return;
        Init();

        GetText((int)Texts.Text_Item_Name).text = data.itemName;
        GetText((int)Texts.Text_Item_Desc).text = data.itemDesc;
        GetText((int)Texts.Text_Item_Stat_Hp).text = data.itemStatHP.ToString();
        GetText((int)Texts.Text_Item_Stat_Atk).text = data.itemStatATK.ToString();
        GetText((int)Texts.Text_Item_Stat_Def).text = data.itemStatDEF.ToString();
        GetText((int)Texts.Text_Item_Stat_Crit).text = data.itemStatCRIT.ToString();
        GetImage((int)Images.Image_Item).sprite = Main.Resource.Load<Sprite>($"{data.itemStringKey}.sprite");
    }

    public void SetItemInfo(ItemData data)
    {
        this.data = data;
        Refresh();
    }

    #endregion

    #region OnButtons

    public void OnEquip(PointerEventData data)
    {
    }

    public void OnPopupExit(PointerEventData data)
    {
        Main.UI.ClosePopupUI(this);
    }

    #endregion
}
