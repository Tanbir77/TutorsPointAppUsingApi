using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using TutorsPointApi.Attributes;
using TutorsPointInterface;
using TutorsPointEntity;

namespace TutorsPointApi.Controllers
{   [RoutePrefix("api/users")]
    public class UserController : ApiController
    {
        ITutorRepo repo;
        IParentRepo pRepo;
        
        public UserController(ITutorRepo tutorRepo,IParentRepo parentRepo)
        {
            this.repo = tutorRepo;
            this.pRepo = parentRepo;
        }
        [Route("")]
        [BasicAuthentication]
        public IHttpActionResult Get()
        {
            string[] arr = Thread.CurrentPrincipal.Identity.Name.Split(new char[] { ':' });
            if (arr[0] == "parent")
            {
                return Ok(pRepo.Get(arr[1]));
            }
            else
            {
                return Ok(repo.Get(arr[1]));
            }
          
        }

       
    }
}
