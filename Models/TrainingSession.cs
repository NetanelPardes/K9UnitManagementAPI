using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace K9UnitManagementAPI.Models
{
    public class TrainingSession
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "SessionDate is required")]
        public DateTime SessionDate { get; set; }

        [Required(ErrorMessage = "DurationMinutes is required")]
        [Range(1, 300, ErrorMessage = "DurationMinutes should be between 1 and 300")]
        public int DurationMinutes { get; set; }

        [Required(ErrorMessage = "TrainingType is required")]
        [RegularExpression("^(Obedience|ScentDetection|Agility|FieldExercise|Endurance)$", ErrorMessage = "TrainingType must be one of the list")]
        public string TrainingType { get; set; } = string.Empty;

        [Required(ErrorMessage = "PerformanceScore is required")]
        [Range(0, 100, ErrorMessage = "PerformanceScore should be between 0 and 100")]
        public int PerformanceScore { get; set; }

        public bool Passed { get; }

        [Required(ErrorMessage = "Evaluator is required")]
        [StringLength(100, ErrorMessage = "Evaluator maximum characters is 100")]
        public string Evaluator { get; set; } = string.Empty;
    }
}
