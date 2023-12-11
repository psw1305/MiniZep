using UnityEngine.EventSystems;

public class UI_Popup_Inventory : UI_Popup
{
    #region Enums

    enum Buttons
    {
        Btn_Exit,
    }

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

        BindButton(typeof(Buttons));

        GetButton((int)Buttons.Btn_Exit).gameObject.BindEvent(OnPopupExit);

        return true;
    }

    #endregion

    #region OnButtons

    public void OnPopupExit(PointerEventData data)
    {
        Main.UI.ClosePopupUI(this);
    }

    #endregion
}
