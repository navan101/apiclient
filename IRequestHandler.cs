using Newtonsoft.Json.Linq;
using static RESTfulAPIConsume.RequestHandlers.methods;

namespace RESTfulAPIConsume.RequestHandlers
{
    public interface IRequestHandler
    {
        string CallAPI(string url, string id, string invoicestatus, string signstatus);
       
    }
   
}
