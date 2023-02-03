using Products.Domain.Entities;

namespace Products.Repository.Interface
{
    public interface IUserRepository
    {
        User GetUserByUsername(string username);
        User AddUser(User user);
    }
}