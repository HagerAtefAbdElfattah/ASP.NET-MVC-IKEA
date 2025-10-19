using System.Diagnostics;
using System.Text;
using C44_G01_MVC04.BLL.Services.ServicesTesting;
using Microsoft.AspNetCore.Mvc;

namespace C44_G01_MVC04.PL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISingletonServices SingletonServices1;
        private readonly ISingletonServices SingletonServices2;
        private readonly IScopedServices ScopedServices1;
        private readonly IScopedServices ScopedServices2;
        private readonly ITransiantServices TransiantServices1;
        private readonly ITransiantServices TransiantServices2;

        public HomeController(ISingletonServices ISingletonServices1, ISingletonServices ISingletonServices2,
                              IScopedServices IScopedServices1, IScopedServices IScopedServices2,
                              ITransiantServices ITransiantServices1, ITransiantServices ITransiantServices2)
        {
            this.SingletonServices1 = ISingletonServices1;
            this.SingletonServices2 = ISingletonServices2;
            this.ScopedServices1 = IScopedServices1;
            this.ScopedServices2 = IScopedServices2;
            this.TransiantServices1 = ITransiantServices1;
            this.TransiantServices2 = ITransiantServices2;
        }

        public String Index()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Singleton 1: {SingletonServices1.GetGuid()}");
            stringBuilder.AppendLine($"Singleton 2: {SingletonServices2.GetGuid()}");
            stringBuilder.AppendLine($"Scoped 1: {ScopedServices1.GetGuid()}");
            stringBuilder.AppendLine($"Scoped 2: {ScopedServices2.GetGuid()}");
            stringBuilder.AppendLine($"TransiantServices1: {TransiantServices1.GetGuid()}");
            stringBuilder.AppendLine($"TransiantServices2: {TransiantServices2.GetGuid()}");

            ////////////////////////////////////////////////////////////////////////
            ///scoped services will create object per request
            ///
            //transiant services will create object per injection
            //
            //singleton services will create object once for all requests
            /////////////////////////////////////////////////////////////////////
            ///defualt is scoped because I can Have more than one request at the same time in the same application
            ///singleton is useful for real time application like chat application to keep the connection open
            return stringBuilder.ToString();
        }


        public IActionResult Privacy()
        {
            return View();
        }
    }
}
