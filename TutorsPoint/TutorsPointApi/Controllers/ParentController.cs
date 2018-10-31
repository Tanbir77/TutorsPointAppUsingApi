using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TutorsPointInterface;
using TutorsPointEntity;
using TutorsPointApi.Attributes;

namespace TutorsPointApi.Controllers
{
    [RoutePrefix("api/Parents")]
    public class ParentController : ApiController
    {
        IParentRepo repo;
        public ParentController(IParentRepo parentRepo)
        {
            this.repo = parentRepo;
        }
        // GET api/values
        [Route("")]
        public IHttpActionResult get()
        {
            return Ok(this.repo.GetAll());
        }
        [Route("{id}", Name = "GetParentById")]
        public IHttpActionResult get(int id)
        {
            Parent parent = this.repo.Get(id);
            if (parent == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            
            return Ok(parent);
        }


        [Route("")]
        public IHttpActionResult Post(Parent parent)
        {   this.repo.Insert(parent);

            string uri = Url.Link("GetParentById", new { id = parent.ParentId });
            return Created(uri, parent);
        }
        [Route("{id}")]
        [BasicAuthentication]
        public IHttpActionResult Put([FromBody]Parent parent,[FromUri] int id)
        {
            parent.ParentId = id;
            this.repo.Update(parent);
            return Ok(parent);
        }
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            this.repo.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }

}
