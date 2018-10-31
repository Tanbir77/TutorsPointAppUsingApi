using System.Collections.Generic;
using TutorsPointEntity;

namespace TutorsPointInterface
{
    public interface IApplyInfoRepo
    {
        List<ApplyInfo> GetAll();
        ApplyInfo Get(int id);
        List<ApplyInfo> GetAppliesByPostId(int id);
        int Insert(ApplyInfo info);
        int Update(ApplyInfo info);
        int Delete(int id);
        int CountApplies();
    }
}