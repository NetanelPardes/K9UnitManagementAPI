using System.ComponentModel.DataAnnotations;

namespace K9UnitManagementAPI.DTO
{
    public class CreateDogDTO
    {
        [StringLength(50, ErrorMessage = "Name maximum characters is 50")]
        public string Name { get; set; }
        [StringLength(50, ErrorMessage = "Breed maximum characters is 50")]
        public string Breed { get; set; }
        [StringLength(15, ErrorMessage = "MicrochipId maximum characters is 15")]
        public string MicrochipId { get; set; }
        public DateTime DateOfBirth { get; set; }
        [RegularExpression("^ExplosiveDetection|NarcoticsDetection|Tracking|Attack|Search$", ErrorMessage = "Specialty must be one of the list")]
        public string Specialty { get; set; }

        [RegularExpression("^Active|InTraining|Retired$", ErrorMessage = "Status must be one of the list")]
        public string? Status { get; set; } = "InTraining";
        public int? HandlerId { get; set; } = null;
    }
}
