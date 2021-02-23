using CoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.ViewModels
{
    public class NewsCategoryViewModel
    {
        public List<News> News { get; set; }
        public List<Category> Categories { get; set; }
    }
}
