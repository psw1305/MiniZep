using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager
{
    private List<CharacterBlueprint> characterBlueprints = new();
    private Dictionary<string, GameObject> uiPrefabs = new();

    public void Initialize()
    {
        // Character ���赵
        CharacterBlueprint[] characters = Resources.LoadAll<CharacterBlueprint>("ScriptableObjects/Player");
        foreach (CharacterBlueprint character in characters) characterBlueprints.Add(character);

        // UI ������
        GameObject[] objs = Resources.LoadAll<GameObject>("Prefabs/UI");  
        foreach (GameObject obj in objs) uiPrefabs[obj.name] = obj;
    }

    public GameObject Instantiate(string prefabName, Transform parent)
    {
        if (!uiPrefabs.TryGetValue(prefabName, out GameObject prefab)) return null;

        return GameObject.Instantiate(prefab, parent);
    }

    /// <summary>
    /// ĳ���� ���� ��� ����Ʈ ����
    /// </summary>
    /// <param name="toggleGroup">��� ����Ʈ�� ������ ��� �׷�</param>
    public void AddCharacterToggles(ToggleGroup toggleGroup)
    {
        for (int i = 0; i < characterBlueprints.Count; i++)
        {
            var characterToggle = Manager.Resource.Instantiate("UI_Character_Toggle", toggleGroup.transform);
            var uiToggle = characterToggle.GetComponent<UI_CharacterToggle>();
            uiToggle.Initialized(characterBlueprints[i], toggleGroup);
        }
    }
}
