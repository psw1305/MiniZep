using UnityEngine;
using TMPro;

public class Npc : MonoBehaviour, ICharacter
{
    [SerializeField] private TextMeshProUGUI displayName;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;

    private void Start()
    {
        var communityNameObj = Manager.Resource.Instantiate("UI_Community_Name", Manager.Game.CommunityList);
        var communityName = communityNameObj.GetComponent<TextMeshProUGUI>();
        communityName.text = displayName.text;
    }
}
