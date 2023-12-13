using UnityEngine.EventSystems;

public class UI_Popup_Notice : UI_Popup
{
    #region Enums

    enum Texts
    {
        Text_Notice_Title,
        Text_Notice_Contents,
    }

    enum Buttons
    {
        Btn_Check,
    }

    #endregion

    #region Fields

    private string _noticeTitle;
    private string _noticeContent;

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
        BindButton(typeof(Buttons));

        GetButton((int)Buttons.Btn_Check).gameObject.BindEvent(OnPopupExit);
        GetText((int)Texts.Text_Notice_Title).text = _noticeTitle;
        GetText((int)Texts.Text_Notice_Contents).text = _noticeContent;

        return true;
    }

    public void SetNoticeText(string title, string content)
    {
        _noticeTitle = title;
        _noticeContent = content;
    }

    #endregion

    #region OnButtons

    public void OnPopupExit(PointerEventData data)
    {
        Main.UI.ClosePopupUI(this);
    }

    #endregion
}
