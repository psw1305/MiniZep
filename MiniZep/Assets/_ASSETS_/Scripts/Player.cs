using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI displayID;

    private void Start()
    {
        displayID.text = PlayerPrefs.GetString("user_id", "defaultID");
    }
}
