using sahadLearn.API.models.domains;
using sahadLearn.API.models.DTO;

namespace sahadLearn.API.Repository
{
    public interface IwalkRepository
    {


        Task<Walk> Create(Walk walk);
        Task<Walk> Update(Walk walk ,Guid id);
        Task<Walk?> Delete(Guid id);
        Task<PagedResult<Walk>> GetAll(String ? searchKey , Guid ? regionID , int pageNo, int pageSize);

        Task<Walk?> GetSingle(Guid id);



    }
}
