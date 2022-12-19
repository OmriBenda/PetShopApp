using PetShopApp.Models;

namespace PetShopApp.Repository
{
    public interface IRepository<T> : ICategoryRepo, ICommentRepo, ILoginRepo
    {
        IEnumerable<T> GetAnimals();
        IEnumerable<T> TwoMostPopular();
        IEnumerable<T> ByCategory(int categoryID);
        void InsertAnimal(T t);
        void UpdateAnimal(int id, T t);
        void DeleteAnimal(int id);
        T GetAnimalById(int id);
    }
}
