using CoreApp.Models;
using CoreApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Controllers
{
    public class NewsController : Controller
    {
        private readonly NewsContext context;
        private readonly IWebHostEnvironment web;

        public NewsController(NewsContext context, IWebHostEnvironment web)
        {
            this.context = context;
            this.web = web;
        }
        public IActionResult Index()
        {
            NewsCategoryViewModel newsCategoryViewModel = new NewsCategoryViewModel()
            {
                News = context.News.ToList(),
                Categories = context.Categories.ToList()
            };
            return View(newsCategoryViewModel);
        }
        [HttpGet]
        public IActionResult Index(string searchNews,string sortOrder,string currentFilter,int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["Title"] = string.IsNullOrEmpty(sortOrder) ? "t_asc" : "";
            ViewData["CategoryName"] = sortOrder == "Name" ? "n_desc" : "n_asc";
            if (searchNews != null)
                pageNumber = 1;
            else
                searchNews = currentFilter;
            ViewData["CurrentFilter"] = searchNews;
            IEnumerable<News> newsQuery = from n in context.News.ToList() select n;
            IEnumerable<Category> categories = from c in context.Categories.ToList() select c;
            if (!string.IsNullOrEmpty(searchNews))
            {
                newsQuery = newsQuery.Where(n => n.Title.Contains(searchNews) || n.Category.Name.Contains(searchNews));
            }
            NewsCategoryViewModel model = new NewsCategoryViewModel()
            {
                News = newsQuery.ToList()
            };
            switch (sortOrder)
            {
                case "t_asc":
                    model.News = model.News.OrderBy(m => m.Title).ToList();
                    break;
                case "n_desc":
                    model.News = model.News.OrderByDescending(m => m.Category.Name).ToList();
                    break;
                case "n_asc":
                    model.News = model.News.OrderBy(m => m.Category.Name).ToList();
                    break;
                default:
                    model.News = model.News.OrderByDescending(m => m.Title).ToList();
                    break;
            }
            int pageSize = 2;
            List<News> news = new List<News>();
            news = model.News.ToList();
            return View(PaginatedList<News>.Create(news,pageNumber??1,pageSize));
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();
            var n = context.News.Find(id);
            if (n == null)
                return NotFound();
            return View(n);
            
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(context.Categories.ToList(), "Id", "Id");
            return View();
        }
        [HttpPost]
        public IActionResult Create(NewsViewModel model)
        {
            if(ModelState.IsValid)
            {
                UploadImage(model);
                News n = new News();
                n.Id = model.Id;
                n.Image = model.File.FileName;
                n.Date = model.Date;
                n.Title = model.Title;
                n.Topic = model.Topic;
                n.CategoryId = model.CategoryId;

                context.News.Add(n);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Index");
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var n = context.News.Find(id);
            if (n == null)
                return NotFound();
            NewsViewModel newsViewModel = new NewsViewModel()
            {
                Id = n.Id,
                Image = n.Image,
                Title = n.Title,
                Topic = n.Topic,
                Date = n.Date,
                CategoryId = n.CategoryId
            };
            ViewData["CategoryId"] = new SelectList(context.Categories.ToList(), "Id", "Id");
            return View(newsViewModel);
        }
        [HttpPost]
        public IActionResult Edit(NewsViewModel model)
        {
            if(ModelState.IsValid)
            {
                UploadImage(model);
                News news = new News();
                news.Id = model.Id;
                news.Image = model.File.FileName;
                news.Title = model.Title;
                news.Topic = model.Topic;
                news.CategoryId = model.CategoryId;
                context.News.Update(news);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Index");
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            return Details(id);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int? id)
        {
            var news = context.News.Find(id);
            if(news != null)
            {
                context.News.Remove(news);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Index");
        }







        public void UploadImage(NewsViewModel model)
        {
            if (model.File != null)
            {
                string upload = Path.Combine(web.WebRootPath, @"assets\img\gallery");
                string fullPath = Path.Combine(upload, model.File.FileName);
                FileStream fileStream = new FileStream(fullPath, FileMode.Create);
                model.File.CopyTo(fileStream);
            }
        }
    }
}
