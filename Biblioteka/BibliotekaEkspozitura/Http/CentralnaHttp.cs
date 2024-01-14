using BibliotekaEkspozitura.Domain;
using BibliotekaEkspozitura.Dto;
using BibliotekaEkspozitura.Utils;
using System.Net;

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
            HttpResponseMessage response = await _httpClient.PostAsync($"/api/v1/register", HttpUtils.HttpClientRequest(registerMember));
            await CheckHttpException(response);
            return await HttpUtils.HttpClientResponse<MemberDto>(response);
        }

        private static async Task CheckHttpException(HttpResponseMessage response)
        {
            if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                throw new Exception(await HttpUtils.HttpClientResponse(response));
            }
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new DomainException(await HttpUtils.HttpClientResponse(response), HttpStatusCode.NotFound);
            }
            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new DomainException(await HttpUtils.HttpClientResponse(response), HttpStatusCode.BadRequest);
            }
        }

        public async Task<RentBookDto> RentBook(RentDto rent)
        {
            RentBookDto rentBook = new() { MemberId = rent.MemberId };
            HttpResponseMessage response = await _httpClient.PostAsync($"/api/v1/rent-book", HttpUtils.HttpClientRequest(rentBook));
            await CheckHttpException(response);
            return await HttpUtils.HttpClientResponse<RentBookDto>(response);
        }

        public async Task<RentBookDto> ReturnBook(RentDto rent)
        {
            RentBookDto rentBook = new() { MemberId = rent.MemberId };
            HttpResponseMessage response = await _httpClient.PostAsync($"/api/v1/return-book", HttpUtils.HttpClientRequest(rentBook));
            await CheckHttpException(response);
            return await HttpUtils.HttpClientResponse<RentBookDto>(response);
        }
    }
}
