using BibliotekaCentralna.Model;
using Microsoft.EntityFrameworkCore;

namespace BibliotekaCentralna.Domain
{
    public class CentralnaDbContext : DbContext
    {
        public DbSet<Member> Users { get; set; }
        public DbSet<Rent> Rents { get; set; }

        public CentralnaDbContext(DbContextOptions<CentralnaDbContext> options) : base(options) { }
        protected CentralnaDbContext() { }
    }
}
