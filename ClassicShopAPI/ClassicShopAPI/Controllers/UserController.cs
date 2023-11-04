using ClassicShopAPI.Entities;
using ClassicShopAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ClassicShopAPI.Controllers;

/*
 * kalau mau customer value HttpStatusnya itu bisa, menggunakan Task<IActionResult>
 *
 * interface IActionResult ini sama seperti Response Entity di java
 *
 * C# vs Java :
 * - Task<IActionResult> => ResponseEntity<>
 * - [FromBody] => @RequestBody
 * - [FromQuery] => @RequestParam
 * - [ApiController] => @RestController
 * - [Route(url: "")] => @RequestMapping(value: "")
 *
 * disclaimer :
 * - untuk update, walaupun kita tidak mengubah semua datanya, tetapi kita harus mengirimkan seluruh property beserta value sebelumnya
 */

[ApiController]
[Route("/api/customers")]
public class UserController : ControllerBase
{
    private readonly IRepository<User> _userRepository;
    private readonly IPersistence _persistence;

    public UserController(IRepository<User> userRepository, IPersistence persistence)
    {
        _userRepository = userRepository;
        _persistence = persistence;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] User payload)
    {
        var customer = await _userRepository.SaveAsync(payload);
        await _persistence.SaveChangesAsync();
        return Created("/api/customers", customer);
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetUserById(string userId)
    {
        var user = await _userRepository.FindByIdAsync(Guid.Parse(userId));
        return Ok(user);
    }

    [HttpGet]
    public async Task<IActionResult> GetUserByName([FromQuery] string name, [FromQuery] string address)
    {
        var customer = await _userRepository.FindAsync(user => user.CustomerName.Equals(name) && user.Address.Equals(address));
        return Ok(customer);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser([FromBody] User user)
    {
        var customer = _userRepository.Update(user);
        await _persistence.SaveChangesAsync();
        return Ok(customer);
    }

    [HttpDelete("{userId}")]
    public async Task<IActionResult> DeleteUser(string userId)
    {
        try
        {
            var customer = await _userRepository.FindByIdAsync(Guid.Parse(userId));
            if (customer is null) return NotFound("customer is not found");
            _userRepository.Delete(customer);
            await _persistence.SaveChangesAsync();
            return Ok($"{customer.CustomerName} has been deleted");
        }
        catch (Exception e)
        {
            return new StatusCodeResult(500);
        }
    }
}