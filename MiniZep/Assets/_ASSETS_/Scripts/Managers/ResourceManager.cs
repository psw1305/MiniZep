using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager
{
    private List<CharacterBlueprint> characterBlueprints = new();
    private Dictionary<string, GameObject> uiPrefabs = new();

    public void Initialize()
    {
        // Character 설계도
        CharacterBlueprint[] characters = Resources.LoadAll<CharacterBlueprint>("ScriptableObjects/Player");
        foreach (CharacterBlueprint character in characters) characterBlueprints.Add(character);

        // UI 프리팹
        GameObject[] objs = Resources.LoadAll<GameObject>("Prefabs/UI");  
        foreach (GameObject obj in objs) uiPrefabs[obj.name] = obj;
    }

    public GameObject Instantiate(string prefabName, Transform parent)
    {
        if (!uiPrefabs.TryGetValue(prefabName, out GameObject prefab)) return null;

        return GameObject.Instantiate(prefab, parent);
    }

    /// <summary>
    /// 캐릭터 선택 토글 리스트 생성
    /// </summary>
    /// <param name="toggleGroup">토글 리스트를 관리할 토글 그룹</param>
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
