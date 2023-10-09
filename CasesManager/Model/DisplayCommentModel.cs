using System;
using System.ComponentModel.DataAnnotations;
using CaseManagerLibrary.Models;
using CaseManagerLibrary.Models.IModels;

namespace CasesManager.Model
{
    public class DisplayCommentModel : IComment
    {
        public int Id { get; set; }
        [Required]
        public string CommentText { get; set; }
        [Required]
        public int IssueId { get; set; }
    }
}

