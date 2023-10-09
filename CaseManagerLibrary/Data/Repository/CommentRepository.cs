using CaseManagerLibrary.Data.DataAccess;
using CaseManagerLibrary.DataAccess;
using CaseManagerLibrary.Models;
using CaseManagerLibrary.Models.IModels;

namespace CaseManagerLibrary.Data.Repository;

public class CommentRepository : ICommentRepository
{
    private readonly IDataAccess _db;
    
    public CommentRepository(IDataAccess db)
    {
        _db = db;
    }
    
    public async Task AddNewComment(IComment comment)
    {
        string sql = "INSERT INTO public.\"Comments\"(CommentText, IssueId) VALUES(@CommentText, @IssueId)";
        var p = new
        {
            @CommentText = comment.CommentText,
            @IssueId = comment.IssueId
        };
        await _db.SaveData(sql, p, "Default");
    }
}