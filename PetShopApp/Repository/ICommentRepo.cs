using PetShopApp.Models;

namespace PetShopApp.Repository
{
    public interface ICommentRepo
    {
        IEnumerable<Comments> GetComments(int id);
        void AddComment(int id, string comment);
    }
}
