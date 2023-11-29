using CaseManagerLibrary.Models;

namespace CaseManagerLibrary.DataAccess;

public interface ICaseRepository
{
    Task AddNewCase(Case newCase);
    Task<Case> GetCaseById(int id);
    Task<List<Case>> GetAllCases();
    Task<List<Case>> GetAllSpecialistsCases(string specialistId);
    Task UpdateCase(Case updateCase);
    Task DeleteCase(int id);
}