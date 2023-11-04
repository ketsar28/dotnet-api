namespace DotnetUpskilling;
/*
 * polymorphism -> poly morphism : banyak bentuk, method overload itu juga termasuk banyak bentuk
 * kita bisa membuat method dengan nama yang sama namun parameternya yang berbeda
 *
 * syarat method overloding :
 * - membuat nama method yang sama, namun parameter berbeda
 * - tidak berlaku untuk parameter yang sama, namun return typenya berbeda
 *
 * constructor termasuk polymorphism : karena dia sebuah method dengan nama dari sebuah class dengan parameter yang berbeda"
 *
 * note :
 * - overloding : termasuk polymorphism, membuat method dengan nama yang sama namun parameternya berbeda
 * - overiding : menulis ulang sebuah method, yang sama dengan method milik parentnya
 */
public class Polymorphism
{
    public string Name { get; set; }
    public int Hp { get; set; }
    public int BaseDamage { get; set; }

    public void Attack(Hero hero)
    {
        hero.GetHit(BaseDamage);
        Console.WriteLine($"{Name} attacked to {hero.Name}");
        
    }

    // method overload
    public void Attack(Monster monster)
    {
        Console.WriteLine($"{Name} has attacked {monster.Name}");
        monster.GetHit(BaseDamage);
        Console.WriteLine($"current Hp {monster.Name} : {monster.Hp}");
    }

    public void GetHit(int damage)
    {
        Console.WriteLine($"{Name} get hit : {damage}");
        Hp -= damage;
    }
}

public class RunningPolymorphism
{
    public static void Main(string[] args)
    {
        Monster jungle = new Monster
        {
            BaseDamage = 200,
            Hp = 500,
            Name = "jungze"
        };

        Polymorphism hero1 = new Polymorphism
        {
            BaseDamage = 250,
            Hp = 500,
            Name = "huza"
        };
       
        hero1.Attack(jungle);
    }
}