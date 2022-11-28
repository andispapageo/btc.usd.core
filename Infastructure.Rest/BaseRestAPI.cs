using RestSharp;

namespace Infastructure.Rest
{
    public abstract class BaseRestAPI<T> where T : class
    {
        private string _Url;
        private RestClient _client;

        public BaseRestAPI(string url)
        {
            _Url = url;
            _client = new RestClient(_Url);
        }

        protected async Task<IEnumerable<T>> GetCollectionAsync(CancellationToken cancellationToken)
        {
            var request = new RestRequest();
            return await _client?.GetAsync<IEnumerable<T>>(request, cancellationToken);
        }

        protected async Task<T> GetModelAsync(CancellationToken cancellationToken)
        {
            var request = new RestRequest();
            return await _client?.GetAsync<T>(request, cancellationToken);
        }
    }
}
