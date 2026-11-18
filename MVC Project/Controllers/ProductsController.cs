using Microsoft.AspNetCore.Mvc;
using MVC_Project.Models;

namespace MVC_Project.Controllers
{
    public class ProductsController : Controller
    {

        [HttpGet]
        public Product GetProductById(int id)
        {
            return new Product() { Id = 1, Name = "Iphone 15 Pro Max", Price = 20 };
        }


        [HttpGet]
        public JsonResult GetProducts()
        {
            return new JsonResult(new List<Product>()
            {
                new Product(){Id = 1, Name = "P1", Price = 100},
                new Product(){Id = 2, Name = "P2", Price = 130},
                new Product(){Id = 3, Name = "P3", Price = 110},
            });
        }


        [HttpGet]
        public ViewResult Index()
        {
            return new ViewResult();
        }


        [HttpGet]
        public FileContentResult DownloadFile()
        {
            var bytes = System.IO.File.ReadAllBytes("wwwroot/files/notes.txt");
            return new FileContentResult(bytes, "application/txt");
        }

        [HttpGet] // BASEURL/Products/RedirectToUrl
        public RedirectResult RedirectToUrl()
        {
            return new RedirectResult("https://www.google.com");
        }


        [HttpGet]
        public RedirectToActionResult RedirectAction()
        {
            return new RedirectToActionResult("RedirectToUrl", "Products", null);
        }

        public IActionResult Test(int id)
        {
            if (id == 1)
                return View();
            else if (id == 2)
                return Json(new Product() { Id = 1, Name = "Iphone 15 Pro Max", Price = 20 });
            else if (id == 3)
                return Redirect("https://www.facebook.com");
            else
                return View();
        }
    }
}
