using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CaseManagerLibrary.Models.IModels;
using CaseManagerLibrary.Utility;

namespace CaseManagerLibrary.Models
{
    public class Issue : IIssue
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string IssueNumber { get; set; }

        [Required] 
        public string Status { get; set; } = SD.StatusPending;

        public int CaseId { get; set; }
        [ForeignKey("CaseId")]
        public Case Case { get; set; }
        public string SpecialistId { get; set; }
        [ForeignKey("SpecialistId")]
        public Specialist Specialist { get; set; }
        
        public List<Comment>  Comments { get; set; }
    }
}