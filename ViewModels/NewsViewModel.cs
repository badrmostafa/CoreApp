using CoreApp.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.ViewModels
{
    public class NewsViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Display(Name = "Picture")]
        public string Image { get; set; }
        [Required]
        [Range(150,200)]
        public string Topic { get; set; }
        [Required(ErrorMessage = "This Field is Required.")]
        public IFormFile File { get; set; }
        //navigation property
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
