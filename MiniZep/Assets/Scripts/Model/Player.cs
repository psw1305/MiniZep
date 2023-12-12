using TMPro;
using UnityEngine;

public class Player : ICharacter
{
    public string Name { get; set; }

    [SerializeField] private TextMeshProUGUI displayName;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;

    private CharacterBlueprint characterBlueprint;

    private void Start()
    {
        InitPlayer();
    }

    private void InitPlayer()
    {
        InitCharacter();
        InitName();
    }

    public void InitCharacter()
    {
        if (Main.Game.PlayerBlueprint == null) return;

        characterBlueprint = Main.Game.PlayerBlueprint;
        spriteRenderer.sprite = characterBlueprint.CSprite;
        animator.runtimeAnimatorController = characterBlueprint.CAnim;
    }

    public void InitName()
    {
        displayName.text = PlayerPrefs.GetString("user_id", "defaultID");
    }
}
