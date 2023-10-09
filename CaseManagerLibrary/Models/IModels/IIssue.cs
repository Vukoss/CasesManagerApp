namespace CaseManagerLibrary.Models.IModels
{
    public interface IIssue
    {
        int Id { get; set; }
        string IssueNumber { get; set; }
        string Status { get; set; }
        int CaseId { get; set; }
        string SpecialistId { get; set; }
    }
}