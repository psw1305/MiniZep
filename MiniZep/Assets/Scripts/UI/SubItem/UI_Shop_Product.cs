using UnityEngine.EventSystems;

public class UI_Shop_Product : UI_Base
{
    #region Enums

    enum Images
    {
        Image_Product,
    }

    enum Texts
    {
        Text_Product_Name,
        Text_Product_Desc,
        Text_Product_Price,
        Text_Product_Stat_Hp,
        Text_Product_Stat_Atk,
        Text_Product_Stat_Def,
        Text_Product_Stat_Crit,
    }

    enum Buttons
    {
        Btn_Buy,
    }

    #endregion

    #region Fields

    private UI_Popup_Shop _shop;
    private InventoryItem _item;

    #endregion

    private void Start()
    {
        Init();
    }

    public override bool Init()
    {
        if (!base.Init()) return false;

        BindImage(typeof(Images));
        BindText(typeof(Texts));
        BindButton(typeof(Buttons));

        GetButton((int)Buttons.Btn_Buy).gameObject.BindEvent(ProductTransaction);
        Refresh();

        return true;
    }

    private void Refresh()
    {
        if (_item == null) return;

        GetImage((int)Images.Image_Product).sprite = _item.ItemImage;
        GetText((int)Texts.Text_Product_Name).text = _item.BaseData.itemName;
        GetText((int)Texts.Text_Product_Desc).text = _item.BaseData.itemDesc;
        GetText((int)Texts.Text_Product_Price).text = _item.BaseData.itemPrice.ToString();
        GetText((int)Texts.Text_Product_Stat_Hp).text = _item.BaseData.itemStatHP.ToString();
        GetText((int)Texts.Text_Product_Stat_Atk).text = _item.BaseData.itemStatATK.ToString();
        GetText((int)Texts.Text_Product_Stat_Def).text = _item.BaseData.itemStatDEF.ToString();
        GetText((int)Texts.Text_Product_Stat_Crit).text = _item.BaseData.itemStatCRIT.ToString();
    }

    public void SetProduct(UI_Popup_Shop shop, InventoryItem item)
    {
        _shop = shop;
        _item = item;
    }

    #region OnButtons

    /// <summary>
    /// 상품 거래 => 거래 완료 시, 상품 삭제
    /// </summary>
    /// <param name="data"></param>
    private void ProductTransaction (PointerEventData data)
    {
        if (Main.Player.Cash >= _item.BaseData.itemPrice)
        {
            Main.UI.ShowPopupUI<UI_Popup_Notice>().SetNoticeText("구매 완료", "구매하였습니다!");
            Main.Player.UseCash(_item.BaseData.itemPrice);
            Main.Inventory.AddItem(_item);
            Main.Game.ShopProducts.Remove(_item);

            _shop.Refresh();
            Destroy(gameObject);
        }
        else
        {
            Main.UI.ShowPopupUI<UI_Popup_Notice>().SetNoticeText("구매 실패", "재화가 부족하여\n상품을 구매할 수 없습니다.");
        }
    }

    #endregion
}
