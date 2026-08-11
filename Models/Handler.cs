using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace K9UnitManagementAPI.Models
{
    [Index(nameof(PersonalNumber), IsUnique = true)]
    public class Handler
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "FullName is required")]
        [StringLength(100, ErrorMessage = "FullName maximum characters is 100")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "PersonalNumber is required")]
        [StringLength(10, ErrorMessage = "PersonalNumber maximum characters is 10")]
        public string PersonalNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Rank is required")]
        [StringLength(30, ErrorMessage = "Rank maximum characters is 30")]
        public string Rank { get; set; } = string.Empty;

        [Required(ErrorMessage = "YearsOfExperience is required")]
        [Range(0,40,ErrorMessage = "YearsOfExperience should be between 0 and 40")]
        public int YearsOfExperience { get; set; }


        [Required(ErrorMessage = "BaseAssigned is required")]
        [StringLength(100, ErrorMessage = "BaseAssigned maximum characters is 100")]
        public string BaseAssigned { get; set; } = string.Empty;

        [DefaultValue(null)]
        public int? DogId { get; set; } 
        public Dog? dog { get; set; }
    }
}
