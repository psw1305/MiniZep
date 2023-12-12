public class PlayerManager
{
    public string Name { get; private set; }
    public int Cash { get; private set; }

    // StatUnit 클래스로 스탯 관리
    public StatUnit HP { get; private set; }
    public StatUnit ATK { get; private set; }
    public StatUnit DEF { get; private set; }
    public StatUnit CRIT { get; private set; }

    public Equipment Equipment { get; private set; }

    public void Initialize()
    {
        // #1. 기본 데이터 설정
        Name = "PSW";
        Cash = 10000;

        // #2. Stat 생성
        HP = new StatUnit(100);
        ATK = new StatUnit(25);
        DEF = new StatUnit(20);
        CRIT = new StatUnit(5);

        // #3. 아이템 생성
        foreach (string key in Main.Data.Items.Keys)
        {
            Main.Inventory.AddItem(new InventoryItem(key));
        }

        // #4 장비 관리 기능 생성
        Equipment = new Equipment();
    }
}
