namespace CaseManagerLibrary.Models.IModels
{
    public interface ICase
    {
        int Id { get; set; }
        string CaseNumber { get; set; }
        string Principal { get; set; }
        DateTime DateOfReceipte { get; set; }
    }
}