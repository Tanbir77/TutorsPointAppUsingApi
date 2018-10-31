using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Filters;
using TutorsPointRepository;
using TutorsPointEntity;


namespace TutorsPointApi.Attributes
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                string encodedString = actionContext.Request.Headers.Authorization.Parameter;
                string decodedString = Encoding.UTF8.GetString(Convert.FromBase64String(encodedString));
                string[] arr = decodedString.Split(new char[] { ':' });
                string email = arr[0];
                string password = arr[1];
                TutorsDBContext context = new TutorsDBContext();
                Tutor tutor = context.Tutors.SingleOrDefault(t => t.Email == email && t.Password == password);
                Parent parent = context.Parents.SingleOrDefault(t => t.Email == email && t.Password == password);
                if (tutor != null)
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity("tutor:"+email), null);
                }
                else if (parent != null)
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity("parent:"+email), null);
                }
                else 
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }

        }
    }
}