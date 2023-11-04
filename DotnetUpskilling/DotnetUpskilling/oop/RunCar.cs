namespace DotnetUpskilling;

public class RunCar
{
  
    public void Main(string[] args)
    {
        // Car ferarri = new Car("red", "suzuki", 500);
        // Car lamborgini = new Car("blue", "yamaha", 800);

        // Console.WriteLine($"ferrari : {ferarri.GetColor()}");
        // Console.WriteLine($"ferrari : {ferarri.GetBrand()}");
        // Console.WriteLine($"ferrari : {ferarri.GetFuel()}");
        //
        // Console.WriteLine($"lamborgini : {lamborgini.GetColor()}");
        // Console.WriteLine($"lamborgini : {lamborgini.GetBrand()}");
        // Console.WriteLine($"lamborgini : {lamborgini.GetFuel()}");
        
        
        // cara ke 1
        // direct access : mengisikan attribute secara langsung itu tidak aman
        // Car avanza = new Car();
        
        // avanza.SetColor("green");
        // avanza.SetBrand("toyota");
        // avanza.SetFuel(30);
        //
        // Console.WriteLine($"avanza : {avanza.GetColor()}");
        
        
        // cara ke 2

        // avanza.Color = "black";
        // Console.WriteLine($"avanza : {avanza.Color}");
        
        
        // cara ke 3
        
        // inisialisasi attribute = mirip seperti object di js
        Car inova = new Car
        {
            Color = "yellow",
            Brand = "toyota",
            Fuel = 250
        };
        
        Console.WriteLine($"color (inova) : {inova.Color}");
        Console.WriteLine($"brand (inova) : {inova.Brand}");
        Console.WriteLine($"fuel (inova) : {inova.Fuel}");

    }
}