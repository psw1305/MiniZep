using UnityEngine.EventSystems;

public class UI_Scene_Game : UI_Scene
{
    #region Enums

    enum Buttons
    {
        Btn_Inventory,
        Btn_Shop,
    }

    #endregion

    private void Start()
    {
        Init();
    }

    public override bool Init()
    {
        if (!base.Init()) return false;

        BindButton(typeof(Buttons));

        GetButton((int)Buttons.Btn_Inventory).gameObject.BindEvent(OnInventory);
        GetButton((int)Buttons.Btn_Shop).gameObject.BindEvent(OnShop);

        return true;
    }

    private void OnInventory(PointerEventData data)
    {
        Main.UI.ShowPopupUI<UI_Popup_Inventory>();
    }

    private void OnShop(PointerEventData data)
    {
        Main.UI.ShowPopupUI<UI_Popup_Shop>();
    }
}
