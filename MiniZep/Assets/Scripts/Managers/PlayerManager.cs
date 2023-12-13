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
        Cash = 200000;

        // #2. Stat 생성
        HP = new StatUnit(100);
        ATK = new StatUnit(25);
        DEF = new StatUnit(20);
        CRIT = new StatUnit(5);

        // #3. 시작 아이템 생성 [TODO => 하드코딩으로 임시 생성]
        Main.Inventory.AddItem(new InventoryItem("item-weapon-01"));
        Main.Inventory.AddItem(new InventoryItem("item-armor-01"));
        Main.Inventory.AddItem(new InventoryItem("item-helm-01"));
        Main.Inventory.AddItem(new InventoryItem("item-shoes-01"));

        // #4 장비 관리 기능 생성
        Equipment = new Equipment();
    }

    /// <summary>
    /// 재화 사용
    /// </summary>
    /// <param name="useCash">사용된 재화 비용</param>
    public void UseCash(int useCash)
    {
        Cash -= useCash;
    }
}
