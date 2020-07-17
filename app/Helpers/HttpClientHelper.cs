using System.Net.Http;
using System.Threading.Tasks;

namespace vintri.Helpers
{
    public static class   HttpClientHelper {
     public async static Task<HttpResponseMessage> GetAsync(string  url){
         HttpResponseMessage responseMessage;
         using(HttpClient client = new HttpClient()){
            responseMessage = await client.GetAsync(url);
         }
         return responseMessage;
     }
    }
}