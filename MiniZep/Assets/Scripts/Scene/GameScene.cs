public class GameScene : BaseScene
{
    protected override bool Initialize()
    {
        if (!base.Initialize()) return false;

        // 씬 진입 시 처리
        UI = Main.UI.ShowSceneUI<UI_Scene_Game>();

        return true;
    }
}
