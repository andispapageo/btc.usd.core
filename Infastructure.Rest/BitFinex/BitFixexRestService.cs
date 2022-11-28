using Infastructure.Rest.Interface;

namespace Infastructure.Rest.BitFinex
{
    public class BitFixexRestService<T> : BaseRestAPI<T> where T : class, IRestService
    {
        public BitFixexRestService(string url) : base(url) { }
    }
}
