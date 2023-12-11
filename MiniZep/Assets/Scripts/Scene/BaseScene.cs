using UnityEngine;
using UnityEngine.EventSystems;

public class BaseScene : MonoBehaviour
{
    public UI_Scene UI { get; protected set; }
    private bool _initialized = false;

    private void Start()
    {
        if (Main.Resource.Loaded)
        {
            Main.Game.Initialize();
            Initialize();
        }
        else
        {
            Main.Resource.LoadAllAsync<UnityEngine.Object>("PreLoad", (key, count, totalCount) =>
            {
                if (count >= totalCount)
                {
                    Main.Resource.Loaded = true;
                    Main.Game.Initialize();
                    Initialize();
                }
            });
        }
    }

    protected virtual bool Initialize()
    {
        if (_initialized) return false;

        Object obj = GameObject.FindObjectOfType<EventSystem>();
        if (obj == null) Main.Resource.InstantiatePrefab("EventSystem.prefab").name = "@EventSystem";

        _initialized = true;
        return true;
    }
}
