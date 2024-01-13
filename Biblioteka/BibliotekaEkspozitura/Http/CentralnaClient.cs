namespace BibliotekaEkspozitura.Http
{
    public static class CentralnaClient
    {
        public static void AddCentralnaHttpClient(this IServiceCollection services, Action<HttpClient> options)
        {
            services.AddHttpClient<CentralnaHttp>(options);
        }
    }
}
