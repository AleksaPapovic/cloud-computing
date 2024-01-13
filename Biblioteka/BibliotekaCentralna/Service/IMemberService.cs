
using BibliotekaCentralna.Dto;

namespace BibliotekaCentralna.Service
{
    public interface IMemberService
    {
        Task<RentDto?> RentBook(RentBookDto rentBook);
        Task<MemberDto?> RegisterMember(RegisterMemberDto registerMember);
    }
}
