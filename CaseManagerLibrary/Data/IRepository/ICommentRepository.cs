using CaseManagerLibrary.Models;
using CaseManagerLibrary.Models.IModels;

namespace CaseManagerLibrary.DataAccess;

public interface ICommentRepository
{
    Task AddNewComment(IComment comment);
}