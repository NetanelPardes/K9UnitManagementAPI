using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace K9UnitManagementAPI.DTO
{
    public class DogsByFiltersTDO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public string Specialty { get; set; }
        public string Status { get; set; }
    }
}
