public class Program
{
    // single line comment
    /*
     * multi line comments
     */
    public void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        Console.WriteLine("Bismillah Sukses!");

        // variables - implicit, explicit
        var secondNumber = 30; // implicit
        int number = 20; // explicit


        Console.WriteLine(number);
        Console.WriteLine(secondNumber);

        
        /*
         * number data types
         * dibagi menjadi 2 :
         * - Integer Types :
         * ^ byte 8bit
         * ^ short 16bit
         * ^ int 32bit
         * ^ long 64bit
         *
         * - Floating Point Types :
         * ^ float 32bit
         * ^ double 64bit
         * ^ decimal 128bit
         */

        byte byteNumber = 128;
        short shortNumber = 10000;
        int intNumber = 1000000;
        long longNumber = 100000000L;

        float floatNumber = 11.11F;
        double doubleNumber = 222222222.22d;
        decimal decimalNumber = 33333333333333333333333.3m;
        
        
        
        /*
         * unsigned type number (hanya menerima angka positif)
         * - Integer Types
         * - ushort 16bit
         * - uint
         * - ulong
         */

        ushort unsignedShortNumber = 10;
        uint unsignedIntNumber = 10000;
        ulong unsignedLongNumber = 100000000L;
        

        
        /*
         * String data types
         */

        char myChar = 'k';
        string fullName = "Ketsar Ali";
        
        // escape character
        string escapeCharacter = "this is \"escape character\"";
        Console.WriteLine(escapeCharacter);
        
        // path writing
        string path = @"\Ketsar\programming\dotNet"; // ignore escape character
        Console.WriteLine(path);
        
        // verbatim - ignore verbatim
        Console.WriteLine(@"1. learning
2. reading
3. coding");
        
        
        
        // concatenation
        string firstName = "Muhammad ";
        string concatName = firstName + "Ketsar";
        Console.WriteLine("concat name : " + concatName);
        
        // string interpolation - menampung variable didalam string
        string firstText = "Jakarta";
        string secondText = "Kota";

        string combineText = $"{firstText} {secondText}";
        Console.WriteLine("string interpolation : " + combineText);
    }
}