using AutoMapper;
using BibliotekaEkspozitura.Domain;
using BibliotekaEkspozitura.Dto;
using BibliotekaEkspozitura.Http;
using BibliotekaEkspozitura.Repository;

namespace BibliotekaEkspozitura.Service
{
    public class MemberService : IMemberService
    {
        private readonly CentralnaHttp _centralnaHttp;
        private readonly IMemberRepository _memberRepository;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMapper _mapper;
        public MemberService(CentralnaHttp centralnaHttp, IMemberRepository memberRepository, IHttpClientFactory httpClientFactory, IMapper mapper)
        {
            _centralnaHttp = centralnaHttp;
            _memberRepository = memberRepository;
            _httpClientFactory = httpClientFactory;
            _mapper = mapper;
        }

        public async Task<MemberDto?> RegisterMember(RegisterMemberDto registerMember)
        {
            return await _centralnaHttp.RegisterMember(registerMember);
        }

        public async Task<RentBookDto?> RentBook(RentDto rent)
        {
            RentBookDto? rentBookDto = await _centralnaHttp.RentBook(rent);
            RentBook rentBook = _mapper.Map<RentBook>(rent);
            await _memberRepository.CreateRent(rentBook);
            return rentBookDto;
        }

        public async Task<RentBookDto?> ReturnBook(RentDto rent)
        {
            RentBookDto? rentBookDto = await _centralnaHttp.ReturnBook(rent);
            RentBook rentBook = _mapper.Map<RentBook>(rent);
            await _memberRepository.DeleteRent(rentBook);
            return rentBookDto;
        }
    }
}
