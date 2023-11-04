namespace DotnetUpskilling.now;

/*
 * inheritance : pewarisan yang menurunkan attribute ataupun method di oop
 *
 * keyword untuk inheritance di C# : tanda titik (:)
 *
 * overload : membuat sebuah method dengan nama yang sama namun parameternya berbeda
 * override : berasal dari kata over - write yang artinya menuliskan ulang (contentnya). menuliskan ulang kode didalam method dari parentnya ke childnya
 *
 * jadi di method parentnya perlu ditambahkan keyword 'virtual', dan di childnya ditambahkan keyword 'override'
 *
 * tidak hanya method yang dapat di override, attribute/property pun bisa di override (tapi untuk apa, tidak ada gunanya).
 *
 * bedanya virtual vs abstract :
 * - virtual : tetap memiliki body didalamnya
 * - abstract : 
 * 
 * disclimer :
 * kalau kita tidak menggunakan teknik override ini, akan memakan banyak resource, karena membuat 2/lebih method yang berbeda walau memiliki koneksi.
 *
 */

public class Manager : Employee
{
    public override void SayEmployee(Employee employee)
    {
        Console.WriteLine($"Hi {employee.Name}, saya {Name} (manager)");
    }
}

public class Supervisor : Employee
{
    public override void SayEmployee(Employee employee)
    {
        Console.WriteLine($"Hi {employee.Name}, saya {Name} sebagai supervisor");
    }
}