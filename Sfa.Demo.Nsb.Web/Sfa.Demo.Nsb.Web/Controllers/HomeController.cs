namespace Sfa.Demo.Nsb.Web.Controllers
{
    using System.Web.Mvc;

    using NServiceBus;

    using Common.Events;

    public class HomeController : Controller
    {
        private readonly IBus _bus;

        public HomeController(IBus bus)
        {
            _bus = bus;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void SendEvent(int number)
        {
            _bus.Publish<IDoSomething>(e => { e.Number = number; });
        }
    }
}