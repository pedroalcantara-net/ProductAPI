using Products.Domain.ViewModel;

namespace Products.Service.Interface
{
    public interface IUserService
    {
        string Login(UserViewmodel user);
        string SignUp(UserViewmodel user);
    }
}