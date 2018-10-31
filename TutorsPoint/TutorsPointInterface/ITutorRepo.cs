using System.Collections.Generic;
using TutorsPointEntity;

namespace TutorsPointInterface
{
    public interface ITutorRepo
    {
        List<Tutor> GetAll();
        Tutor Get(string email);
        Tutor Get(int id);
        int Insert(Tutor tutor);
        int Update(Tutor tutor);
        int Delete(int id);
        int CountTutors();
    }
}