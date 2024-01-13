using BibliotekaCentralna.Dto;
using BibliotekaCentralna.Model;
using BibliotekaCentralna.Repository;

namespace BibliotekaCentralna.Service
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;

        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<MemberDto?> RegisterMember(RegisterMemberDto registerMember)
        {
            Member member = await _memberRepository.GetByJMBG(registerMember.JMBG);

            return null;
        }

        public async Task<RentDto?> RentBook(RentBookDto rentBook)
        {
            throw new NotImplementedException();
        }
    }
}
