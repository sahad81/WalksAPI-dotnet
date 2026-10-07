using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace sahadLearn.API.Data
{
    public class sahadLearnAuthDbContext : IdentityDbContext
    {
        public sahadLearnAuthDbContext(DbContextOptions<sahadLearnAuthDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); // must be called first

            var readerRoleId = "a1b2c3d4-1111-4a1b-9c1d-111111111111";
            var writerRoleId = "a1b2c3d4-2222-4a1b-9c1d-222222222222";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = readerRoleId,
                    ConcurrencyStamp = readerRoleId,
                    Name = "Reader",
                    NormalizedName = "READER"
                },
                new IdentityRole
                {
                    Id = writerRoleId,
                    ConcurrencyStamp = writerRoleId,
                    Name = "Writer",
                    NormalizedName = "WRITER"
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}