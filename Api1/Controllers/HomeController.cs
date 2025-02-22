using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api1.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomeController
        public ActionResult Index()
        {

            Models.ApplicationDbContext? context = HttpContext.RequestServices.GetService(typeof(Api1.Models.ApplicationDbContext)) as Models.ApplicationDbContext;

            //return View(context.GetAllHousing());
            return View();
        }


    }
}
