using EFUpskilling.Entities;
using EFUpskilling.Repositories;

namespace EFUpskilling.Services.Implements;

public class UserService : IUserService
{
    // pakai cara readonly ini untuk melakukan injection tetapi harus dibuat constructor secara eksplisit
    
    private readonly IRepository<User> _repository;
    private readonly IPersistence _persistence;

    public UserService(IRepository<User> repository, IPersistence persistence)
    {
        _repository = repository;
        _persistence = persistence;
    }

    public User CreateUser(User user)
    {
        try
        {
            var saveUser = _repository.Save(user);
            _persistence.SaveChanges();
            return saveUser;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public User GetUserById(string id)
    {
        try
        {
            var customer = _repository.GetById(Guid.Parse(id));
            if (customer is null) throw new Exception("customer is not found");
            return customer;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}