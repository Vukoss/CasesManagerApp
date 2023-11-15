using CaseManagerLibrary.Data.DataAccess;
using CaseManagerLibrary.Data.UOW;
using CaseManagerLibrary.Data.Repository;
using CaseManagerLibrary.DataAccess;

namespace CaseManagerLibrary.Data.UOW;

public class UnitOfWork : IUnitOfWork
{
    private readonly IDataAccess _db;
    public ICaseRepository CaseRepository { get; set; }
    public IIssueRepository IssueRepository { get; set; }
    public ICommentRepository CommentRepository { get; set; }
    public ILaboratoryRepository LaboratoryRepository { get; set; }
    public ISpecialistRepository SpecialistRepository { get; set; }

    public UnitOfWork(IDataAccess db)
    {
        _db = db;
        CaseRepository = new CaseRepository(_db);
        IssueRepository = new IssueRepository(_db);
        CommentRepository = new CommentRepository(_db);
        LaboratoryRepository = new LaboratoryRepository(_db);
        SpecialistRepository = new SpecialistRepository(_db);
    }
}