using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Item : UI_Base
{
    #region Enums

    enum Images
    {
        Image_Item,
    }

    enum Buttons
    {
        Btn_Item,
    }

    #endregion

    #region Properties

    public InventoryItem Item { get; private set; }

    #endregion

    private void Start()
    {
        Init();
    }

    public override bool Init()
    {
        if (!base.Init()) return false;

        BindButton(typeof(Buttons));
        BindImage(typeof(Images));

        GetButton((int)Buttons.Btn_Item).gameObject.BindEvent(OnItemInfo);
        Refresh();
        return true;
    }

    public void SetInfo(InventoryItem item)
    {
        Item = item;
    }

    public void Refresh()
    {
        if (Item == null) return;

        Init();
        GetImage((int)Images.Image_Item).sprite = Item.ItemImage;
    }

    private void OnItemInfo(PointerEventData data)
    {
        Main.UI.ShowPopupUI<UI_Popup_ItemInfo>().SetItemInfo(this);
    }
}
