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
    [RoutePrefix("api/applies")]
    public class ApplyController : ApiController
    {
        IApplyInfoRepo repo;
        public ApplyController(IApplyInfoRepo applyInfoRepo)
        {
            this.repo = applyInfoRepo;
        }
        // GET: api/Apply
        [Route("")]

        public IHttpActionResult Get()
        {
            return Ok(this.repo.GetAll());
        }

        // GET: api/Apply/5
        [Route("{id}", Name = "GetApplyById")]
        [BasicAuthentication]
        public IHttpActionResult get(int id)
        {
            ApplyInfo info = this.repo.Get(id);
            if (info == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else return Ok(info);
        }

        // POST: api/Apply
        [Route("")]
        [BasicAuthentication]
        public IHttpActionResult Post([FromBody]ApplyInfo info)
        {
            this.repo.Insert(info);
            string uri = Url.Link("GetApplyById", new { id = info.ApplyId });
            return Created(uri, info);
        }

        // PUT: api/Post/5
        [Route("{id}")]
        public IHttpActionResult Put([FromUri]int id, [FromBody]ApplyInfo info)
        {
            info.ApplyId = id;
            this.repo.Update(info);
            return Ok(info);

        }

        // DELETE: api/Tutor/5
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            this.repo.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
