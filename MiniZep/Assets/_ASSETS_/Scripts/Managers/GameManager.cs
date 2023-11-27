public class GameManager
{
    public CharacterBlueprint PlayerBlueprint { get; set; }
    public GameState State { get; set; }
    
    public void Initialize()
    {
        State = GameState.Play;
    }
}
