using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UI_Scene_Lobby : MonoBehaviour
{
    private LobbyStep step;

    [Header("Step")]
    [SerializeField] private GameObject stepSelect;
    [SerializeField] private GameObject stepInput;
    [SerializeField] private TextMeshProUGUI errorMessage;

    [Header("Select Field")]
    [SerializeField] private ToggleGroup toggleGroup;
    [SerializeField] private Button nextStepButton;

    [Header("Input Field")]
    [SerializeField] private Image selectCharacter;
    [SerializeField] private TMP_InputField nameInput;
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
        Manager.Resource.AddCharacterToggles(toggleGroup);

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
        nameInput.onEndEdit.AddListener(delegate { CreateName(nameInput); });
        playButton.onClick.AddListener(PlayToMain);

        stepInput.SetActive(false);
    }

    /// <summary>
    /// ��ǲ �ʵ忡 �ؽ�Ʈ �Է½� ���̵� ����
    /// </summary>
    /// <param name="input">�Է��� ���̵�</param>
    public void CreateName(TMP_InputField input)
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
