using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    public CharacterBlueprint PlayerBlueprint { get; set; }
    public GameState State { get; set; }

    #region Main UI Fields

    public UI_Scene_Main MainUI { get; set; }
    public Transform CommunityList { get; set; }

    #endregion

    public void Initialize()
    {
        State = GameState.Play;
    }
}
