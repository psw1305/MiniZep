using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Blueprint/Character")]
public class CharacterBlueprint : ScriptableObject
{
    [SerializeField] private string cName;
    [SerializeField] private AnimatorController cAnim;

    public string CName => cName;
    public AnimatorController CAnim => cAnim;
}
