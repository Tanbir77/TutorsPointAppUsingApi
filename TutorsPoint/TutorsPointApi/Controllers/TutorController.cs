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
    [RoutePrefix("api/Tutors")]
    public class TutorController : ApiController
    {
        ITutorRepo repo;
        public TutorController(ITutorRepo tutorRepo)
        {
            this.repo = tutorRepo;
        }
        // GET: api/Tutor
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(this.repo.GetAll());
        }

        // GET: api/Tutor/5
        [Route("{id}", Name = "GetTutorById")]
        public IHttpActionResult get(int id)
        {
            Tutor tutor = this.repo.Get(id);
            if (tutor == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else return  Ok(tutor);
        }

        // POST: api/Tutor
        [Route("")]

        public IHttpActionResult Post(Tutor tutor)
        {   this.repo.Insert(tutor);
            string uri = Url.Link("GetTutorById", new { id = tutor.TutorId });
            return Created(uri,tutor);
        }

        
        [Route("{id}")]
        [BasicAuthentication]
        public IHttpActionResult Put([FromUri]int id, [FromBody]Tutor tutor)
        {
            tutor.TutorId = id;
            this.repo.Update(tutor);
            return Ok(tutor);

        }

        // DELETE: api/Tutor/5
        [Route("{id}")]
        [BasicAuthentication]
        public IHttpActionResult Delete(int id)
        {
            this.repo.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
