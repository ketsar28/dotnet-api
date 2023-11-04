using System.Drawing;

namespace DotnetUpskilling;

/*
 * class -> sebuah blueprint
 * object -> representasi dari sebuah class yang telah dibuat
 * attribute/property -> segala hal yang dimiliki dari sebuah object
 * method : behavior dari sebuah object
 * 
 * kenapa perlu menggunakan paradigma oop ? dengan oop kita bisa buat kode menjadi reusable 
 * reusable : kode yang dibuat dapat digunakan berulang kali, dengan tidak menuliskan kode dan baris yang sama (redundant)
 *
 * di C# bisa dibuat lebih dari 1 class dalam 1 file
 *
 * jika membuat attribute di C# tanpa menggunakan access modifier, dia tidak bisa di akses
 *
 * ada 4 pilar oop :
 * - encapsulation : sebagai pembungkus agar data/attribute didalam class itu aman (untuk si save)
 * - abstraction
 * - polymorphism
 * - inheritance
 *
 *
 * access modifier ada 4 :
 * - public -> bisa diakses dimanapun, class apapun, atau file apapun (direct access)
 * - private -> hanya bisa diakses oleh dirinya sendiri 
 * - protected -> bisa diakses oleh childnya/turunannya/dirinya sendiri
 * - internal -> hanya bisa diakses dilingkup project/modul yang sama
 *
 * untuk access modifier private :
 * - nama attributenya diawali dengan underscore(_)
 */

public class Car
{
    // public string Color;
    // public string Brand;
    // public int Fuel;
    
    // private string _color;
    // private string _brand;
    // private int _fuel;
    
    
    // cara ke 3 - lebih simpel dan efektif
    // walaupun terlihat seperti access modifier, secara default dibalik layarnya ini merupakan 'private'
    public string Color { get; set; }
    public string Brand { get; set; }
    public int Fuel { get; set; }
    
    
    // property/attribute tersebut di inisialisasi datanya dengan sebuah 'constructor' method
    // naming convention untuk parameter itu camelCase - attribute itu naming-nya PascalCase
    // ini namanya : parameterize constructor
    // constructor ini disebut juga overloding method
    
    // public Car(string color, string brand, int fuel)
    // {
    //     Color = color;
    //     Brand = brand;
    //     Fuel = fuel;
    // }
    
    // public Car(string color, string brand, int fuel)
    // {
    //     _color = color;
    //     _brand = brand;
    //     _fuel = fuel;
    // }

    // public Car(string color, string brand, int fuel)
    // {
    //     Color = color;
    //     Brand = brand;
    //     Fuel = fuel;
    // }

    // default consturctor -> constructor tanpa parameter (jadi objectnya bisa dikosongin)
    // constructor ini disebut juga overloding method
    // public Car()
    // {
    // }

    // cara pertama - getter & setter (1)
    
    // public string GetColor()
    // {
    //     return _color;
    // }
    //
    // public void SetColor(string color)
    // {
    //     _color = color;
    // }
    //
    // public string GetBrand()
    // {
    //     return _brand;
    // }
    // public void SetBrand(string brand)
    // {
    //     _brand = brand;
    // }
    //
    // public int GetFuel()
    // {
    //     return _fuel;
    // }
    //
    // public void SetFuel(int fuel)
    // {
    //     _fuel = fuel;
    // }

    
    // cara kedua - mirip direct access(2)
    // kita bisa juga tambahkan validasi di set nya

    // public string Color
    // {
    //     get { return _color; }
    //     set { _color = value; }
    // }
    //
    // public string Brand
    // {
    //     get { return _brand; }
    //     set { _brand = value; }
    // }
    //
    // public int Fuel
    // {
    //     get { return _fuel; }
    //     set
    //     {
    //         if(value != null){ _fuel = value;} 
    //     }
    // }
}
