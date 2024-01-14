
using BibliotekaCentralna.Dto;

namespace BibliotekaCentralna.Service
{
    public interface IMemberService
    {
        Task<MemberDto?> RegisterMember(RegisterMemberDto registerMember);
        Task<RentBookDto?> RentBook(RentBookDto rentBook);
        Task<RentBookDto?> ReturnBook(RentBookDto rentBook);
    }
}
