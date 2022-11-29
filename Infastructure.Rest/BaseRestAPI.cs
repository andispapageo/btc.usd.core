using Newtonsoft.Json;
using RestSharp;
using System.Text;

namespace Infastructure.Rest
{
    public abstract class BaseRestAPI<T> where T : class
    {
        private string _Url;
        private RestClient _client;
        public abstract bool FetchAllSymbols();
        public abstract IEnumerable<string> Symbols();
        public BaseRestAPI(string url)
        {
            _Url = url;
            if (FetchAllSymbols())
                _client = new RestClient(_Url);
            else
            {
                var urlBuilder = new StringBuilder(_Url);
                urlBuilder.Append("/");
                var resUrl = Symbols().Aggregate(new StringBuilder(_Url), (x, y) =>
                {
                    x.Append(y);
                    return x;
                });

                var options = new RestClientOptions(resUrl.ToString())
                {
                    ThrowOnAnyError = true,
                    MaxTimeout = 1200
                };
                _client = new RestClient(options);
            }
        }

        public async Task<IEnumerable<T>> GetObjectAsync(CancellationToken cancellationToken)
        {
            var request = new RestRequest();
            var handle = await _client.ExecuteAsync(request, cancellationToken);
            var result = JsonConvert.DeserializeObject<T>(handle.Content);
            return new[] { result };
        }

        public async Task<IEnumerable<T>> GetEnumerableAsync(CancellationToken cancellationToken)
        {
            var request = new RestRequest();
            var handle = await _client.ExecuteAsync(request, cancellationToken);
            var result = JsonConvert.DeserializeObject<IEnumerable<T>>(handle.Content);
            return result;
        }
        protected async Task<T> GetModelAsync(CancellationToken cancellationToken)
        {
            var request = new RestRequest();
            return await _client?.GetAsync<T>(request, cancellationToken);
        }
    }
}
