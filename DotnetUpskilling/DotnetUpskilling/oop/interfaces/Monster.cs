namespace DotnetUpskilling.interfaces;

public class Monster : IHero
{
    public string Name { get; set; }
    public int Hp { get; set; }
    public int BaseDamage { get; set; }
    
    public void Attack(IHero hero)
    {
        hero.GetHit(BaseDamage);
    }

    public void GetHit(int damage)
    {
        Console.WriteLine($"{Name} get hit : {damage}");
        Hp -= damage;
    }
}