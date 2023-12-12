
public class PlayerManager
{
    public string Name { get; private set; }
    public int Cash { get; private set; }

    // StatUnit 클래스로 스탯 관리
    public StatUnit HP { get; private set; }
    public StatUnit ATK { get; private set; }
    public StatUnit DEF { get; private set; }
    public StatUnit CRIT { get; private set; }

    public InventoryManager Inventory = new();

    public void Initialize()
    {
        Name = "PSW";
        Cash = 10000;

        // Stat 관리
        HP = new StatUnit(100);
        ATK = new StatUnit(25);
        DEF = new StatUnit(20);
        CRIT = new StatUnit(5);
    }
}
