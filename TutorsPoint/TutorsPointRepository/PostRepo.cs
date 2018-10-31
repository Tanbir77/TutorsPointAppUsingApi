using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorsPointEntity;
using TutorsPointInterface;

namespace TutorsPointRepository
{
    public class PostRepo : IPostRepo
    {
        TutorsDBContext context = new TutorsDBContext();

        public List<Post> GetAll()
        {
            return context.Posts.ToList();
        }

        public List<Post> Get(int id)
        {
            return context.Posts.Where(i => i.ParentId == id).ToList();
        }

        public List<Post> GetPostsByParentId(int id)
        {
            return context.Posts.Where(i => i.ParentId == id).ToList();
        }


        public int Insert(Post post)
        {
            context.Posts.Add(post);
            return context.SaveChanges();
        }

        public int Update(Post post)
        {
            Post PostToUpdate = context.Posts.SingleOrDefault(i => i.PostId == post.PostId);
            PostToUpdate.Title = post.Title;
            PostToUpdate.cls = post.cls;
            PostToUpdate.Sub = post.Sub;
            PostToUpdate.Salary = post.Salary;
            PostToUpdate.DaysPerWeek = post.DaysPerWeek;
            PostToUpdate.Gender = post.Gender;
            PostToUpdate.Preferable = post.Preferable;
            PostToUpdate.Location = post.Location;
            PostToUpdate.Medium = post.Medium;
            PostToUpdate.ParentEmail = post.ParentEmail;
            PostToUpdate.ParentId = post.ParentId;
            PostToUpdate.Phone = post.Phone;
            return context.SaveChanges();
        }

        public int Delete(int id)
        {
            Post PostToDelete = context.Posts.SingleOrDefault(i => i.PostId == id);
            context.Posts.Remove(PostToDelete);
            return context.SaveChanges();
        }

        public int CountPosts()
        {

            int count = context.Posts.Count();
            return count;

        }
    }
}
