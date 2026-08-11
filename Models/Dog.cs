using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace K9UnitManagementAPI.Models
{
    public class Dog
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name maximum characters is 50")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Breed is required")]
        [StringLength(50, ErrorMessage = "Breed maximum characters is 50")]
        public string Breed { get; set; } = string.Empty;

        [Required(ErrorMessage = "MicrochipId is required")]
        [StringLength(15, ErrorMessage = "MicrochipId maximum characters is 15")]
        public string MicrochipId { get; set; } = string.Empty;

        [Required(ErrorMessage = "DateOfBirth is required")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Specialty is required")]
        [RegularExpression("^ExplosiveDetection|NarcoticsDetection|Tracking|Attack|Search$" , ErrorMessage = "Specialty must be one of the list")]
        public string Specialty { get; set; } = string.Empty;

        [Required(ErrorMessage = "Status is required")]
        [RegularExpression("^Active|InTraining|Retired$", ErrorMessage = "Status must be one of the list")]
        public string Status { get; set; } = "InTraining";

        [DefaultValue(null)]
        public int? HandlerId { get; set; }

        [JsonIgnore]
        public Handler? handler { get; set; }
        public ICollection<TrainingSession> trainingSessions { get; set; } = new List<TrainingSession>();
    }
}
