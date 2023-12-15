using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Repositories
{
    public interface IWalksRepository
    {
        Task<Walk> CreateAsync(Walk walk);
        Task<List<Walk>> GetAllAsync();
        Task<Walk> GetByIdAsync(Guid id);
        Task<Walk> PutAsync(Guid id, Walk walk);
        Task<Walk?> DeleteAsync(Guid id);
    }
}
