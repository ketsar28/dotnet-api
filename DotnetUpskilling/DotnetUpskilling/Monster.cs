namespace DotnetUpskilling;

public class Monster
{
    public string Name { get; set; }
    public int Hp { get; set; }
    public int BaseDamage { get; set; }

    public void GetHit(int damage)
    {
        Console.WriteLine($"{Name} get hit : {damage}");
        Hp -= damage;
    }
}