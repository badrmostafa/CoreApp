using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.ViewModels
{
    public class TeamMembersViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name = "Job Name")]
        [Required]
        public string JobTitle { get; set; }
        [Display(Name = "Picture")]
        public string Image { get; set; }
        [Required(ErrorMessage = "This Field is Required.")]
        public IFormFile File { get; set; }
    }
}
