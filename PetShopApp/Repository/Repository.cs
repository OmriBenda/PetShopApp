using Microsoft.EntityFrameworkCore;
using PetShopApp.Data;
using PetShopApp.Models;

namespace PetShopApp.Repository
{
    public class Repository : IRepository<Animal>
    {
        public static List<Login> logins = new List<Login>() { new Login() { Name = "noam", Password = "1" },
        new Login(){Name = "omri", Password = "2"} };
        private PetShopContext _Context;
        public Repository(PetShopContext context)
        {
            _Context = context;
        }

        public void AddComment(int id, string commen)
        {
            Comments com = new Comments() { comment = commen, AnimalId = id };
            _Context.Comments.Add(com);
            _Context.SaveChanges();
        }

        public IEnumerable<Animal> ByCategory(int categoryID)
        {
          return _Context.Categories.Find(categoryID)!.Animals!;
        }

        public bool CheckValid(Login login)
        {
            foreach(var user in logins)
            {
                if(user.Password == login.Password && user.Name == login.Name)
                    return true;
            }
            return false;
        }

        public void DeleteAnimal(int id)
        {
            var Animal = _Context.Animals.FirstOrDefault(a => a.AnimalId == id);
            _Context.Animals.Remove(Animal);
            _Context.SaveChanges();
        }

        public Animal GetAnimalById(int id)
        { 
            return _Context.Animals.First(a => a.AnimalId == id);
        }

        public IEnumerable<Animal> GetAnimals()
        {
            return _Context.Animals;
        }

        public IEnumerable<Category> GetCategoryNames()
        {
            return _Context.Categories;
        }

        public IEnumerable<Comments> GetComments(int id)
        {
            return _Context.Animals.Single(a => a.AnimalId == id).Comments!;
        }

        public void InsertAnimal(Animal t)
        {
            _Context.Animals.Add(t);
            _Context.SaveChanges();
        }

        public IEnumerable<Animal> TwoMostPopular()
        {
            //return _Context.Animals!.Include(c => c.Comments)
            //      .OrderByDescending(c => c.Comments!.Count)
            //      .Take(2).ToList();
           return _Context.Animals.OrderByDescending(a => a.Comments!.Count).Take(2).ToList();
        }

        public void UpdateAnimal(int id, Animal t)
        {
            var AnimalInDb = _Context.Animals.Single(a => a.AnimalId == id);
            AnimalInDb.Name = t.Name;
            AnimalInDb.Age = t.Age;
            AnimalInDb.Description = t.Description;
            AnimalInDb.PictureName = t.PictureName;
            AnimalInDb.Comments = t.Comments;
            AnimalInDb.CategoryId = t.CategoryId;
            AnimalInDb.Category = t.Category;
            _Context.SaveChanges();
        }
    }
}
