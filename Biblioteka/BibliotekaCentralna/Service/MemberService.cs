using AutoMapper;
using BibliotekaCentralna.Domain;
using BibliotekaCentralna.Dto;
using BibliotekaCentralna.Model;
using BibliotekaCentralna.Repository;
using System.Net;

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
            Member? newMember = await _memberRepository.GetByJMBG(registerMember.JMBG);
            if (newMember != null)
                throw new DomainException("The member already exists with same JMBG.",HttpStatusCode.BadRequest);
            else
                await _memberRepository.CreateMember(member);
            return _mapper.Map<MemberDto>(member);
        }

        public async Task<RentBookDto?> RentBook(RentBookDto rentBook)
        {
            await CheckUser(rentBook.MemberId);
            int count = await _memberRepository.GetRentCount(rentBook.MemberId);
            if (count < 3)
            {
                await _memberRepository.CreateRent(rentBook.MemberId);
                return rentBook;
            }
            else
                throw new DomainException("The member already exists with same JMBG.", HttpStatusCode.BadRequest);
        }

        public async Task<RentBookDto?> ReturnBook(RentBookDto rentBook)
        {
                await CheckUser(rentBook.MemberId);
                await _memberRepository.DeleteRent(rentBook.MemberId);
                return rentBook;
        }

        private async Task<Member?> CheckUser(int memberId)
        {
            Member? member = await _memberRepository.GetById(memberId);
            if (member == null)
                throw new DomainException("The member does not exists", HttpStatusCode.NotFound);
            return member;
        }
    }
}
