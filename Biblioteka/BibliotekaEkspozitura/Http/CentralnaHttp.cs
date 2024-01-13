using BibliotekaEkspozitura.Dto;
using BibliotekaEkspozitura.Utils;
using System.Diagnostics;

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
            _httpClient.BaseAddress = new Uri("https://biblioteka_cn:8081");
        }

        public async Task<MemberDto> RegisterMember(RegisterMemberDto registerMember)
        {
            HttpResponseMessage response = null;
            try
            {
                response = await _httpClient.PostAsync($"/api/v1/register", HttpUtils.HttpClientRequest(registerMember));
            }
            catch(Exception ex)
            {
                Console.WriteLine("ex", ex);
                Console.WriteLine("ex", ex.Message);
                Console.WriteLine("ex inner", ex.InnerException?.Message);
                var x = ex;
            }
            Console.WriteLine("writeline upao123 response");
            return await HttpUtils.HttpClientResponse<MemberDto>(response);
        }
    }
}
