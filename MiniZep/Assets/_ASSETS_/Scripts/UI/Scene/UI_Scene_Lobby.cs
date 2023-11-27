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
        // 캐릭이 선택되지 않을 경우, 단계 넘어가기 불가능
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
    /// 인풋 필드에 텍스트 입력시 아이디 생성
    /// </summary>
    /// <param name="input">입력한 아이디</param>
    public void CreateName(TMP_InputField input)
    {
        if (input.text.Length < 2 || input.text.Length > 10)
        {
            step = LobbyStep.Input;
            Debug.Log("아이디를 2 ~ 10 글자이내로 작성하시오");
            input.text = string.Empty;
            return;
        }

        step = LobbyStep.Finish;
        PlayerPrefs.SetString("user_id", input.text);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// 마무리 단계에 도달한 경우, 메인 씬으로 로드
    /// </summary>
    public void PlayToMain()
    {
        if (step != LobbyStep.Finish) return;

        SceneManager.LoadScene("Main");
    }

    #endregion
}
