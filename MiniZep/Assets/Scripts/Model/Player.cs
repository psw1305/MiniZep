using TMPro;
using UnityEngine;

public class Player : SingletonBehaviour<Player>, ICharacter
{
    public string Name { get; set; }

    [SerializeField] private TextMeshProUGUI displayName;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;

    private CharacterBlueprint characterBlueprint;
    private GameObject communityNameObj;

    private void Start()
    {
        //communityNameObj = Main.Resource.Instantiate("UI_Community_Name", Main.Game.CommunityList);
        //var communityName = communityNameObj.GetComponent<TextMeshProUGUI>();
        //communityName.text = displayName.text;

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

        var communityName = communityNameObj.GetComponent<TextMeshProUGUI>();
        communityName.text = displayName.text;
    }
}
