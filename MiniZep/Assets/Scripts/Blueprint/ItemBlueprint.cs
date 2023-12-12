using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Blueprint/Item")]
public class ItemBlueprint : ScriptableObject
{
    [SerializeField] private string itemName;
    [SerializeField] private string itemDesc;
    [SerializeField] private Sprite itemImage;
    [SerializeField] private float statValue;

    public string ItemName => itemName;
    public string ItemDesc => itemDesc;
    public Sprite ItemImage => itemImage;
    public float StatValue => statValue;
}
