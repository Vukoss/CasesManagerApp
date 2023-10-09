using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace CaseManagerLibrary.Models
{
    public class Specialist : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int LaboratoryId { get; set; }
        [ForeignKey("LaboratoryId")]
        public Laboratory Laboratory { get; set; }
        [NotMapped]
        public string FullName
        {
            get
            {
                var fullName = FirstName + " " + LastName;
                return fullName;
            }
        }
    }
}