using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Blueprint/Character")]
public class CharacterBlueprint : ScriptableObject
{
    [SerializeField] private string cName;
    [SerializeField] private Sprite cSprite;
    [SerializeField] private AnimatorController cAnim;

    public string CName => cName;
    public Sprite CSprite => cSprite;
    public AnimatorController CAnim => cAnim;
}
