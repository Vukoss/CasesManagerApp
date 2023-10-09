using CaseManagerLibrary.Models;
using CaseManagerLibrary.Models.IModels;

namespace CaseManagerLibrary.DataAccess;

public interface ICaseRepository
{
    Task AddNewCase(ICase newCase);
    Task<ICase> GetCaseById(int id);
    Task<List<ICase>> GetAllCases();
    Task<List<ICase>> GetAllSpecialistsCases(string specialistId);
    Task UpdateCase(ICase updateCase);
    Task DeleteCase(int id);
}