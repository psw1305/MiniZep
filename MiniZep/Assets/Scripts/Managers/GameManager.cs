
public class GameManager
{
    #region Fields

    public CharacterBlueprint PlayerBlueprint { get; set; }
    public GameState State { get; set; }
    public UI_Scene_Game MainUI { get; set; }

    #endregion

    public void Initialize()
    {
        State = GameState.Play;
    }
}
