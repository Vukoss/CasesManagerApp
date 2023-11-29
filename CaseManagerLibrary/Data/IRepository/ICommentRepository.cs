using CaseManagerLibrary.Models;

namespace CaseManagerLibrary.DataAccess;

public interface ICommentRepository
{
    Task AddNewComment(Comment comment, int issueId, string specialistId);
    Task<List<Comment>> GetAllIssueComments(int issueId);
}