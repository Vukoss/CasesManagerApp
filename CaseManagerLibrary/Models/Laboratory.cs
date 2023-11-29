using System.ComponentModel.DataAnnotations;

namespace CaseManagerLibrary.Models
{
    public class Laboratory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string LaboratoryName { get; set; }

        private List<Specialist> Specialists { get; set; }
    }
}