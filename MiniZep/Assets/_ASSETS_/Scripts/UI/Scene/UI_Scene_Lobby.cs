using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Scene_Lobby : MonoBehaviour
{
    [SerializeField] private TMP_InputField idInput;
    [SerializeField] private Button playButton;
    private bool isPlay = false;

    private void Start()
    {
        idInput.onEndEdit.AddListener(delegate { CreateID(idInput); });
        playButton.onClick.AddListener(PlayToMain);
    }

    /// <summary>
    /// 인풋 필드에 텍스트 입력시 아이디 생성
    /// </summary>
    /// <param name="input"></param>
    public void CreateID(TMP_InputField input)
    {
        if (input.text.Length < 2 || input.text.Length > 10)
        {
            Debug.Log("아이디를 2 ~ 10 글자이내로 작성하시오");
            input.text = string.Empty;
            return;
        }

        isPlay = true;
        PlayerPrefs.SetString("user_id", input.text);
        PlayerPrefs.Save();
    }

    public void PlayToMain()
    {
        if (!isPlay) return;

        SceneManager.LoadScene("Main");
    }
}
