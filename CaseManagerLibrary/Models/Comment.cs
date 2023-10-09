using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CaseManagerLibrary.Models.IModels;

namespace CaseManagerLibrary.Models
{
    public class Comment : IComment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(500)]
        public string CommentText { get; set; }
        public int IssueId { get; set; }
        [ForeignKey("IssueId")]
        public Issue Issue { get; set; }
    }
}