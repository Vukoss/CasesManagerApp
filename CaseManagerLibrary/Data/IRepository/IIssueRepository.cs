using CaseManagerLibrary.Models;
using CaseManagerLibrary.Models.IModels;

namespace CaseManagerLibrary.DataAccess;

public interface IIssueRepository
{
    Task AddNewIssue(IIssue newIssue);
    
    Task<List<Issue>> GetAllCaseIssues(int caseId);
    
    Task DeleteIssue(int id);

    Task<IIssue> GetIssueById(int id);
    
    Task UpdateIssue(IIssue issue);
}