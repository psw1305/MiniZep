using System.Collections.Generic;

public class GameManager
{
    #region Fields

    public CharacterBlueprint PlayerBlueprint { get; private set; }
    public GameState State { get; private set; }
    public List<InventoryItem> ShopProducts { get; private set; }

    #endregion

    public void Initialize()
    {
        State = GameState.Play;

        // 상품 리스트 추가 [TODO => 추후 상점매니저를 통한 상품관리 구현 필요]
        ShopProducts = new();
        foreach (string key in Main.Data.Items.Keys)
        {
            ShopProducts.Add(new InventoryItem(key));
        }
    }
}
