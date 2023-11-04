namespace DotnetUpskilling.abstracts;

public class RunAbstract
{
    public void Main(string[] args)
    {
        /*
         * Abstract test = new RunAbstract(); -> ini error
         * karena abstract class itu tidak bisa kita instance/dibuat objectnya. namun kita bisa buat sebagai tipe data
         */ 
        Rectangle persegi1 = new Rectangle
        {
            Length = 20,
            Width = 20
        };
        
       

        Triangle segitiga1 = new Triangle
        {
            Base = 15,
            Height = 20
        };

        var resultOfRectangle = persegi1.GetSurface();
        var resultOfTriangle = segitiga1.GetSurface();
        Console.WriteLine($"rectangle : {resultOfRectangle}");
        Console.WriteLine($"triangle : {resultOfTriangle}");
    }
}