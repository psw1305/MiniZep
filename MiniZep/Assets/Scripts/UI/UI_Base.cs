using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static Define;

public class Define
{
    public enum UIEvent
    {
        Click,
        Press,
        PointerDown,
        PointerUp,
        PointerEnter,
        Drag,
        BeginDrag,
        EndDrag,

    }

    public enum MouseEvent
    {
        Click,
        Press,
        PointerDown,
        PointerUp,
        PointerEnter,
        Drag,
        BeginDrag,
        EndDrag,
    }
}

public abstract class UI_Base : MonoBehaviour
{
    private bool _initialized;
    public virtual bool Init()
    {
        if (_initialized) return false;
        _initialized = true;
        return true;
    }

    protected Dictionary<Type, UnityEngine.Object[]> _objects = new();

    protected void Bind<T>(Type type) where T : UnityEngine.Object
    {
        string[] names = Enum.GetNames(type);
        UnityEngine.Object[] objs = new UnityEngine.Object[names.Length];
        _objects.Add(typeof(T), objs);   // Dictionary ¿¡ Ãß°¡

        for (int i = 0; i < names.Length; i++)
        {
            if (typeof(T) == typeof(GameObject))
            {
                objs[i] = Util.FindChild(gameObject, names[i], true);
            }
            else
            {
                objs[i] = Util.FindChild<T>(gameObject, names[i], true);
            }

            if (objs[i] == null)
            {
                Debug.Log($"Failed to bind({names[i]})");
            }
        }
    }

    protected void BindObject(Type type) => Bind<GameObject>(type);
    protected void BindImage(Type type) => Bind<Image>(type);
    protected void BindText(Type type) => Bind<TextMeshProUGUI>(type);
    protected void BindButton(Type type) => Bind<Button>(type);

    protected T Get<T>(int idx) where T : UnityEngine.Object
    {
        if (!_objects.TryGetValue(typeof(T), out UnityEngine.Object[] objs))
        {
            return null;
        }

        return objs[idx] as T;
    }

    protected GameObject GetObject(int idx) { return Get<GameObject>(idx); }
    protected TextMeshProUGUI GetText(int idx) { return Get<TextMeshProUGUI>(idx); }
    protected Button GetButton(int idx) { return Get<Button>(idx); }
    protected Image GetImage(int idx) { return Get<Image>(idx); }

    public static void BindEvent(GameObject go, Action<PointerEventData> action, Define.UIEvent type = Define.UIEvent.Click)
    {
        UI_EventHandler evt = Util.GetOrAddComponent<UI_EventHandler>(go);

        switch (type)
        {
            case UIEvent.Click:
                evt.OnClickHandler -= action;
                evt.OnClickHandler += action;
                break;
            case UIEvent.Press:
                evt.OnPressedHandler -= action;
                evt.OnPressedHandler += action;
                break;
            case UIEvent.PointerDown:
                evt.OnPointerDownHandler -= action;
                evt.OnPointerDownHandler += action;
                break;
            case UIEvent.PointerUp:
                evt.OnPointerUpHandler -= action;
                evt.OnPointerUpHandler += action;
                break;
            case UIEvent.Drag:
                evt.OnDragHandler -= action;
                evt.OnDragHandler += action;
                break;
            case UIEvent.BeginDrag:
                evt.OnBeginDragHandler -= action;
                evt.OnBeginDragHandler += action;
                break;
            case UIEvent.EndDrag:
                evt.OnEndDragHandler -= action;
                evt.OnEndDragHandler += action;
                break;
        }
    }
}
