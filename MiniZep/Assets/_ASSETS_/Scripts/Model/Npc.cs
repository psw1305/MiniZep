using UnityEngine;
using TMPro;

public class NPC : MonoBehaviour, ICharacter
{
    [SerializeField] private NPCBlueprint npcBlueprint;
    [SerializeField] private TextMeshProUGUI displayName;

    [Header("Sprite")]
    [SerializeField] private SpriteRenderer mainSprite;
    [SerializeField] private SpriteRenderer outlineSprite;

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

        mainSprite.sprite = npcBlueprint.CSprite;
        mainSprite.GetComponent<Animator>().runtimeAnimatorController = npcBlueprint.CAnim;

        outlineSprite.sprite = npcBlueprint.CSprite;
        outlineSprite.GetComponent<Animator>().runtimeAnimatorController = npcBlueprint.CAnim;
        outlineSprite.color = Color.clear;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Manager.Game?.MainUI.ActiveDialogueButton(true, npcBlueprint);
            outlineSprite.color = Color.white;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Manager.Game?.MainUI.ActiveDialogueButton(false);
            outlineSprite.color = Color.clear;
        }
    }
}
