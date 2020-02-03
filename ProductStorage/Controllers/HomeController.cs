using ProductStorage.Core.Models.Products;
using System.Web.Mvc;

namespace ProductStorage.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }

        // GET: Home/Login
        [HttpGet]
        public ViewResult Login()
        {
            return View();
        }
    }
}
