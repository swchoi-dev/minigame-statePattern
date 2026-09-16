namespace StatePatternMiniGame;

public class Actor
{
    private int _hp;
    private int _damage;
    
    public string Name { get; set; }

    public int Hp
    {
        get => _hp;
        set => Math.Clamp(value, 0, MaxHp);
    }
    public int MaxHp { get; set; }

    public int Damage
    {
        get => _damage;
        set => Math.Clamp(value, 0, MaxHp);
    }
    
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