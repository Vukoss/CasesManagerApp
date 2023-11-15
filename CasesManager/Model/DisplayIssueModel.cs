using System.ComponentModel.DataAnnotations;
using CaseManagerLibrary.Models.IModels;
using CaseManagerLibrary.Utility;

namespace CasesManager.Model
{
    public class DisplayIssueModel : IIssue
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string IssueNumber { get; set; }
        [Required]
        public string Status { get; set; } = SD.StatusPending;
        [Required]
        public int CaseId { get; set; }
        [Required]
        public string SpecialistId { get; set; }
    }
}

