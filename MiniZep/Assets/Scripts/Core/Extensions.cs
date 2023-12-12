using UnityEngine;
using DG.Tweening;
using TMPro;
using System;
using UnityEngine.EventSystems;

public static class Extensions
{
    // 바인드 이벤트
    public static void BindEvent(this GameObject go, Action<PointerEventData> action = null, Define.UIEvent type = Define.UIEvent.Click)
    {
        UI_Base.BindEvent(go, action, type);
    }

    // 아이템의 데이터 키값이 없을경우 => true
    public static bool IsEmptyItem(this InventoryItem item) => string.IsNullOrEmpty(item.Key);

    // [DOTween] RectTransform X 좌표 움직임
    public static void MoveSidebar(this RectTransform rectTransform, float movePosX)
    {
        rectTransform.DOLocalMoveX(movePosX, 0.4f);
    }

    // [DOTween] 텍스트 타이핑 치듯이 연출 
    public static void TypingText(this TextMeshProUGUI tmproText, float duration)
    {
        float maxDuration = tmproText.text.Length * duration;
        DOTween.To(c => tmproText.maxVisibleCharacters = (int)c, 0f, tmproText.text.Length, maxDuration);
    }
}
