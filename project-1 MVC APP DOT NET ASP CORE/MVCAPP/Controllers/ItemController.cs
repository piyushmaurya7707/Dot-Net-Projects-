using Microsoft.AspNetCore.Mvc;
using MVCAPP.Controllers;
using MVCAPP.Models;

namespace MVCAPP.Controllers

{
    public class ItemsController : Controller
    {
        
        
        
        public IActionResult Overview() // we cann write ViewResult or ContactResult etc but IActionResult carrya all of this 
        {
            var item = new Items()  { Name = "keyboard" };
            return View(item);
        }


        public IActionResult Edit(int id )

        {
            return Content("id" + id);    
        }
    }
}