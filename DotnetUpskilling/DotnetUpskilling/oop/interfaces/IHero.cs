namespace DotnetUpskilling.interfaces;
/*
 * naming convention di C# : diawali dengan huruf I sebelum nama interfacenya
 *
 * di interface secara default/secara implicit sudah ada access modifier public, jadi tidak perlu ditambahkan
 *
 * kegunaan interface :
 * - membuat kontrak sebuah method, agar tidak dibuat secara berulang/boilerplate code
 * - digunakan juga untuk membuat sebuah layer aplikasi

 * bukan classnya secara langsung yang digunakan. melainkan kontraknya. tujuannya supaya tidak melenceng dari aturan saat membuat aplikasi.
 *
 * jadi kalau ingin menambahkan fitur baru, tambahkan di kontraknya. supaya tidak ada yang keluar jalur. jadi class servicenya/logicnya cukup turunkan saja/extends method" yag dimiliki dari class kontraknya
 *
 * untuk menghubungkan antar layer aplikasi di API, itu menggunakan interface/class kontrak (OOP)
 */
public interface IHero
{
    
    public string Name { get; set; }
    public int Hp { get; set; }
    public int BaseDamage { get; set; }
    
    void GetHit(int damage);
    void Attack(IHero hitAble);
}