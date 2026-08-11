using K9UnitManagementAPI.DTO;
using K9UnitManagementAPI.Models;

namespace K9UnitManagementAPI.Repositories
{
    public interface IDogRepository
    {
        Task<FindDogByIdDTO?> CreatingDog(CreateDogDTO createDogDTO);
        Task<FindDogByIdDTO?> FindDog(int id);

    }
}
