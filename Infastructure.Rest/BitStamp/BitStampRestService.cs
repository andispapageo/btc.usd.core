using Infastructure.Rest.Interface;

namespace Infastructure.Rest.BitStamp
{
    internal class BitStampRestService<T> :  BaseRestAPI<T> where T : class, IRestService
    {
        public BitStampRestService(string url) : base(url) { }
    }
}
