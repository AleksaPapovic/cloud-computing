using AutoMapper;
using BibliotekaCentralna.Dto;
using BibliotekaCentralna.Model;
using BibliotekaCentralna.Repository;

namespace BibliotekaCentralna.Service
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;

        public MemberService(IMemberRepository memberRepository, IMapper mapper)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
        }

        public async Task<MemberDto?> RegisterMember(RegisterMemberDto registerMember)
        {
            Member member = _mapper.Map<Member>(registerMember);
            Member newMember = await _memberRepository.GetByJMBG(registerMember.JMBG);

            return _mapper.Map<MemberDto>(member);
        }

        public async Task<RentDto?> RentBook(RentBookDto rentBook)
        {
            throw new NotImplementedException();
        }
    }
}
