namespace DotnetUpskilling;

public enum Direction
{
    // data enum = members
    North,
    East,
    South,
    West
}

public enum Role
{
    // data enum = members
    Manager,
    Employee = 3,
    Admin,
    User
}

// penerapan solid : konsep single responsibility, dimana yang bertanggung jawab untuk suatu class, hanya class itu sendiri
public class Types
{
    // accessModifier enum Gender - using private modifier (karena didalam lingkup class)
    private enum Gender
    {
        // penulisan : PascalCase
        Male, Female // members of enum
    }
    
    public void Main(string[] args)
    {
        /*
         * ENUM
         
         Enum : kumpulan data constant yang tidak bisa di ubah"/sudah fix datanya
          - seperti : gender, role, mata angin, payment method
          - untuk membuat enum, bisa dibuat didalam class ataupun diluar class
          
          note : 
          - data enum tidak bisa di looping, harus dipanggil menggunakan titik (.)
         */

        
        // akses enum didalam class
        var gender = GetGender();
        Console.WriteLine("first gender : " + gender);
        Console.WriteLine("second gender : " + Gender.Female);
        
        
        // akses enum diluar class
        Console.WriteLine($"enum role : {Role.Manager}");
        Console.WriteLine($"enum direction : {Direction.West}");

        
        // ini merupakan 'casting' : sebuah teknik untuk merubah dari suatu tipe data menjadi tipe data lain
        var employee = (int) Role.Employee;
        Console.WriteLine(employee);
    }

    // secara default access modifiernya itu 'private' apabila tidak di berikan
    static Gender GetGender()
    {
        return Gender.Male;
    }
}