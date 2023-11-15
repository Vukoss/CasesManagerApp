using CaseManagerLibrary.Models;

namespace CaseManagerLibrary.DataAccess;

public interface ILaboratoryRepository
{
    Task<Laboratory> GetLaboratoryNameByLaboratoryId(int laboratoryId);
    Task<List<Laboratory>> GetAllLaboratories();
}