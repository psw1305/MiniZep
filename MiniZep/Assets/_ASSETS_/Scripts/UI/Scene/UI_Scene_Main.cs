using System.Collections;
using TMPro;
using UnityEngine;

public class UI_Scene_Main : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI displayTime;

    private IEnumerator Start()
    {
        while (true)
        {
            displayTime.text = Util.GetCurrntTime();
            yield return new WaitForSeconds(1f);
        }
    }
}
