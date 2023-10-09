namespace CaseManagerLibrary.Models.IModels
{
    public interface IComment
    {
        int Id { get; set; }
        string CommentText { get; set; }
        int IssueId { get; set; }
    }
}