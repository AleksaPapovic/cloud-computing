using BibliotekaEkspozitura.Domain;
using Microsoft.EntityFrameworkCore;

namespace BibliotekaEkspozitora.Domain
{
    public class EkspozituraDbContext : DbContext
    {
        public DbSet<RentBook> RentBooks { get; set; }

        public EkspozituraDbContext(DbContextOptions<EkspozituraDbContext> options) : base(options) { }
        protected EkspozituraDbContext() { }
    }
}
