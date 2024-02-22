using Microsoft.AspNetCore.Mvc;
using NET7.Models;
using NET7.Repository;
using System.Diagnostics;

namespace NET7.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISingletonServices _singleton;
        private readonly ISingletonServices _singleton1;
        private readonly IScopedServies _scoped;
        private readonly IScopedServies _scoped1;
        private readonly ITransientServices _transient;
        private readonly ITransientServices _transient1;
        public HomeController(ILogger<HomeController> logger, ISingletonServices singleton, ISingletonServices singleton1, IScopedServies scoped, IScopedServies scoped1, ITransientServices transient, ITransientServices transient1)
        {
            _logger = logger;
            _singleton1 = singleton1;
            _singleton = singleton;
            _scoped = scoped;
            _scoped1 = scoped1;
            _transient = transient;
            _transient1 = transient1;
        }

        public IActionResult Index()
        {
            ViewBag.singleton = _singleton.GetTaskId().ToString();
            ViewBag.singleton1 = _singleton1.GetTaskId().ToString();
            ViewBag.scoped = _scoped.GetTaskId().ToString();
            ViewBag.scoped1 = _scoped1.GetTaskId().ToString();
            ViewBag.transient = _transient.GetTaskId().ToString();
            ViewBag.transient1 = _transient1.GetTaskId().ToString();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}