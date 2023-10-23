using CaseManagerLibrary.Data.DataAccess;
using CaseManagerLibrary.DataAccess;
using CaseManagerLibrary.Models;
using CaseManagerLibrary.Models.IModels;
using Microsoft.EntityFrameworkCore;

namespace CaseManagerLibrary.Data.Repository;

public class CaseRepository : ICaseRepository
{
    private readonly IDataAccess _db;
    public CaseRepository(IDataAccess db)
    {
        _db = db;
    }
    public async Task AddNewCase(ICase newCase)
    {
        string sql = "INSERT INTO public.\"Cases\"(\"CaseNumber\", \"Principal\", \"DateOfReceipte\") VALUES(@CaseNumber, @Principal, @DateOfReceipte)";
        var p = new
        {
            @CaseNumber = newCase.CaseNumber,
            @Principal = newCase.Principal,
            @DateOfReceipte = newCase.DateOfReceipte
        };
        await _db.SaveData(sql, p, "Default");
    }

    public async Task<ICase> GetCaseById(int id)
    {
        string sql = "SELECT c.\"Id\", c.\"CaseNumber\", c.\"Principal\", c.\"DateOfReceipte\" FROM public.\"Cases\" c WHERE c.\"Id\" = @Id;";
        var p = new
        {
            @Id = id
        };
        var output = await _db.LoadData<Case, dynamic>(sql, p, "Default");
        return output.FirstOrDefault();
    }

    public async Task UpdateCase(ICase editCase)
    {
        var sql = "UPDATE public.\"Cases\" SET \"CaseNumber\" = @CaseNumber, \"Principal\" = @Principal, \"DateOfReceipte\" = @DateOfReceipte WHERE \"Id\" = @Id;";
        var p = new
        {
            @Id = editCase.Id,
            @CaseNumber = editCase.CaseNumber,
            @Principal = editCase.Principal,
            @DateOfReceipte = editCase.DateOfReceipte
        };
        await _db.SaveData(sql, p, "Default");
    }
    
    public async Task<List<ICase>> GetAllCases()
    {
        string sql = "SELECT \"Id\", \"CaseNumber\", \"Principal\", \"DateOfReceipte\" FROM public.\"Cases\";";

        var output = await _db.LoadData<Case, dynamic>(sql, new { }, "Default");

        return output.ToList<ICase>();
    }
    
    public async Task<List<ICase>> GetAllSpecialistsCases(string specialistId)
    {
        string sql = "SELECT c.\"Id\", c.\"CaseNumber\", c.\"Principal\", c.\"DateOfReceipte\" FROM public.\"Issues\" i INNER JOIN public.\"Cases\" c ON i.\"CaseId\" = c.\"Id\" INNER JOIN public.\"AspNetUsers\" u ON i.\"SpecialistId\" = u.\"Id\" WHERE u.\"Id\" = @SpecialistId;";
        var c = new
        {
            @SpecialistId = specialistId
        };
    
        var output = await _db.LoadData<Case, dynamic>(sql, c, "Default");
    
        return output.ToList<ICase>();
    }
    
    public async Task DeleteCase(int id)
    {
        string sql = "DELETE FROM public.\"Cases\" c WHERE c.\"Id\" = @id;";
        var p = new
        {
            @id = id
        };
        await _db.SaveData(sql, p, "Default");
    }


}