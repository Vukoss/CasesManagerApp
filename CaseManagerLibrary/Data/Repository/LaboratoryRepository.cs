using CaseManagerLibrary.Data.DataAccess;
using CaseManagerLibrary.DataAccess;
using CaseManagerLibrary.Models;

namespace CaseManagerLibrary.Data.Repository;

public class LaboratoryRepository : ILaboratoryRepository
{
    private readonly IDataAccess _db;
    
    public LaboratoryRepository(IDataAccess db)
    {
        _db = db;
    }
    
    public async Task<Laboratory> GetLaboratoryNameByLaboratoryId(int laboratoryId)
    {
        string sql = "SELECT l.\"LaboratoryName\" FROM public.\"Laboratories\" l WHERE l.\"Id\" = @LaboratoryId";

        var c = new
        {
            @LaboratoryId = laboratoryId
        };

        var output = await _db.LoadData<Laboratory, dynamic>(sql, c, "Default");

        return output.FirstOrDefault();
    }
    
    public async Task<List<Laboratory>> GetAllLaboratories()
    {
        string sql = "SELECT l.\"Id\", l.\"LaboratoryName\" FROM public.\"Laboratories\" l;";

        var output = await _db.LoadData<Laboratory, dynamic>(sql, new {}, "Default");

        return output.ToList();
    }
}