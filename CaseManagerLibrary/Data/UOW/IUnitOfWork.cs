using CaseManagerLibrary.DataAccess;

namespace CaseManagerLibrary.Data.UOW;

public interface IUnitOfWork
{
    public ICaseRepository CaseRepository { get; set; }
    public IIssueRepository IssueRepository { get; set; }
    public ICommentRepository CommentRepository { get; set; }
    public ILaboratoryRepository LaboratoryRepository { get; set; }
    public ISpecialistRepository SpecialistRepository { get; set; }
}