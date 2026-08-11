using System.ComponentModel.DataAnnotations;

namespace K9UnitManagementAPI.DTO
{
    public class TrainingWithFullDetailsDTO
    {
        public int Id { get; set; }
        public DateTime SessionDate { get; set; }
        [Range(1, 300, ErrorMessage = "DurationMinutes should be between 1 and 300")]
        public int DurationMinutes { get; set; }
        [RegularExpression("^(Obedience|ScentDetection|Agility|FieldExercise|Endurance)$", ErrorMessage = "TrainingType must be one of the list")]
        public string TrainingType { get; set; } = string.Empty;
        [Range(0, 100, ErrorMessage = "PerformanceScore should be between 0 and 100")]
        public int PerformanceScore { get; set; }
        public bool Passed { get; set; }
        [StringLength(100, ErrorMessage = "Evaluator maximum characters is 100")]
        public string Evaluator { get; set; } = string.Empty;
        public int DogId { get; set; }
        [StringLength(50, ErrorMessage = "Name maximum characters is 50")]
        public string DogName { get; set; } = string.Empty;
        [RegularExpression("^ExplosiveDetection|NarcoticsDetection|Tracking|Attack|Search$", ErrorMessage = "Specialty must be one of the list")]
        public string Specialty { get; set; } = string.Empty;
        [StringLength(100, ErrorMessage = "FullName maximum characters is 100")]
        public string? HandlerFullName { get; set; } = null;
    }
}
