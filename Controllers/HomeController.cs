using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CoreApp.Models;

namespace CoreApp.Controllers
{
    public class HomeController : Controller
    {
        NewsContext nc;
        public HomeController(NewsContext newsContext)
        {
            nc = newsContext;
        }
        public IActionResult Index()
        {
           List<Category> categories = nc.Categories.ToList();
            return View(categories);
        }
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SaveContact(ContactUs contact)
        {
            nc.Contacts.Add(contact);
            nc.SaveChanges();
            return Redirect("https://localhost:44320/Home/Index");
        }
        public IActionResult Message()
        {
            IEnumerable<ContactUs> contacts = nc.Contacts.ToList();
            return View(contacts);
        }
        public IActionResult News(int Id)
        {
            IEnumerable<News> news = nc.News.Where(n => n.CategoryId == Id)
                .OrderByDescending(d => d.Date).ToList();
            Category category = nc.Categories.Find(Id);
            //ViewBag.CategoryName = category.Name;
            ViewData["categoryName"] = category.Name;
            return View(news);
        }
        
        public IActionResult Delete(int id)
        {
           News n = nc.News.Find(id);
            if (n != null)
            {
                nc.News.Remove(n);
                nc.SaveChanges();
            }
            else
            {
                throw new Exception("Id Not Found In News.");
            }
            return Redirect("https://localhost:44320/");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
