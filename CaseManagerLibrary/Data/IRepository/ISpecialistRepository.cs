using CaseManagerLibrary.Models;

namespace CaseManagerLibrary.DataAccess;

public interface ISpecialistRepository
{
    Task<Specialist> GetSpecialistByIssueId(int issueId);

    Task<Specialist> GetSpecialistById(string id);
    
    Task<List<Specialist>> GetAllSpecialists();
}