using UnityEngine.EventSystems;

public class UI_Popup_Status : UI_Popup
{
    #region Enums

    enum Texts
    {
        Text_Player_Name,
        Text_Player_Gold,
        Text_Player_Atk,
        Text_Player_Def,
        Text_Player_Hp,
        Text_Player_Crit,
    }

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

        BindText(typeof(Texts));
        BindButton(typeof(Buttons));

        GetText((int)Texts.Text_Player_Name).text = Main.Player.Name;
        GetText((int)Texts.Text_Player_Gold).text = $"소지금 : {Main.Player.Gold}";
        GetText((int)Texts.Text_Player_Atk).text = $"공격력 : {Main.Player.ATK}";
        GetText((int)Texts.Text_Player_Def).text = $"방어력 : {Main.Player.DEF}";
        GetText((int)Texts.Text_Player_Hp).text = $"체력 : {Main.Player.HP}";
        GetText((int)Texts.Text_Player_Crit).text = $"치명타 : {Main.Player.CRIT}";

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
