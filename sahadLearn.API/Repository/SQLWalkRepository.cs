using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using sahadLearn.API.Data;
using sahadLearn.API.models.domains;
using sahadLearn.API.models.DTO;

namespace sahadLearn.API.Repository
{
    public class SQLWalkRepository : IwalkRepository
    {
        private readonly sahadLearnDbContext dbContext;
        public SQLWalkRepository(sahadLearnDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Walk?> Create(Walk walk)
        {
            await dbContext.Walks.AddAsync(walk);
            await dbContext.SaveChangesAsync();

            return walk;
        }

      
        public async Task<Walk?> Delete(Guid id)
        {
            var existing = await dbContext.Walks.FirstOrDefaultAsync(x => x.id == id);

            if (existing == null)
            {
                return null;
            }
            else
            {


                dbContext.Walks.Remove(existing);
             await   dbContext.SaveChangesAsync();
                return existing;
            }
            {
                
            }
        }

        public async Task<Walk?> Update(Walk walk, Guid id)
        {
            var existing = await dbContext.Walks.FirstOrDefaultAsync(x => x.id == id);

            if (existing == null)
                return null;

            existing.name = walk.name;
            existing.discription = walk.discription;
            existing.LegthInKm = walk.LegthInKm;
            existing.WalkImageUrl = walk.WalkImageUrl;
            existing.difficaltyId = walk.difficaltyId;
            existing.RegionID = walk.RegionID;
            if (walk.WalkImageUrl != null)
            {
                existing.WalkImageUrl = walk.WalkImageUrl;
            }

            await dbContext.SaveChangesAsync();

            // reload with related data
            return await dbContext.Walks
                .Include(w => w.Defficalty)
                .Include(w => w.Rigion)
                .FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<PagedResult<Walk>> GetAll(
     String? searchKey, Guid? regionID, int pageNo, int pageSize)
        {
            // Guard against invalid values
            pageNo = pageNo < 1 ? 1 : pageNo;
            pageSize = pageSize < 1 ? 10 : Math.Min(pageSize, 100); // cap max page size

            var walks = dbContext.Walks.AsNoTracking().AsQueryable();

            if (regionID.HasValue)
            {
                walks = walks.Where(x => x.RegionID == regionID.Value);
            }

            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                walks = walks.Where(x =>
                    x.name.Contains(searchKey) ||
                    x.discription.Contains(searchKey));
            }

            // Count AFTER filters, BEFORE Skip/Take
            var totalCount = await walks.CountAsync();

            var items = await walks
                .OrderBy(x => x.name)              // required for stable paging
                .Skip((pageNo - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<Walk>
            {
                Items = items,
                TotalCount = totalCount,
                PageNo = pageNo,
                PageSize = pageSize
            };
        }
        public async Task<Walk?> GetSingle(Guid id)
        {
            return await dbContext.Walks
                .Include(w => w.Defficalty)
                .Include(w => w.Rigion)
                .FirstOrDefaultAsync(x => x.id == id);
        }
    }
}
