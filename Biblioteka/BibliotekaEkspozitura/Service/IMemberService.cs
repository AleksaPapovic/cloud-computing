using BibliotekaEkspozitura.Dto;

namespace BibliotekaEkspozitura.Service
{
    public interface IMemberService
    {
        Task<MemberDto?> RegisterMember(RegisterMemberDto registerMember);
        Task<RentDto?> RentBook(RentBookDto rentBook);
        Task<RentDto?> ReturnBook(ReturnBookDto returnBook);
    }
}
