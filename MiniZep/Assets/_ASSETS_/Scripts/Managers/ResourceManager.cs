using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    private List<CharacterBlueprint> playerBlueprints = new();
    private Dictionary<string, GameObject> uiPrefabs = new();

    public void Initialize()
    {
        // Player 설계도
        CharacterBlueprint[] players = Resources.LoadAll<CharacterBlueprint>("ScriptableObjects/Player");
        foreach (CharacterBlueprint player in players) playerBlueprints.Add(player);

        // UI 프리팹
        GameObject[] objs = Resources.LoadAll<GameObject>("Prefabs/UI");  
        foreach (GameObject obj in objs) uiPrefabs[obj.name] = obj;
    }

    public GameObject Instantiate(string prefabName)
    {
        if (!uiPrefabs.TryGetValue(prefabName, out GameObject prefab)) return null;

        return GameObject.Instantiate(prefab);
    }

    public CharacterBlueprint[] GetPlayerBlueprints()
    {
        return playerBlueprints.ToArray();
    }
}
