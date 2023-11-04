namespace DotnetUpskilling;

/*
 * naming convention untuk anonymous function : camelCase
 * kita juga bisa membuat callback di anonymous function
 */

public class AnonymousFunction
{
    
    public void Main(string[] args)
    {
        // cara pertama
        var sayHello = delegate()
        {
            Console.WriteLine("Hello Bro!");
        };
        
        // cara kedua mirip arrow function di js
        var sayHelloWithParam = (string name) =>
        {
            Console.WriteLine($"Hello, {name}");
        };

        sayHello();
        sayHelloWithParam("Nabil");
        
        Callback(() =>
        {
            Console.WriteLine("this is callback in anonymous function");
            return true;
        });
    }
    
    public static void Callback(Func<bool> isTrue)
    {
        isTrue.Invoke();
    }
}
