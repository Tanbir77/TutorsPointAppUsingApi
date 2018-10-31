using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TutorsPointInterface;
using TutorsPointEntity;

namespace TutorsPointApi.Controllers
{
    [RoutePrefix("api/appliedLists/{id}")]
    public class appliedListController : ApiController
    {
        IPostRepo repo;
        IApplyInfoRepo applyRepo;
        ITutorRepo tutorRepo;
        public appliedListController(IPostRepo repo,IApplyInfoRepo aRepo,ITutorRepo tRepo)
        {
            this.repo = repo;
            this.applyRepo = aRepo;
            this.tutorRepo = tRepo;
        }
        [Route("")]
        public IHttpActionResult GetAppliedList(int id)
        {
            
            var posts=repo.GetPostsByParentId(id);
            List < Tutor > tutorList= new List<Tutor>();
            if (posts != null)
            {   
                foreach(var post in posts)
                {
                    var applies = (applyRepo.GetAppliesByPostId(post.PostId));
                    foreach (var v in applies)
                    {
                        tutorList.Add(tutorRepo.Get(v.TutorEmail));
                    }
                }
                
                return Ok(tutorList);
            }
            return StatusCode(HttpStatusCode.NoContent);

        }

        
    }
}
