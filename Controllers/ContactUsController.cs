using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoreApp.Models;

namespace CoreApp.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly NewsContext _context;

        public ContactUsController(NewsContext context)
        {
            _context = context;
        }

        // GET: ContactUs
        public IActionResult Index()
        {
            return View(_context.Contacts.ToList());
        }
        [HttpGet]
        public IActionResult Index(string searchContact, string sortOrder,string currentFilter, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["Name"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["Email"] = sortOrder == "Email" ? "email_desc" : "email_asc";
            if (searchContact != null)
                pageNumber = 1;
            else
                searchContact = currentFilter;
            ViewData["CurrentFilter"] = searchContact;
            var contactQuery = from c in _context.Contacts.ToList() select c;
            if(!string.IsNullOrEmpty(searchContact))
            {
                contactQuery = contactQuery.Where(c => c.Name.Contains(searchContact) || c.Email.Contains(searchContact));
            }
            switch(sortOrder)
            {
                case "name_desc":
                    contactQuery = contactQuery.OrderByDescending(c => c.Name);
                    break;
                case "email_desc":
                    contactQuery = contactQuery.OrderByDescending(c => c.Email);
                    break;
                case "email_asc":
                    contactQuery = contactQuery.OrderBy(c => c.Email);
                    break;
                default:
                    contactQuery = contactQuery.OrderBy(c => c.Name);
                    break;
            }
            int pageSize = 2;
            return View(PaginatedList<ContactUs>.Create(contactQuery,pageNumber??1,pageSize));
        }
        // GET: ContactUs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactUs = await _context.Contacts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactUs == null)
            {
                return NotFound();
            }

            return View(contactUs);
        }

        // GET: ContactUs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContactUs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Message,Subject")] ContactUs contactUs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactUs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contactUs);
        }

        // GET: ContactUs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactUs = await _context.Contacts.FindAsync(id);
            if (contactUs == null)
            {
                return NotFound();
            }
            return View(contactUs);
        }

        // POST: ContactUs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Message,Subject")] ContactUs contactUs)
        {
            if (id != contactUs.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactUs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactUsExists(contactUs.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(contactUs);
        }

        // GET: ContactUs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactUs = await _context.Contacts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactUs == null)
            {
                return NotFound();
            }

            return View(contactUs);
        }

        // POST: ContactUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactUs = await _context.Contacts.FindAsync(id);
            _context.Contacts.Remove(contactUs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactUsExists(int id)
        {
            return _context.Contacts.Any(e => e.Id == id);
        }
    }
}
