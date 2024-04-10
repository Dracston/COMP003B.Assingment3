using COMP003B.Assingment3.Models;
using Microsoft.AspNetCore.Mvc;


namespace COMP003B.Assingment3.Controllers
{
    public class GroceryController : Controller
    {
        private static List<Grocery> _groceries = new List<Grocery>();
        public IActionResult Index()
        {
            return View(_groceries);
        }

        public IActionResult Create()
        {
            return View();
        }

        //Post:Grocery/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create (Grocery grocery) 
        { 
            //Add model state validation
            if(ModelState.IsValid)
            {
                //Check if PLU has been added already
                if(!_groceries.Any(g=> g.PLU== grocery.PLU))
                {

                }
            }
            
        }
    }
}
