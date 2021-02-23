using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoreApp.Models;
using CoreApp.ViewModels;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace CoreApp.Controllers
{
    public class TeamMembersController : Controller
    {
        private readonly NewsContext _context;
        private readonly IWebHostEnvironment web;

        public TeamMembersController(NewsContext context, IWebHostEnvironment web)
        {
            _context = context;
            this.web = web;
        }

        // GET: TeamMembers
        public IActionResult Index()
        {
            return View( _context.TeamMembers.ToList());
        }
        [HttpGet]
        public IActionResult Index(string searchTeamMembers, string sortOrder, int? pageNumber, string currentFilter)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["Name"] = string.IsNullOrEmpty(sortOrder) ? "n_desc" : "";
            ViewData["JobTitle"] = sortOrder == "JobTitle" ? "j_asc" : "j_desc";
            if (searchTeamMembers != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchTeamMembers = currentFilter;
            }
            ViewData["CurrentFilter"] = searchTeamMembers;
            var membersQuery = from t in _context.TeamMembers.ToList() select t;
            if(!string.IsNullOrEmpty(searchTeamMembers))
            {
                membersQuery = membersQuery.Where(m => m.Name.Contains(searchTeamMembers) || m.JobTitle.Contains(searchTeamMembers));
            }
            switch (sortOrder)
            {
                case "n_desc":
                    membersQuery = membersQuery.OrderByDescending(m => m.Name);
                    break;
                case "j_asc":
                    membersQuery = membersQuery.OrderBy(m => m.JobTitle);
                    break;
                case "j_desc":
                    membersQuery = membersQuery.OrderByDescending(m => m.JobTitle);
                    break;
                default:
                    membersQuery = membersQuery.OrderBy(m => m.Name);
                    break;
            }
            int pageSize = 2;
            return View(PaginatedList<TeamMember>.Create(membersQuery,pageNumber??1,pageSize));
        }
        // GET: TeamMembers/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamMember = _context.TeamMembers.Find(id);
               
            if (teamMember == null)
            {
                return NotFound();
            }
            return View(teamMember);
        }

        // GET: TeamMembers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TeamMembers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TeamMembersViewModel model)
        {
            if(ModelState.IsValid)
            {
                UploadImage(model);
                TeamMember teamMember = new TeamMember()
                {
                    Id = model.Id,
                    Image = model.File.FileName,
                    JobTitle = model.JobTitle,
                    Name = model.Name
                };
                _context.TeamMembers.Add(teamMember);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Index");
        }

        // GET: TeamMembers/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamMember = _context.TeamMembers.Find(id);
            if (teamMember == null)
            {
                return NotFound();
            }
            TeamMembersViewModel model = new TeamMembersViewModel()
            {
                Id = teamMember.Id,
                Name = teamMember.Name,
                Image = teamMember.Image,
                JobTitle = teamMember.JobTitle
            };
            return View(model);
        }

        // POST: TeamMembers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TeamMembersViewModel model)
        {
            
            if (ModelState.IsValid)
            {
                UploadImage(model);
                TeamMember teamMember = new TeamMember()
                {
                    Id = model.Id,
                    Image = model.File.FileName,
                    JobTitle = model.JobTitle,
                    Name = model.Name
                };
                _context.TeamMembers.Update(teamMember);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Index");
        }

        // GET: TeamMembers/Delete/5
        public IActionResult Delete(int? id)
        {
            return Details(id);
        }

        // POST: TeamMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var teamMember =  _context.TeamMembers.Find(id);
            if(teamMember != null)
            {
                _context.TeamMembers.Remove(teamMember);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Index");
        }

        private bool TeamMemberExists(int id)
        {
            return _context.TeamMembers.Any(e => e.Id == id);
        }
        public void UploadImage(TeamMembersViewModel model)
        {
            if (model.File != null)
            {
                string upload = Path.Combine(web.WebRootPath, @"assets\img\testimonials");
                string fullPath = Path.Combine(upload, model.File.FileName);
                FileStream fileStream = new FileStream(fullPath, FileMode.Create);
                model.File.CopyTo(fileStream);
            }
        }
    }
}
