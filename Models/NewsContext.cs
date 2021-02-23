using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Models
{
    public class NewsContext:DbContext
    {
        public NewsContext(DbContextOptions<NewsContext> options):base(options)
        {

        }
        public DbSet<News> News { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<ContactUs> Contacts { get; set; }
    }
}
