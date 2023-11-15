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
    
    public async Task AddNewComment(Comment comment, int issueId, string specialistId)
    {
        string sql = "INSERT INTO public.\"Comments\"(\"CommentText\", \"CommentDate\", \"IssueId\", \"SpecialistId\") VALUES(@CommentText, @CommentDate, @IssueId, @SpecialistId)";
        var p = new
        {
            @CommentText = comment.CommentText,
            @IssueId = issueId,
            @SpecialistId = specialistId,
            @CommentDate = comment.CommentDate
        };
        await _db.SaveData(sql, p, "Default");
    }
    
    public async Task<List<Comment>> GetAllIssueComments(int issueId)
    {
        string sql = "SELECT * FROM public.\"Comments\" c WHERE c.\"IssueId\" = @Id;";
        var p = new
        {
            @Id = issueId
        };
        var output = await _db.LoadData<Comment, dynamic>(sql, p, "Default");
        return output.ToList();
    }
}