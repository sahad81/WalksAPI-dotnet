using sahadLearn.API.models.domains;

namespace sahadLearn.API.Repository
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync();
        Task<Region?> GetById(Guid id);

        Task<Region> Create(Region region);
        Task<Region?> Update(Region region , Guid id);
        Task<Region> Delete(Guid id);

    }
}
