using System.Web.Http;
using Unity;
using Unity.WebApi;
using TutorsPointInterface;
using TutorsPointRepository;

namespace TutorsPointApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IParentRepo,ParentRepo>();
            container.RegisterType<ITutorRepo, TutorRepo>();
            container.RegisterType<IPostRepo, PostRepo>();
            container.RegisterType<IApplyInfoRepo, ApplyInfoRepo>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}