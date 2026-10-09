using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using  MyApp.Models;



namespace MyApp.Controllers
{
    public class IsActionReault : Controller
    {
        
        public  IActionReault OverView()
        {
            var item = new Item() {NameAuthorizationRequirement = { Name = "keyboard" };
            return View(item);
        }
    }
}
