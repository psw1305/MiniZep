public class InventoryItem
{
    public ItemData baseData { get; private set; }

    public void SetData(ItemData data)
    {
        baseData = data;
    }
}
