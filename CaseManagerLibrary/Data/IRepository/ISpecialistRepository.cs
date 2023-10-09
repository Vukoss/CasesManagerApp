using CaseManagerLibrary.Models;

namespace CaseManagerLibrary.DataAccess;

public interface ISpecialistRepository
{
    Task<Specialist> GetSpecialistByIssueId(int issueId);
    
    Task<List<Specialist>> GetAllSpecialists();
}