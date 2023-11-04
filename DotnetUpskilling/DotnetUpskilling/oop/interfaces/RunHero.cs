namespace DotnetUpskilling.interfaces;

public class RunHero
{
    public void Main(string[] args)
    {
        IHero hero1 = new Hero
        {
            BaseDamage = 200,
            Hp = 1500,
            Name = "Kagura"
        };

        IHero hero2 = new Hero
        {
            Hp = 600,
            Name = "Lancelot",
            BaseDamage = 500
        };

        
        hero1.Attack(hero2);
        hero2.Attack(hero1);
    }
}