using System.Collections.Generic;
using TutorsPointEntity;

namespace TutorsPointInterface
{
    public interface IParentRepo
    {
        List<Parent> GetAll();
        Parent Get(string  email);
        Parent Get(int id);
        int Insert(Parent parent);
        int Update(Parent parent);
        int Delete(int id);
    }
}