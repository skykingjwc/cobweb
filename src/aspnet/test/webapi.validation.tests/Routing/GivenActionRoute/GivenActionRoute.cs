using System.Web.Http;
using NUnit.Framework;

namespace Aranasoft.Cobweb.Http.Validation.Tests.Routing.GivenActionRoute {
    [TestFixture]
    public abstract class GivenActionRoute {
        protected HttpConfiguration HttpConfiguration;

        [SetUp]
        public void ConfigureRoutes() {
            HttpConfiguration = new HttpConfiguration();
            HttpConfiguration.Routes.MapHttpRoute(name: "default",
                                                  routeTemplate: "{controller}/{action}/{id}",
                                                  defaults: new {id = RouteParameter.Optional});
        }
    }
}
