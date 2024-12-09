namespace Infrastructure.DataSource.ApiClientFactory
{

    public interface IWebApiClientFactory
    {
        Task<HttpClient> GetClientAsync();

    }






    public class WebApiClientFactory : IWebApiClientFactory
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly BaseUrl baseUrl;

        public WebApiClientFactory(IHttpClientFactory httpClientFactory, BaseUrl baseUrl)
        {
            _httpClientFactory = httpClientFactory;
            this.baseUrl = baseUrl;

            // _token = token;

        }



        public async Task<HttpClient> GetClientAsync()
        {
            var httpClient = _httpClientFactory.CreateClient("LocalApi");

            //httpClient.BaseAddress = new Uri(baseUrl.Api);
            //  string bearerToken = _token.AccessToken;
            //  if (!string.IsNullOrEmpty(bearerToken)) httpClient.SetBearerToken(bearerToken);

            return httpClient;

        }

    }


    

}
