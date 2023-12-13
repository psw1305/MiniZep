using UnityEngine.EventSystems;

public class UI_Popup_Shop : UI_Popup
{
    #region Enums

    enum GameObjects
    {
        ProductList,
    }

    enum Texts
    {
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

        BindObject(typeof(GameObjects));
        BindText(typeof(Texts));
        BindButton(typeof(Buttons));

        GetButton((int)Buttons.Btn_Exit).gameObject.BindEvent(OnPopupExit);

        SetProductList();
        Refresh();

        return true;
    }

    public void Refresh()
    {
        GetText((int)Texts.Text_Player_Cash).text = Main.Player.Cash.ToString();
    }

    public void SetProductList()
    {
        foreach (var item in Main.Game.ShopProducts)
        {
            UI_Shop_Product uiProduct = Main.Resource.InstantiatePrefab("UI_Shop_Product.prefab", GetObject((int)GameObjects.ProductList).transform).GetComponent<UI_Shop_Product>();
            uiProduct.SetProduct(this, item);
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
