using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using TMPro;

public static class Extensions
{
    /// <summary>
    /// [DOTween] RectTransform X ��ǥ ������
    /// </summary>
    /// <param name="rectTransform"></param>
    /// <param name="movePosX">�����ϴ� ���� ������ x ��ǥ</param>
    public static void MoveSidebar(this RectTransform rectTransform, float movePosX)
    {
        rectTransform.DOLocalMoveX(movePosX, 0.4f);
    }

    /// <summary>
    /// [DOTween] �ؽ�Ʈ Ÿ���� ġ���� ���� 
    /// </summary>
    /// <param name="tmproText"></param>
    /// <param name="duration"></param>
    public static void TypingText(this TextMeshProUGUI tmproText, float duration)
    {
        float maxDuration = tmproText.text.Length * duration;
        DOTween.To(c => tmproText.maxVisibleCharacters = (int)c, 0f, tmproText.text.Length, maxDuration);
    }
}
