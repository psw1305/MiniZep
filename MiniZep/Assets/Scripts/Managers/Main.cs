using UnityEngine;

public class Main : MonoBehaviour
{
    private static Main instance;
    private static bool initialized;
    public static Main Instance
    {
        get
        {
            if (!initialized)
            {
                initialized = true;

                GameObject obj = GameObject.Find("@Main");
                if (obj == null)
                {
                    obj = new() { name = @"Main" };
                    obj.AddComponent<Main>();
                    DontDestroyOnLoad(obj);
                    instance = obj.GetComponent<Main>();
                }
            }
            return instance;
        }
    }

    private readonly ResourceManager _resource = new();
    private readonly DataManager _data = new();
    private readonly UIManager _ui = new();
    private readonly GameManager _game = new();
    private readonly PlayerManager _player = new();

    public static ResourceManager Resource => Instance != null ? Instance._resource : null;
    public static DataManager Data => Instance != null ? Instance._data : null;
    public static UIManager UI => Instance != null ? Instance._ui : null;
    public static GameManager Game => Instance != null ? Instance._game : null;
    public static PlayerManager Player => Instance != null ? Instance._player : null;
}
