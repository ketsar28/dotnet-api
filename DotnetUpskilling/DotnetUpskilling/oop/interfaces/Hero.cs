namespace DotnetUpskilling.interfaces;
    /*
     * java : semua yang ada di Java adalah object
     * C# : 'hampir' semua yang ada di C# adalah object
     *
     * kenapa ? karena di C#, sebagian ada yang menggunakan struct, jadi tidak hanya pakai class. tetapi struct itu mirip seperti class. tetapi sturct ini dipakai pada lingkup yang kecil. misalnya sumbu kartesius (hanya x dan y)
     *
     * bermain dengan object interaction / bermain sesama object
     *
     * interface : adalah class contract yang berisi method tanpa body
     *
     * bukan classnya secara langsung yang digunakan. melainkan kontraknya. tujuannya supaya tidak melenceng dari aturan saat membuat aplikasi.
     *
     * jadi kalau ingin menambahkan fitur baru, tambahkan di kontraknya. supaya tidak ada yang keluar jalur. jadi class servicenya/logicnya cukup turunkan saja/extends method" yag dimiliki dari class kontraknya
     *
     * untuk menghubungkan antar layer aplikasi di API, itu menggunakan interface/class kontrak (OOP)
     */
public class Hero : IHero
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