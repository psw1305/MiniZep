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

    public ItemData Data { get; private set; }

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

    public void SetInfo(string key)
    {
        Data = Main.Data.Items[key];
    }

    public void Refresh()
    {
        if (Data == null) return;

        Init();
        GetImage((int)Images.Image_Item).sprite = Main.Resource.Load<Sprite>($"{Data.itemStringKey}.sprite");
    }

    private void OnItemInfo(PointerEventData data)
    {
        Main.UI.ShowPopupUI<UI_Popup_ItemInfo>().SetItemInfo(Data);
    }
}
