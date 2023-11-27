using UnityEngine;

public class UIManager
{
    #region Properties

    public GameObject Root
    {
        get
        {
            GameObject root = GameObject.Find("@UI_Root") ?? new GameObject("@UI_Root");
            return root;
        }
    }
    public UI_Scene SceneUI => sceneUI;

    #endregion

    #region Fields

    private int order = 10;
    private UI_Scene sceneUI;

    #endregion

    public void SetCanvas(GameObject go, bool sort = true)
    {
        Canvas canvas = Util.GetOrAddComponent<Canvas>(go);
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.overrideSorting = true;

        if (sort)
        {
            canvas.sortingOrder = order;
            order++;
        }
        else // 팝업이 아닌 일반 고정 UI
        {
            canvas.sortingOrder = 0;
        }
    }

    public T ShowSceneUI<T>(string name = null) where T : UI_Scene
    {
        if (string.IsNullOrEmpty(name))
        {
            name = typeof(T).Name;
        }

        GameObject go = Manager.Resource.Instantiate($"Scene/{name}", Root.transform);
        T sceneUI = Util.GetOrAddComponent<T>(go);
        this.sceneUI = sceneUI;

        return sceneUI;
    }
}
