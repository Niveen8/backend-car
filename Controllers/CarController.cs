using CarShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarShop.Controllers
{
    public class CarController : Controller
    {
        private CarContext context;
        public CarController(CarContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Search(string searchkey)
        {
            var cars = context.Repositories.Where(c => c.Make.Contains(searchkey)).Include(p => p.Car).Include(p => p.Admin).OrderBy(p => p.Make).ToList();
            return View("CarDetails", cars);
        }


        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Cars =context.Cars.OrderBy(p => p.Make).ToList();
            return View("AddCar");
        }

        [HttpPost]
        public IActionResult Add(Repository cr)
        {
            context.Repositories.Add(cr);
            context.SaveChanges();
            return RedirectToAction("CarDetails", "Car");
        }
        public IActionResult Delete(int id)
        {
            Repository p = context.Repositories.Where(p => p.Id == id).FirstOrDefault();
            context.Remove(p);
            context.SaveChanges();
            return RedirectToAction("CarDetails");
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetInt32("uid") == null)
                return View();
            int? AdminID = HttpContext.Session.GetInt32("uid");
            Admin ad = context.Admins.Find(AdminID);

            return View("Welcome", ad);
        }
        [HttpPost]
        public IActionResult Login(int Aid, string Apass)
        {
            Admin A = context.Admins.Where(p => p.Id == Aid && p.Password == Apass).FirstOrDefault();
            if (A != null)
            {
                HttpContext.Session.SetInt32("uid", Aid);
                int? AdminID = HttpContext.Session.GetInt32("uid");
                Admin ad = context.Admins.Find(AdminID);
                return View("Welcome", ad);
            }
            return View();
        }

        public IActionResult CarDetails()
        {
            var Cars = context.Repositories.Include(p => p.Car).Include(p => p.Admin).OrderBy(p => p.Id).ToList();

            return View("CarDetails",Cars);
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            if (HttpContext.Session.GetInt32("uid") == null)
                return RedirectToAction("Login");
            return View("ChangePassword");

        }
        [HttpPost]
        public IActionResult ChangePassword(string newP)
        {
            //if (HttpContext.Session.GetInt32("uid") == null)
             //   return RedirectToAction("Login");

            int? Aid = HttpContext.Session.GetInt32("uid");
            Admin A = context.Admins.Find(Aid);
            A.Password = newP;
            context.Admins.Update(A);
            context.SaveChanges();

            return View("Login");

        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Index");
        }
    }
}
