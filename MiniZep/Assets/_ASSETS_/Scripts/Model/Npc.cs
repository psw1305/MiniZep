using UnityEngine;
using TMPro;

public class Npc : MonoBehaviour, ICharacter
{
    [SerializeField] private TextMeshProUGUI displayName;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;
}
