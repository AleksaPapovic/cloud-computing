using BibliotekaEkspozitura.Dto;
using BibliotekaEkspozitura.Utils;

namespace BibliotekaEkspozitura.Http
{
    public class CentralnaHttp
    {
        private readonly HttpClient _httpClient;

        public CentralnaHttp(HttpClient httpClient)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            _httpClient = new HttpClient(clientHandler);
            _httpClient.BaseAddress = httpClient.BaseAddress;
        }

        public async Task<MemberDto> RegisterMember(RegisterMemberDto registerMember)
        {
            var response = await _httpClient.PostAsync($"register", HttpUtils.HttpClientRequest(registerMember));
            return await HttpUtils.HttpClientResponse<MemberDto>(response);
        }
    }
}
