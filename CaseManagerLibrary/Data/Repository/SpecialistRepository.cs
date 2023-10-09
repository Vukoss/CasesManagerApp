using CaseManagerLibrary.Data.DataAccess;
using CaseManagerLibrary.DataAccess;
using CaseManagerLibrary.Models;

namespace CaseManagerLibrary.Data.Repository;

public class SpecialistRepository : ISpecialistRepository
{
    private readonly IDataAccess _db;
    
    public SpecialistRepository(IDataAccess db)
    {
        _db = db;
    }
    
    public async Task<Specialist> GetSpecialistByIssueId(int issueId)
    {
        string sql = "SELECT u.\"FirstName\", u.\"LastName\", u.\"LaboratoryId\" FROM public.\"Issues\" i INNER JOIN public.\"AspNetUsers\" u ON i.\"SpecialistId\" = u.\"Id\" WHERE i.\"Id\" = @IssueId;";

        var c = new
        {
            @IssueId = issueId
        };

        var output = await _db.LoadData<Specialist, dynamic>(sql, c, "Default");

        return output.FirstOrDefault();
    }
    
    public async Task<List<Specialist>> GetAllSpecialists()
    {
        string sql = "SELECT u.\"Id\", u.\"FirstName\", u.\"LastName\" FROM public.\"AspNetUsers\" u;";

        var output = await _db.LoadData<Specialist, dynamic>(sql, new { }, "Default");

        return output.ToList<Specialist>();
    }
}