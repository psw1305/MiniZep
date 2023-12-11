
public class PlayerManager
{
    public string Name { get; set; }
    public int Gold { get; set; }

    // 임시 스탯 필드 값 => 추후 stat 클래스로 관리 예정
    public int ATK { get; set; }
    public int DEF { get; set; }
    public int HP { get; set; }
    public int CRIT { get; set; }

    public void Initialize()
    {
        Name = "PSW";
        Gold = 10000;
        ATK = 25;
        DEF = 20;
        HP = 100;
        CRIT = 5;
    }
}
