using UnityEngine;

[CreateAssetMenu(fileName = "NPC", menuName = "Blueprint/NPC")]
public class NPCBlueprint : CharacterBlueprint
{
    [SerializeField] private string npcIntro;

    public string NPCIntro => npcIntro;
}
