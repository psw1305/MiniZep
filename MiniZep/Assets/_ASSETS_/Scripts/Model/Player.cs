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
        communityNameObj = Manager.Resource.Instantiate("UI_Community_Name", Manager.Game.CommunityList);
        var communityName = communityNameObj.GetComponent<TextMeshProUGUI>();
        communityName.text = displayName.text;

        InitPlayer();
    }

    private void InitPlayer()
    {
        InitCharacter();
        InitName();
    }

    public void InitCharacter()
    {
        if (Manager.Game.PlayerBlueprint == null) return;

        characterBlueprint = Manager.Game.PlayerBlueprint;
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
