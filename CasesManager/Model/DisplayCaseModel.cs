using System;
using System.ComponentModel.DataAnnotations;
using CaseManagerLibrary.Models;
using CaseManagerLibrary.Models.IModels;

namespace CasesManager.Model
{
    public class DisplayCaseModel : ICase
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CaseNumber { get; set; }
        [Required]
        public string Principal { get; set; }
        [Required]
        public DateTime DateOfReceipte { get; set; }
    }
}

