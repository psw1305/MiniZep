using UnityEngine;
using TMPro;

public class NPC : MonoBehaviour, ICharacter
{
    [SerializeField] private NPCBlueprint npcBlueprint;

    [SerializeField] private TextMeshProUGUI displayName;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;

    private void Start()
    {
        InitNPC();

        var communityNameObj = Manager.Resource.Instantiate("UI_Community_Name", Manager.Game.CommunityList);
        var communityName = communityNameObj.GetComponent<TextMeshProUGUI>();
        communityName.text = displayName.text;
    }

    public void InitNPC()
    {
        if (npcBlueprint == null) return;

        displayName.text = npcBlueprint.CName;
        spriteRenderer.sprite = npcBlueprint.CSprite;
        animator.runtimeAnimatorController = npcBlueprint.CAnim;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Manager.Game.MainUI.ActiveDialogueButton(true, npcBlueprint);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Manager.Game.MainUI.ActiveDialogueButton(false);
        }
    }
}
