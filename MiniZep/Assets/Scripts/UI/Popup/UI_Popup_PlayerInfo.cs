using UnityEngine.EventSystems;

public class UI_Popup_PlayerInfo : UI_Popup
{
    #region Enums

    enum GameObjects
    {
        InventoryList,
    }

    enum Texts
    {
        Text_Player_Name,
        Text_Player_Atk,
        Text_Player_Def,
        Text_Player_Hp,
        Text_Player_Crit,
        Text_Player_Cash,
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
        BindObject(typeof(GameObjects));

        GetText((int)Texts.Text_Player_Name).text = Main.Player.Name;
        GetText((int)Texts.Text_Player_Cash).text = Main.Player.Cash.ToString();
        GetText((int)Texts.Text_Player_Atk).text = Main.Player.ATK.Value.ToString();
        GetText((int)Texts.Text_Player_Def).text = Main.Player.DEF.Value.ToString();
        GetText((int)Texts.Text_Player_Hp).text = Main.Player.HP.Value.ToString();
        GetText((int)Texts.Text_Player_Crit).text = Main.Player.CRIT.Value.ToString();

        GetButton((int)Buttons.Btn_Exit).gameObject.BindEvent(OnPopupExit);

        SetInventory();

        return true;
    }

    private void Refresh()
    {
        Init();
    }

    private void SetInventory()
    {
        foreach (string key in Main.Data.Items.Keys)
        {
            UI_Item itemClone = Main.Resource.InstantiatePrefab("UI_Item.prefab", GetObject((int)GameObjects.InventoryList).transform).GetComponent<UI_Item>();
            itemClone.SetInfo(key);
        }
    }

    #endregion

    #region OnButtons

    public void OnPopupExit(PointerEventData data)
    {
        Main.UI.ClosePopupUI(this);
    }

    #endregion
}
