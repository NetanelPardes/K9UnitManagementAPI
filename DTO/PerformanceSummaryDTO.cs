using static System.Runtime.InteropServices.JavaScript.JSType;

namespace K9UnitManagementAPI.DTO
{
    public class PerformanceSummaryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public int NumberOfTrainings { get; set; }
        public double AveragePerformanceScore { get; set; }
    }
}
