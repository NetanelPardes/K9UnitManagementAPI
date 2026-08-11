using System.ComponentModel.DataAnnotations;

namespace K9UnitManagementAPI.DTO
{
    public class TrainingListTDO
    {
        public List<TrainingWithFullDetailsDTO> Items { get; set; }
        public int TotalResults { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
    }
}
