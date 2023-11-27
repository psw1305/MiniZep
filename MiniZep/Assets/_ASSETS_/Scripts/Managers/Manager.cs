
public class Manager : SingletonBehaviour<Manager>
{
    private ResourceManager resource = new();
    private UIManager ui = new();
    private GameManager game = new();
    public static ResourceManager Resource => Instance != null ? Instance.resource : null;
    public static UIManager UI => Instance != null ? Instance.ui : null;
    public static GameManager Game => Instance != null ? Instance.game : null;

    protected override void Awake()
    {
        base.Awake();

        Resource.Initialize();
        Game.Initialize();
    }
}
