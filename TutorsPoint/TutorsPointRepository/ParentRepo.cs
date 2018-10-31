using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorsPointEntity;
using TutorsPointInterface;

namespace TutorsPointRepository
{
     public class ParentRepo:IParentRepo
    {
        TutorsDBContext context = new TutorsDBContext();

        public List<Parent> GetAll()
        {
            return context.Parents.ToList();
        }

        public Parent Get(String email)
        {
            return context.Parents.SingleOrDefault(d => d.Email == email);
        }
        public Parent Get(int id)
        {
            return context.Parents.SingleOrDefault(d => d.ParentId == id);
        }

        public int  Insert(Parent parent)
        {
            context.Parents.Add(parent);
            return context.SaveChanges();
        }

        public int Update(Parent parent)
        {
            Parent ParentToUpdate = context.Parents.SingleOrDefault(d => d.ParentId == parent.ParentId);
            ParentToUpdate.ParentName = parent.ParentName;
            ParentToUpdate.Email = parent.Email;
            ParentToUpdate.Address = parent.Address;
            ParentToUpdate.Gender = parent.Gender;
            ParentToUpdate.Phone = parent.Phone;
            ParentToUpdate.Password = parent.Password;
            

            return context.SaveChanges();
        }

        public int Delete(int id)
        {
            Parent ParentToDelete = context.Parents.SingleOrDefault(d => d.ParentId == id);
            context.Parents.Remove(ParentToDelete);
            return context.SaveChanges();
        }
    }
}

