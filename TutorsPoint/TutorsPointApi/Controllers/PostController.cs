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
    [RoutePrefix("api/Posts")]
    public class PostController : ApiController
    {
        IPostRepo repo;
        public PostController(IPostRepo postRepo)
        {
            this.repo = postRepo;
        }
        // GET: api/Post
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(this.repo.GetAll());
        }

        // GET: api/Post/5
        [Route("{id}", Name = "GetPostById")]
        [BasicAuthentication]
        public IHttpActionResult get(int id)
        {
            var post = this.repo.Get(id);
            if (post == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else return Ok(post);
        }

        // POST: api/Post
        [Route("")]
        [BasicAuthentication]
        public IHttpActionResult Post([FromBody]Post post)
        {
            this.repo.Insert(post);
            string uri = Url.Link("GetPostById", new { id = post.PostId });
            return Created(uri, post);
        }

        // PUT: api/Post/5
        [Route("{id}")]
        public IHttpActionResult Put([FromUri]int id, [FromBody]Post post)
        {
            post.PostId= id;
            this.repo.Update(post);
            return Ok(post);

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
