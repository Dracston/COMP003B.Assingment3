using COMP003B.Assingment3.Models;
using Microsoft.AspNetCore.Mvc;


namespace COMP003B.Assingment3.Controllers
{
    public class GroceriesController : Controller
    {
        private static List<Grocery> _groceries = new List<Grocery>();
        //Get:Groceries/
        [HttpGet]
        public IActionResult Index()
        {
            return View(_groceries);
        }

        //Get;Groceries/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //Post:Groceries/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Grocery grocery)
        {
            //Add model state validation
            if (ModelState.IsValid)
            {
                //Check if PLU has been added already
                if (!_groceries.Any(g => g.PLU == grocery.PLU))
                {
                    _groceries.Add(grocery);
                }

                //Redirect to Index
                return RedirectToAction(nameof(Index));
            }
            return View();

        }

        //Get:Groceries/Edit/(plu)
        [HttpGet]
        public IActionResult Edit(int? plu)
        {
            //Check for Null Value
            if (plu == null)
            {
                return NotFound();
            }
            //Try to find product by PLU
            var grocery = _groceries.FirstOrDefault(g => g.PLU == plu);

            //Check if it's still null
            if (grocery == null)
            {
                return NotFound();
            }
            //Return product to View
            return View(grocery);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int plu, Grocery grocery)
        {

            //Check if PLU has been added already
            if (plu != grocery.PLU)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingGrocery = _groceries.FirstOrDefault(g => g.PLU == grocery.PLU);
                if (existingGrocery != null)
                {
                    //Update Grocery details
                    existingGrocery.Name = grocery.Name;
                    existingGrocery.Quantity = grocery.Quantity;
                    //Updates inventory amount/ name changes
                }
                //Returns usere to index
                return RedirectToAction(nameof(Index));
            }
            return View(grocery);
        }

        //Get:Groceries/Delete/(PLU)
        [HttpGet]
        public IActionResult Delete(int? plu)
        {
            //Null check
            if(plu== null)
            {
                return NotFound();
            }
            //Find product by plu
            var grocery = _groceries.FirstOrDefault(g=>g.PLU == plu);

            //Additional null check
            if(grocery == null)
            {
                return NotFound();
            }
            return View(grocery);
        }

        //Post: Grocery/Delete/(plu)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirm(int plu)
        { 
            //Look for product
            var grocery = _groceries.FirstOrDefault(g=> g.PLU == plu);
            //When product PLU if matched
            if(grocery!= null)
            {
                //Remove
                _groceries.Remove(grocery);
            }
            return RedirectToAction(nameof(Index));
        }


    }
}
