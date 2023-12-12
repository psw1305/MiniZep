using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Scene_Game : UI_Scene
{
    #region Enums

    enum Buttons
    {
        Btn_PlayerInfo,
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

        GetButton((int)Buttons.Btn_PlayerInfo).gameObject.BindEvent(OnPlayerInfo);
        
        return true;
    }

    private void OnPlayerInfo(PointerEventData data)
    {
        Main.UI.ShowPopupUI<UI_Popup_PlayerInfo>();
    }
}
