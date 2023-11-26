using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI displayID;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;

    private CharacterBlueprint characterBlueprint;

    private void Start()
    {
        InitPlayer();
    }

    private void InitPlayer()
    {
        characterBlueprint = Manager.Game.PlayerBlueprint;

        displayID.text = PlayerPrefs.GetString("user_id", "defaultID");
        spriteRenderer.sprite = characterBlueprint.CSprite;
        animator.runtimeAnimatorController = characterBlueprint.CAnim;
    }
}
