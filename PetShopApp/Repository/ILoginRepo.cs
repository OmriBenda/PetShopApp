using PetShopApp.Models;

namespace PetShopApp.Repository
{
    public interface ILoginRepo
    {
        bool CheckValid(Login login);
    }
}
