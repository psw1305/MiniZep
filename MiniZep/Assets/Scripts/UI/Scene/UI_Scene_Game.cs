using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Scene_Game : UI_Scene
{
    #region Enums

    enum Texts
    {
        UserNameText,
        UserLevelText,
        GoldText,
    }

    enum Buttons
    {
        Btn_Status,
        Btn_Inventory,
    }

    #endregion

    #region Fields

    private Player player;

    #endregion;

    private void Start()
    {
        Init();
    }

    public override bool Init()
    {
        if (!base.Init()) return false;

        BindButton(typeof(Buttons));

        GetButton((int)Buttons.Btn_Status).gameObject.BindEvent(OnStatus);
        GetButton((int)Buttons.Btn_Inventory).gameObject.BindEvent(OnInventory);

        return true;
    }

    private void OnStatus(PointerEventData data)
    {
        Main.UI.ShowPopupUI<UI_Popup_Status>();
    }

    private void OnInventory(PointerEventData data)
    {
        Main.UI.ShowPopupUI<UI_Popup_Inventory>();
    }
}
