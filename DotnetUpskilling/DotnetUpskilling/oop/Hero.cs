namespace DotnetUpskilling;
    /*
     * java : semua yang ada di Java adalah object
     * C# : 'hampir' semua yang ada di C# adalah object
     *
     * kenapa ? karena di C#, sebagian ada yang menggunakan struct, jadi tidak hanya pakai class. tetapi struct itu mirip seperti class. tetapi sturct ini dipakai pada lingkup yang kecil. misalnya sumbu kartesius (hanya x dan y)
     *
     * bermain dengan object interaction / bermain sesama object
     */
public class Hero
{
    public string Name { get; set; }
    public int Hp { get; set; }
    public int BaseDamage { get; set; }

    public void Attack(Hero hero)
    {
       hero.GetHit(BaseDamage);
       Console.WriteLine($"{Name} attacked to {hero.Name}");
        
    }

    public void GetHit(int damage)
    {
        Console.WriteLine($"{Name} get hit : {damage}");
        Hp -= damage;
    }
    
}

public class Running
{
    public void Main(string[] args)
    {
        Hero hero1 = new Hero
        {
            BaseDamage = 200,
            Hp = 1500,
            Name = "Kagura"
        };

        Hero hero2 = new Hero
        {
            Hp = 600,
            Name = "Lancelot",
            BaseDamage = 500
        };

        Console.WriteLine($"before : {hero2.Hp} ");
        
        hero1.Attack(hero2);

        Console.WriteLine($"after : {hero2.Hp}");

        var result = hero1.BaseDamage > hero2.BaseDamage ? "kagura win" : "lancelot win";
        Console.WriteLine($"result is : {result}");
    }
}