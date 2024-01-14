using BibliotekaEkspozitura.Domain;

namespace BibliotekaEkspozitura.Repository
{
    public interface IMemberRepository
    {
        Task<RentBook> CreateRent(RentBook rentBook);
        Task<RentBook> DeleteRent(RentBook rentBook);
    }
}
