using Microsoft.EntityFrameworkCore;
using Products.Data;
using Products.Domain.Entities;
using Products.Repository.Interface;

namespace Products.Repository
{
    public class UserRepository : IUserRepository
    {
        protected readonly ProductsContext _context;
        protected readonly DbSet<User> _user;

        public UserRepository(ProductsContext context)
        {
            _context = context;
            _user = context.Set<User>();
        }

        public User GetUserByUsername(string username) => _user.FirstOrDefault(u => u.Username == username);

        public User AddUser(User user)
        {
            var addedUser = _user.Add(user).Entity;
            _context.SaveChanges();
            return addedUser;
        }
    }
}
