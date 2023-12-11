public class UI_Popup : UI_Base
{
    public override bool Init()
    {
        if (!base.Init()) return false;

        Main.UI.SetCanvas(gameObject, true);

        return true;
    }

    public virtual void ClosePopupUI()  // �˾��̴ϱ� ���� ĵ����(Scene)�� �ٸ��� �ݴ°� �ʿ�
    {
        Main.UI.ClosePopupUI(this);
    }
}
