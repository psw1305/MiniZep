using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using TMPro;

public enum LobbyStep
{
    Start,
    Select,
    Input,
    Finish,
}

public class UI_Scene_Lobby : MonoBehaviour
{
    [Header("Step")]
    [SerializeField] private LobbyStep step;
    [SerializeField] private GameObject stepSelect;
    [SerializeField] private GameObject stepInput;
    [SerializeField] private TextMeshProUGUI errorMessage;

    [Header("Select Field")]
    [SerializeField] private GameObject characterTogglePrefab;
    [SerializeField] private ToggleGroup toggleGroup;
    [SerializeField] private Button nextStepButton;
    private CharacterBlueprint[] characterBlueprints;

    [Header("Input Field")]
    [SerializeField] private Image selectCharacter;
    [SerializeField] private TMP_InputField idInput;
    [SerializeField] private Button playButton;

    private void Start()
    {
        step = LobbyStep.Select;

        InitStepSelect();
        InitStepInput();
    }

    #region Step - Select

    private void InitStepSelect()
    {
        characterBlueprints = Manager.Resource.GetCharacterBlueprints();

        for (int i = 0; i < characterBlueprints.Length; i++)
        {
            var characterToggle = Instantiate(characterTogglePrefab, toggleGroup.transform);
            var uiToggle = characterToggle.GetComponent<UI_CharacterToggle>();
            uiToggle.Initialized(characterBlueprints[i], toggleGroup);
        }

        nextStepButton.onClick.AddListener(NextStep);
    }

    private void NextStep()
    {
        // ĳ���� ���õ��� ���� ���, �ܰ� �Ѿ�� �Ұ���
        if (Manager.Game.PlayerBlueprint == null) return;

        step = LobbyStep.Input;
        selectCharacter.sprite = Manager.Game.PlayerBlueprint.CSprite;

        stepSelect.SetActive(false);
        stepInput.SetActive(true);
    }

    #endregion


    #region Step - Input

    private void InitStepInput()
    {
        idInput.onEndEdit.AddListener(delegate { CreateID(idInput); });
        playButton.onClick.AddListener(PlayToMain);

        stepInput.SetActive(false);
    }

    /// <summary>
    /// ��ǲ �ʵ忡 �ؽ�Ʈ �Է½� ���̵� ����
    /// </summary>
    /// <param name="input">�Է��� ���̵�</param>
    public void CreateID(TMP_InputField input)
    {
        if (input.text.Length < 2 || input.text.Length > 10)
        {
            step = LobbyStep.Input;
            Debug.Log("���̵� 2 ~ 10 �����̳��� �ۼ��Ͻÿ�");
            input.text = string.Empty;
            return;
        }

        step = LobbyStep.Finish;
        PlayerPrefs.SetString("user_id", input.text);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// ������ �ܰ迡 ������ ���, ���� ������ �ε�
    /// </summary>
    public void PlayToMain()
    {
        if (step != LobbyStep.Finish) return;

        SceneManager.LoadScene("Main");
    }

    #endregion
}
