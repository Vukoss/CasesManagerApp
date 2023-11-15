using System;
using System.ComponentModel.DataAnnotations;
using CaseManagerLibrary.Models.IModels;

namespace CaseManagerLibrary.Models
{
    public class Case : ICase
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string CaseNumber { get; set; }
        [Required]
        [MaxLength(300)]
        public string Principal { get; set; }
        
        [Required] 
        public DateTime DateOfReceipte { get; set; } = DateTime.Now;
        
        public List<Issue> Issues { get; set; }
    }
}