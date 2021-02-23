using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Models
{
    public class ContactUs
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Client Name")]
        public string Name { get; set; }
        [RegularExpression(@"^\w+([-_.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", 
            ErrorMessage = "This is Not Email Address.")]
        [Required]
        public string Email { get; set; }
        [Required]
        [Range(100,200)]
        public string Message { get; set; }
        [Required]
        [Range(20,30)]
        public string Subject { get; set; }
    }
}
