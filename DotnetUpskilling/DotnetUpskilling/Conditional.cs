namespace DotnetUpskilling;

public class Conditional
{
    public void Main(string[] args)
    {
        /*
         * if(condition - bool)
         * {
         *     statements
         * }
         */

        var i = 10;
        var j = 20;
        var k = 30;
        
        // if ((i < j) && (k < i))
        // {
        //     Console.WriteLine("10 is less than j");
        // } else if (j > i)
        // {
        //     Console.WriteLine("20 is greater than 10");
        // }
        // else
        // {
        //     Console.WriteLine("i don't know about it");
        // }

        /*
         * switch : penyerdehanaan if else statement
         * case tidak direkomendasikan untuk value integer pada switch statement, walaupun bisa
         */
        var grade = "B";
        switch (grade)
        {
            case "A" :
                Console.WriteLine("excellent");
                break;
            case "B" :
                Console.WriteLine("good");
                break;
            case "C" :
                Console.WriteLine("not bad");
                break;
            case "D" :
                Console.WriteLine("failed");
                break;
            default:
                Console.WriteLine("invalid grade");
                break;
        }
        
    }
}