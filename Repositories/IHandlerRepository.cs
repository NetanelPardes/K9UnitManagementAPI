using K9UnitManagementAPI.Models;

namespace K9UnitManagementAPI.Repositories
{
    public interface IHandlerRepository
    {
        Task<bool> DeleteHandler(int id);
    }
}
