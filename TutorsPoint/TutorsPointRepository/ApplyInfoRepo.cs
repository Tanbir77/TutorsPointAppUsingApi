using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorsPointInterface;
using TutorsPointEntity;

namespace TutorsPointRepository
{
    public class ApplyInfoRepo:IApplyInfoRepo
    {
        TutorsDBContext context = new TutorsDBContext();

        public List<ApplyInfo> GetAll()
        {
            
            return context.ApplyInfoes.ToList();
        }

        public List<ApplyInfo> GetAppliesByPostId(int id)
        {

            return context.ApplyInfoes.Where(p =>p.PostId==id).ToList();
        }
        public ApplyInfo Get(int id)
        {
            return context.ApplyInfoes.SingleOrDefault(d => d.ApplyId == id);
        }

        public int Insert(ApplyInfo info)
        {
            context.ApplyInfoes.Add(info);
            return context.SaveChanges();
        }

        public int Update(ApplyInfo info)
        {
            ApplyInfo InfoToUpdate = context.ApplyInfoes.SingleOrDefault(d => d.ApplyId == info.ApplyId);
            //updatea code
            return context.SaveChanges();
        }

        public int Delete(int id)
        {
            ApplyInfo InfoToDelete = context.ApplyInfoes.SingleOrDefault(d => d.ApplyId == id);
            context.ApplyInfoes.Remove(InfoToDelete);
            return context.SaveChanges();
        }
        public int CountApplies()
        {
            
            int count=context.ApplyInfoes.Count();
            return count;

        }
    }
}
