namespace StatePatternMiniGame;

public class Actor
{
    public string Name { get; set; }
    public int Hp { get; set; }
    public int MaxHp { get; set; }
    public int Damage { get; set; }
    
    public int Defense { get; set; }

    public Actor(string name, int hp, int maxHp, int damage, int defense)
    {
        Name = name;
        Hp = hp;
        MaxHp = maxHp;
        Damage = damage;
        Defense = defense;
    }
}