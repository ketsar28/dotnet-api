namespace DotnetUpskilling;

public class Operator
{
    public void Main(string[] args)
    {
        /*
         * arithmetic operator
         * (+) (-) (*) (/) (%)
         */

        int a = 10 + 10;
        double b = 10.1 + 2;
        
        /*
         * assignment operator
         * (=) assignment
         */

        int c = 20;

        /*
         * operator comparasion (boolean type)
         * <, >, <=, >=, ==, !=
         */

        bool d = 10 > 0;
        
        /*
         * increment, decrement (x++, x--, ++x, --x)
         * x++ : akan ditambahkan apabila dipanggil lagi diline yang berbeda
         * ++x : akan ditambahkan diline yang sama
         */

        var i = 10;
        var j = 20;
        Console.WriteLine(i++);
        Console.WriteLine(++j);
        
        /*
         * logical operator
         * (&&) (||)
         */

        bool logical = (i == 10) && (j == 20);
        Console.WriteLine(logical);

    }
}