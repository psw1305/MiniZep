using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Scene_Main : MonoBehaviour
{
    [Header("Current Time")]
    [SerializeField] private TextMeshProUGUI displayTime;

    [Header("Change - Character")]
    [SerializeField] private Button characterChangeEnterBtn;
    [SerializeField] private Button characterChangeExitBtn;
    [SerializeField] private Button characterChangeBtn;
    [SerializeField] private GameObject characterChangePanel;
    [SerializeField] private ToggleGroup toggleGroup;

    [Header("Change - Name")]
    [SerializeField] private Button nameChangeEnterBtn;
    [SerializeField] private Button nameChangeExitBtn;
    [SerializeField] private Button nameChangeBtn;
    [SerializeField] private GameObject nameChangePanel;
    [SerializeField] private TMP_InputField nameChangeInput;

    [Header("Community")]
    [SerializeField] private Button communityShowBtn;
    [SerializeField] private Button communityHideBtn;
    [SerializeField] private GameObject communityPanel;
    [SerializeField] private Transform communityList;

    [Header("Dialogue")]
    [SerializeField] private Button dialogueEnterBtn;
    [SerializeField] private Button dialogueExitBtn;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private Image portraitImage;
    [SerializeField] private TextMeshProUGUI portraitName;
    [SerializeField] private TextMeshProUGUI dialogueText;

    private void OnEnable()
    {
        InitCharacterChange();
        InitNameChange();
        InitCommunity();
        InitDialogue();

        Manager.Game.MainUI = this;
        Manager.Game.CommunityList = communityList;
    }

    private IEnumerator Start()
    {
        while (true)
        {
            displayTime.text = Util.GetCurrntTime();
            yield return new WaitForSeconds(1f);
        }
    }

    #region Character Change Methods 

    private void InitCharacterChange()
    {
        Manager.Resource.AddCharacterToggles(toggleGroup);

        characterChangeEnterBtn.onClick.AddListener(EnterCharacterChange);
        characterChangeExitBtn.onClick.AddListener(ExitCharacterChange);
        characterChangeBtn.onClick.AddListener(OnCharacterChange);
        characterChangePanel.SetActive(false);
    }

    private void EnterCharacterChange()
    {
        Manager.Game.State = GameState.Pause;
        characterChangePanel.SetActive(true);
    }

    private void ExitCharacterChange()
    {
        Manager.Game.State = GameState.Play;
        characterChangePanel.SetActive(false);
    }

    private void OnCharacterChange()
    {
        Player.Instance.InitCharacter();
        ExitCharacterChange();
    }

    #endregion

    #region Name Change Methods

    private void InitNameChange()
    {
        nameChangeEnterBtn.onClick.AddListener(EnterNameChange);
        nameChangeExitBtn.onClick.AddListener(ExitNameChange);
        nameChangeBtn.onClick.AddListener(OnNameChange);
        nameChangeInput.onEndEdit.AddListener(delegate { ChangedName(nameChangeInput); });
        nameChangePanel.SetActive(false);
    }

    private void EnterNameChange()
    {
        Manager.Game.State = GameState.Pause;
        nameChangePanel.SetActive(true);
    }

    private void ExitNameChange()
    {
        Manager.Game.State = GameState.Play;
        nameChangePanel.SetActive(false);
    }

    private void OnNameChange()
    {
        Player.Instance.InitName();
        ExitNameChange();
    }

    public void ChangedName(TMP_InputField input)
    {
        if (input.text.Length < 2 || input.text.Length > 10)
        {
            Debug.Log("아이디를 2 ~ 10 글자이내로 작성하시오");
            input.text = string.Empty;
            return;
        }

        PlayerPrefs.SetString("user_id", input.text);
        PlayerPrefs.Save();
    }

    #endregion

    #region Community Methods

    private void InitCommunity()
    {
        communityShowBtn.onClick.AddListener(ShowCommunity);
        communityHideBtn.onClick.AddListener(HideCommunity);
        communityPanel.SetActive(false);
    }

    private void ShowCommunity()
    {   
        communityPanel.SetActive(true);
    }

    private void HideCommunity()
    {
        communityPanel.SetActive(false);
    }

    #endregion

    #region Dialogue Methods

    private void InitDialogue()
    {
        dialogueEnterBtn.onClick.AddListener(EnterDialogue);
        dialogueExitBtn.onClick.AddListener(ExitDialogue);
        dialoguePanel.SetActive(false);
    }

    private void EnterDialogue()
    {
        Manager.Game.State = GameState.Pause;
        dialoguePanel.SetActive(true);
    }

    private void ExitDialogue()
    {
        Manager.Game.State = GameState.Play;
        dialoguePanel.SetActive(false);
    }

    public void ActiveDialogueButton(bool isOn, NPCBlueprint npcBlueprint = null)
    {
        if (isOn)
        {
            dialogueEnterBtn.gameObject.SetActive(true);
            SetDialogue(npcBlueprint);
        }
        else
        {
            dialogueEnterBtn.gameObject.SetActive(false);
        }
    }

    private void SetDialogue(NPCBlueprint npcBlueprint)
    {
        portraitName.text = npcBlueprint.CName;
        portraitImage.sprite = npcBlueprint.CSprite;
        dialogueText.text = npcBlueprint.NPCIntro;
    }

    #endregion
}
