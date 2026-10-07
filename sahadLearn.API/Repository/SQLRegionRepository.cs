using Microsoft.EntityFrameworkCore;
using sahadLearn.API.Data;
using sahadLearn.API.models.domains;

namespace sahadLearn.API.Repository
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly sahadLearnDbContext dbContext;
        public SQLRegionRepository(sahadLearnDbContext dbContext)

        {
            
            this.dbContext = dbContext;
        }

        public async  Task<Region> Create(Region region)
        {
             await dbContext.regions.AddAsync(region);
            await dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> Delete(Guid id)
        {
           var existingRegion = dbContext.regions.Find(id);
            if (existingRegion != null)
            {
                dbContext.regions.Remove(existingRegion);
             await   dbContext.SaveChangesAsync();
                return existingRegion;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<Region>> GetAllAsync()
        {
         

            return  await dbContext.regions.ToListAsync();
        }

        public async Task<Region?> GetById(Guid id)
        {
            return   await dbContext.regions
                .FirstOrDefaultAsync(x => x.id == id); ;
        }

        public async Task<Region?> Update(Region region, Guid id)
        {
          var existingRegion = dbContext.regions.Find(id);
            if (existingRegion != null)
            {
                existingRegion.name = region.name;
                existingRegion.Code = region.Code;
                existingRegion.id = region.id;
                existingRegion. RegionImage = region.RegionImage;

           await      dbContext.SaveChangesAsync();
            }
            else
            {
                return null;
            }

            return existingRegion;



        }
    }
}
