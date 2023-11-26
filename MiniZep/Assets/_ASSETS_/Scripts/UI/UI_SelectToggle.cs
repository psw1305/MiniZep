using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_SelectToggle : MonoBehaviour
{
    private Toggle toggle;
    [SerializeField] private TextMeshProUGUI characterName;
    [SerializeField] private Image characterImage;
    public CharacterBlueprint Blueprint { get; private set; }

    public void Initialized(CharacterBlueprint blueprint, ToggleGroup toggleGroup)
    {
        toggle = GetComponent<Toggle>();
        toggle.group = toggleGroup;
        toggle.onValueChanged.AddListener(SelectPlayer);

        Blueprint = blueprint;
        characterName.text = Blueprint.CName;
        characterImage.sprite = Blueprint.CSprite;
    }

    private void SelectPlayer(bool isOn)
    {
        if (isOn)
        {
            Manager.Game.PlayerBlueprint = Blueprint;
        }
        else
        {
            Manager.Game.PlayerBlueprint = null;
        }
    }
}
