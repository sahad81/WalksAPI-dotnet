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

            await dbContext.SaveChangesAsync();

            // reload with related data
            return await dbContext.Walks
                .Include(w => w.Defficalty)
                .Include(w => w.Rigion)
                .FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<List<Walk>> GetAll(string? searchKey, Guid? regionID)
        {
            var walks = dbContext.Walks.AsQueryable();

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

            return await walks.ToListAsync();
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
