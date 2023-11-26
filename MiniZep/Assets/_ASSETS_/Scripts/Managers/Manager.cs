
public class Manager : SingletonBehaviour<Manager>
{
    private ResourceManager resource = new();
    private UIManager ui = new();
    public static ResourceManager Resource => Instance != null ? Instance.resource : null;
    public static UIManager UI => Instance != null ? Instance.ui : null;
}
