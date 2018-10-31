using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorsPointEntity;
using TutorsPointInterface;


namespace TutorsPointRepository
{
    public class TutorRepo : ITutorRepo
    {
        TutorsDBContext context = new TutorsDBContext();

        public List<Tutor> GetAll()
        {
            return context.Tutors.ToList();
        }

        public Tutor Get(String email)
        {
            return context.Tutors.SingleOrDefault(t => t.Email == email);
        }

        public Tutor Get(int id)
        {
            return context.Tutors.SingleOrDefault(t => t.TutorId == id);
        }


        public int Insert(Tutor tutor)
        {
            context.Tutors.Add(tutor);
            return context.SaveChanges();
        }

        public int Update(Tutor tutor)
        {
            Tutor TutorToUpdate = context.Tutors.SingleOrDefault(d => d.TutorId == tutor.TutorId);
            TutorToUpdate.TutorName = tutor.TutorName;
            TutorToUpdate.Email = tutor.Email;
            TutorToUpdate.Gender = tutor.Gender;
            TutorToUpdate.DOB = tutor.DOB;
            TutorToUpdate.Institution = tutor.Institution;
            TutorToUpdate.Password = tutor.Password;
            TutorToUpdate.Phone = tutor.Phone;
           

            return context.SaveChanges();
        }

        public int Delete(int id)
        {
            Tutor TutorToDelete = context.Tutors.SingleOrDefault(d => d.TutorId == id);
            context.Tutors.Remove(TutorToDelete);
            return context.SaveChanges();
        }

        public int CountTutors()
        {

            int count = context.Tutors.Count();
            return count;

        }
    }
}
