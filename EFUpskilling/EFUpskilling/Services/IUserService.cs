using EFUpskilling.Entities;

namespace EFUpskilling.Services;

public interface IUserService
{
    User CreateUser(User user);
    User GetUserById(string id);
}