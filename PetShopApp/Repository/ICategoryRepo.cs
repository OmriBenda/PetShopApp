using PetShopApp.Models;

namespace PetShopApp.Repository
{
    public interface ICategoryRepo
    {
        IEnumerable<Category> GetCategoryNames();
    }
}
