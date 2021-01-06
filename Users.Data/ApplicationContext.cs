using Microsoft.EntityFrameworkCore;
using Users.Data.Entities;

namespace Users.Data
{
    public class ApplicationContext : DbContext
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options
            )
            : base(options)
        {
        }
        public DbSet<UserEntity> User { get; set; }
    }
}
