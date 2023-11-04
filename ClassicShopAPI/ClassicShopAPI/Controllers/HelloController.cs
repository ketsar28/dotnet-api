using Microsoft.AspNetCore.Mvc;

namespace CyberShopAPI.Controllers;

/*
 * kalau routenya "[controller]" : dia akan menyesuaikan nama dari class controllernya (PascalCase). tanpa kata 'Controllernya' : jadi : HelloController => /Hello 
 *
 * di rider punya hot reload : jadi akan direload secara otomatis ketika ada perubahan/penambahan kode tetapi aplikasinya masih berjalan
 *
 * kalau returnnya object, secara otomatis akan dikembalikan responsenya sebagai json
 *
 * path variable di C# : sama seperti java /{path}
 * query param : biasa digunakan untuk melakukan searching, dan ini bisa dikombinasikan dengan LINQ. cara membuat query param di C# : 
 */

[ApiController]
[Route("/api/hello")]
public class HelloController
{
    [HttpGet]
    public string SayHello()
    {
        return "hello ketsar!";
    }

    [HttpGet("single-object")]
    public object GetObject()
    {
        return new
        {
            Id = Guid.NewGuid(),
            Name = "hello ketsar ali",
            Date = DateTime.Now
        };
    }
    
    [HttpGet("multiple-object")]
    public List<object> GetMultipleObject()
    {
        return new List<object>
        {
            new
            {
                Id = Guid.NewGuid(),
                Name = "hello ketsar",
                Date = DateTime.Now
            },
            new
            {
                Id = Guid.NewGuid(),
                Name = "hello nabil",
                Date = DateTime.Now
            }
        };
    }

    [HttpGet("/path-variable/{person}")]
    public string GetPersonByName(string person)
    {
        return $"hello {person}";
    }
    
    [HttpGet("/search-person")]
    public object GetPersonWithStatus([FromQuery] string person, [FromQuery] bool isProgrammer)
    {
        return new
        {
            Id = Guid.NewGuid(),
            Name = person,
            IsProgrammer = isProgrammer
        };
    }
}