using Microsoft.EntityFrameworkCore;
using sahadLearn.API.models.domains;

namespace sahadLearn.API.Data
{
    public class sahadLearnDbContext : DbContext
    {
        public sahadLearnDbContext(DbContextOptions<sahadLearnDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> regions { get; set; }
        public DbSet<Walk> Walks { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Difficulties
            var difficulties = new List<Difficulty>()
            {
                new Difficulty
                {
                    id = Guid.Parse("54466f17-02af-48e7-8ed3-5a4a8bfacf6f"),
                    name = "Easy"
                },
                new Difficulty
                {
                    id = Guid.Parse("ea294873-7a8c-4c0f-bfae-5d6a0a3f3a31"),
                    name = "Medium"
                },
                new Difficulty
                {
                    id = Guid.Parse("f808ddcd-b5e5-4d80-b732-1ca523e48434"),
                    name = "Hard"
                }
            };

            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            // Seed Regions
            var regions = new List<Region>()
            {
                new Region
                {
                    id = Guid.Parse("f7248fc3-2585-4efb-8d1d-1c555f4087f6"),
                    Code = "AKL",
                    name = "Auckland",
                    RegionImage = "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg"
                },
                new Region
                {
                    id = Guid.Parse("6884f7d7-ad1f-4101-8df3-7a6a0b2d9a14"),
                    Code = "NTL",
                    name = "Northland",
                    RegionImage = null
                },
                new Region
                {
                    id = Guid.Parse("14ceba71-4b51-4777-9b17-46602cf66153"),
                    Code = "BOP",
                    name = "Bay Of Plenty",
                    RegionImage = null
                },
                new Region
                {
                    id = Guid.Parse("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"),
                    Code = "WGN",
                    name = "Wellington",
                    RegionImage = "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg"
                },
                new Region
                {
                    id = Guid.Parse("906cb139-415a-4bbb-a174-1a1faf9fb1f6"),
                    Code = "NSN",
                    name = "Nelson",
                    RegionImage = "https://images.pexels.com/photos/13918194/pexels-photo-13918194.jpeg"
                },
                new Region
                {
                    id = Guid.Parse("f077a22e-4248-4bf6-b564-c7cf4e250263"),
                    Code = "STL",
                    name = "Southland",
                    RegionImage = null
                }
            };

            modelBuilder.Entity<Region>().HasData(regions);
        }
    }



}
