using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using TMPro;

public static class Extensions
{
    /// <summary>
    /// [DOTween] RectTransform X 좌표 움직임
    /// </summary>
    /// <param name="rectTransform"></param>
    /// <param name="movePosX">도착하는 로컬 포지션 x 좌표</param>
    public static void MoveSidebar(this RectTransform rectTransform, float movePosX)
    {
        rectTransform.DOLocalMoveX(movePosX, 0.4f);
    }

    /// <summary>
    /// [DOTween] 텍스트 타이핑 치듯이 연출 
    /// </summary>
    /// <param name="tmproText"></param>
    /// <param name="duration"></param>
    public static void TypingText(this TextMeshProUGUI tmproText, float duration)
    {
        float maxDuration = tmproText.text.Length * duration;
        DOTween.To(c => tmproText.maxVisibleCharacters = (int)c, 0f, tmproText.text.Length, maxDuration);
    }
}
