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
    /// ��ǲ �ʵ忡 �ؽ�Ʈ �Է½� ���̵� ����
    /// </summary>
    /// <param name="input"></param>
    public void CreateID(TMP_InputField input)
    {
        if (input.text.Length < 2 || input.text.Length > 10)
        {
            Debug.Log("���̵� 2 ~ 10 �����̳��� �ۼ��Ͻÿ�");
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
