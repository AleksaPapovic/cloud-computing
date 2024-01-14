using BibliotekaEkspozitora.Domain;
using BibliotekaEkspozitura.Domain;
using Microsoft.EntityFrameworkCore;

namespace BibliotekaEkspozitura.Repository
{
    public class MemberRepository : IMemberRepository
    {
        private readonly EkspozituraDbContext _ekspozituraDb;
        public MemberRepository(EkspozituraDbContext ekspozituraDb)
        {
            _ekspozituraDb = ekspozituraDb;
        }

        public async Task<RentBook> CreateRent(RentBook rentBook)
        {
            rentBook.RentDate = DateTime.Now;
            await _ekspozituraDb.RentBooks.AddAsync(rentBook);
            await _ekspozituraDb.SaveChangesAsync();
            return rentBook;
        }

        public async Task<RentBook> DeleteRent(RentBook rentBook)
        {
            RentBook oldRent = await _ekspozituraDb.RentBooks.FirstOrDefaultAsync(rb => rb.Id == rentBook.Id && rb.ISBN.Equals(rentBook.ISBN));
            if (oldRent != null)
            {
                oldRent.ReturnDate = DateTime.Now;
                _ekspozituraDb.RentBooks.Update(oldRent);
                await _ekspozituraDb.SaveChangesAsync();
            }
            return rentBook;
        }
    }
}
