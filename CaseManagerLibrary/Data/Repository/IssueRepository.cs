using CaseManagerLibrary.Data.DataAccess;
using CaseManagerLibrary.DataAccess;
using CaseManagerLibrary.Models;
using CaseManagerLibrary.Models.IModels;

namespace CaseManagerLibrary.Data.Repository;

public class IssueRepository : IIssueRepository
{
    private readonly IDataAccess _db;
    
    public IssueRepository(IDataAccess db)
    {
        _db = db;
    }
    
    public async Task AddNewIssue(IIssue newIssue)
    {
        string sql = "INSERT INTO public.\"Issues\"(\"IssueNumber\", \"Status\", \"CaseId\", \"SpecialistId\") VALUES(@IssueNumber, @Status, @CaseId, @SpecialistId)";
        var p = new
        {
            @IssueNumber = newIssue.IssueNumber,
            @Status = newIssue.Status,
            @CaseId = newIssue.CaseId,
            @SpecialistId = newIssue.SpecialistId
        };
        await _db.SaveData(sql, p, "Default");
    }
    
    public async Task<List<Issue>> GetAllCaseIssues(int caseId)
    {
        string sql = "SELECT i.\"Id\", i.\"IssueNumber\", i.\"Status\", i.\"CaseId\", i.\"SpecialistId\" FROM public.\"Issues\" i WHERE i.\"CaseId\" = @CaseId;";
        var p = new
        {
            @CaseId = caseId
        };
        
        var output = await _db.LoadData<Issue, dynamic>(sql, new { @CaseId = caseId }, "Default");

        return output.ToList<Issue>();
    }
    
    public async Task DeleteIssue(int id)
    {
        string sql = "DELETE FROM public.\"Issues\" i WHERE i.\"Id\" = @id";
        var p = new
        {
            @id = id
        };
        await _db.SaveData(sql, p, "Default");
    }
    
    public async Task<IIssue> GetIssueById(int id)
    {
        string sql = "SELECT i.\"Id\", i.\"IssueNumber\", i.\"Status\", i.\"CaseId\", i.\"SpecialistId\" FROM public.\"Issues\" i WHERE i.\"Id\" = @Id";

        var p = new
        {
            @Id = id
        };
        var output = await _db.LoadData<Issue, dynamic>(sql, p, "Default");

        return output.FirstOrDefault();
    }

    public async Task UpdateIssue(IIssue editIssue)
    {
        string sql = "UPDATE public.\"Issues\" SET \"Id\" = @Id, \"IssueNumber\" = @IssueNumber, \"Status\" = @IssueStatus, \"CaseId\" = @CaseId, \"SpecialistId\" = @SpecialistId WHERE \"Id\" = @Id";
        var p = new
        {
            @Id = editIssue.Id,
            @IssueNumber = editIssue.IssueNumber,
            @IssueStatus = editIssue.Status,
            @CaseId = editIssue.CaseId,
            @SpecialistId = editIssue.SpecialistId
        };
        await _db.SaveData(sql, p, "Default");
    }
}