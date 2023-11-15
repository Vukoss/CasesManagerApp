using CaseManagerLibrary.Models;
using CaseManagerLibrary.Models.IModels;

namespace CaseManagerLibrary.DataAccess;

public interface ICommentRepository
{
    Task AddNewComment(Comment comment, int issueId, string specialistId);
    Task<List<Comment>> GetAllIssueComments(int issueId);
}