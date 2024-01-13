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

        public MemberService(CentralnaHttp centralnaHttp, IMemberRepository memberRepository, IHttpClientFactory httpClientFactory)
        {
            _centralnaHttp = centralnaHttp;
            _memberRepository = memberRepository;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<MemberDto?> RegisterMember(RegisterMemberDto registerMember)
        {
            MemberDto newMember = await _centralnaHttp.RegisterMember(registerMember);
            return newMember;
        }

        public async Task<RentDto?> RentBook(RentBookDto rentBook)
        {
            throw new NotImplementedException();
        }

        public async Task<RentDto?> ReturnBook(ReturnBookDto returnBook)
        {
            throw new NotImplementedException();
        }
    }
}
