namespace BlazorASG.Nswag
{
    public class ClientFactory
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ClientFactory(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory), "HttpClientFactory cannot be null.");
        }

        public async Task<TClient> CreateClientAsync<TClient>(string baseUrl, string clientName) where TClient : class
        {
            
            if (string.IsNullOrWhiteSpace(baseUrl))
            {
                throw new ArgumentException("Base URL cannot be null, empty or whitespace.", nameof(baseUrl));
            }

          
            if (string.IsNullOrWhiteSpace(clientName))
            {
                throw new ArgumentException("Client name cannot be null, empty or whitespace.", nameof(clientName));
            }

            try
            {
                
                var httpClient = _httpClientFactory.CreateClient(clientName);

               
                if (Activator.CreateInstance(typeof(TClient), baseUrl, httpClient) is TClient client)
                {
                    return client;
                }
                else
                {
                    throw new InvalidOperationException($"Could not create an instance of {typeof(TClient).Name}. Make sure the constructor is correct.");
                }
            }
            catch (ArgumentException ex)
            {
               
                throw new InvalidOperationException("Invalid argument provided to create the client.", ex);
            }
            catch (Exception ex)
            {
               
                throw new InvalidOperationException($"An error occurred while creating the client: {ex.Message}", ex);
            }
        }
    }
}