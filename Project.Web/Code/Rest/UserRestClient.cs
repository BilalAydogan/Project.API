using Newtonsoft.Json.Linq;
using RestSharp;

namespace Project.Web.Code.Rest
{
    public class UserRestClient : BaseRestClient
    {
        public dynamic Login(string email, string password)
        {
            RestRequest req = new RestRequest($"/Auth/Login", Method.Post);
            req.AddJsonBody(new
            {
                Email = email,
                Password = password
            });

            RestResponse res = client.Post(req);
            string msg = res.Content.ToString();

            dynamic result = JObject.Parse(msg);

            return result;
        }
    }
}
