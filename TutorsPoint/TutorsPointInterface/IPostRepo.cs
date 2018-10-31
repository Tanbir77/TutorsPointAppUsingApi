using System.Collections.Generic;
using TutorsPointEntity;

namespace TutorsPointInterface
{
    public interface IPostRepo
    {
        List<Post> GetAll();
        List<Post> Get(int id);

        List<Post> GetPostsByParentId(int id);
        int Insert(Post post);
        int Update(Post post);
        int Delete(int id);
        int CountPosts();
    }
}