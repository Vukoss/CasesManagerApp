using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CaseManagerLibrary.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(500)]
        public string CommentText { get; set; }

        [Required] 
        public DateTime CommentDate { get; set; } = DateTime.Now;
        
        public int IssueId { get; set; }
        [ForeignKey("IssueId")]
        public Issue Issue { get; set; }

        public string SpecialistId { get; set; }
        [ForeignKey("SpecialistId")]
        public Specialist Specialist { get; set; }
    }
}