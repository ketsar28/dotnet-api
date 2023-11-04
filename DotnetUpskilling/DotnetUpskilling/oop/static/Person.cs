namespace DotnetUpskilling.now;

/*
 * static vs non-static :
 * - static : cuma 1 aja yang disimpan dialamat memory/dibuat 1 kali dialamat memory. kalau membuat instance object baru, seharusnya berbeda tetapi ini akan tetap sama
 *
 * static Member (method, attribute) : hanya bisa dipanggil disesama static, contoh method static
 *
 * dan best practicenya : method atau attribute yang mengandung static itu disimpan di directory terpisah/di helper directory
 */

public class Person
{
    public static string Name { get; set; }
    public string fullName { get; set; }
    public int Age { get; set; }

    // public override string ToString()
    // {
    //     return $"{nameof(fullName)}: {fullName}, {nameof(Age)}: {Age}";
    // }
}

