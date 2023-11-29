using CaseManagerLibrary.Models;

namespace CaseManagerLibrary.DataAccess;

public interface IIssueRepository
{
    Task AddNewIssue(Issue newIssue);
    
    Task<List<Issue>> GetAllCaseIssues(int caseId);
    
    Task DeleteIssue(int id);

    Task<Issue> GetIssueById(int id);
    
    Task UpdateIssue(Issue issue);

    Task<List<Issue>> GetAllSpecialistsIssuesFromCurrentYear(string userId);
}