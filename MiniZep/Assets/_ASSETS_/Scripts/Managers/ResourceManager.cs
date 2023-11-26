using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    private List<CharacterBlueprint> characterBlueprints = new();
    private Dictionary<string, GameObject> uiPrefabs = new();

    public void Initialize()
    {
        // Player ���赵
        CharacterBlueprint[] characters = Resources.LoadAll<CharacterBlueprint>("ScriptableObjects/Player");
        foreach (CharacterBlueprint character in characters) characterBlueprints.Add(character);

        // UI ������
        GameObject[] objs = Resources.LoadAll<GameObject>("Prefabs/UI");  
        foreach (GameObject obj in objs) uiPrefabs[obj.name] = obj;
    }

    public GameObject Instantiate(string prefabName)
    {
        if (!uiPrefabs.TryGetValue(prefabName, out GameObject prefab)) return null;

        return GameObject.Instantiate(prefab);
    }

    public CharacterBlueprint[] GetCharacterBlueprints()
    {
        return characterBlueprints.ToArray();
    }
}
