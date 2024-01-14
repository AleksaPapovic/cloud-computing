using BibliotekaEkspozitura.Dto;

namespace BibliotekaEkspozitura.Service
{
    public interface IMemberService
    {
        Task<MemberDto?> RegisterMember(RegisterMemberDto registerMember);
        Task<RentBookDto?> RentBook(RentDto rent);
        Task<RentBookDto?> ReturnBook(RentDto rent);
    }
}
