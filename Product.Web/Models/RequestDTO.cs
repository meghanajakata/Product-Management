using static Product.Web.Utility.StaticDetails;

namespace Product.Web.Models
{
    public class RequestDTO
    {
        public ApiTypes ApiType { get; set; } = ApiTypes.GET;
        public string Url { get; set; }
        public object Data { get; set; } 
        public string AccessToken { get; set; }
    }
}
