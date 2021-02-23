using CoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Controllers
{
    public class TeamController : Controller
    {
        private readonly NewsContext db;

        public TeamController(NewsContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
           IEnumerable<TeamMember> teamMembers  = db.TeamMembers.ToList();
            return View(teamMembers);
        }
    }
}
