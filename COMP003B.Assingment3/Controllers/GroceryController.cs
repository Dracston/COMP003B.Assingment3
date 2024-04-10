using Microsoft.AspNetCore.Mvc;

namespace COMP003B.Assingment3.Controllers
{
    public class GroceryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
