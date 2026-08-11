using System.ComponentModel.DataAnnotations;

namespace K9UnitManagementAPI.DTO
{
    public class CreateTrainingSessionTDO
    {
        public int DogId { get; set; }
        [RegularExpression("^(Obedience|ScentDetection|Agility|FieldExercise|Endurance)$", ErrorMessage = "TrainingType must be one of the list")]
        public string TrainingType { get; set; } = string.Empty;
        [Required(ErrorMessage = "SessionDate is required")]
        public DateTime SessionDate { get; set; }

        [Required(ErrorMessage = "DurationMinutes is required")]
        [Range(1, 300, ErrorMessage = "DurationMinutes should be between 1 and 300")]
        public int DurationMinutes { get; set; }
        [Required(ErrorMessage = "PerformanceScore is required")]
        [Range(0, 100, ErrorMessage = "PerformanceScore should be between 0 and 100")]
        public int PerformanceScore { get; set; }
        [Required(ErrorMessage = "Evaluator is required")]
        [StringLength(100, ErrorMessage = "Evaluator maximum characters is 100")]
        public string Evaluator { get; set; } = string.Empty;
    }
}
