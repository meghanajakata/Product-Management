using Microsoft.AspNetCore.Http.HttpResults;
using Newtonsoft.Json;
using Product.Web.Models;
using Product.Web.Service.IService;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using static Product.Web.Utility.StaticDetails;

namespace Product.Web.Service
{
    public class BaseService : IBaseService
    {
        private IHttpClientFactory _httpClientFactory;

        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ResponseDTO> SendAsync(RequestDTO requestDTO)
        {
            try
            {
                HttpClient client = _httpClientFactory.CreateClient("ProductAPI");
                HttpRequestMessage message = new();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(requestDTO.Url);
                if (requestDTO.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(requestDTO.Data), Encoding.UTF8, "application/json");
                }
                HttpResponseMessage? apiResponse = null;

                switch (requestDTO.ApiType)
                {
                    case ApiTypes.GET:
                        message.Method = HttpMethod.Get;
                        break;
                    case ApiTypes.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case ApiTypes.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case ApiTypes.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                }

                apiResponse = await client.SendAsync(message);

                switch (apiResponse.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return new() { IsSuccess = false, Message = "Not Found" };
                    case HttpStatusCode.Forbidden:
                        return new() { IsSuccess = false, Message = "Access Denied" };
                    case HttpStatusCode.Unauthorized:
                        return new() { IsSuccess = false, Message = "Unauthorized" };
                    case HttpStatusCode.InternalServerError:
                        return new() { IsSuccess = false, Message = "Internal Server Error" };
                    default:
                        var apiContent = await apiResponse.Content.ReadAsStringAsync();
                        var apiResponseData = JsonConvert.DeserializeObject<ResponseDTO>(apiContent);
                        return apiResponseData;
                }
            }
            catch (Exception ex)
            {
                var dto = new ResponseDTO()
                {
                    Message = ex.Message.ToString(),
                    IsSuccess = false
                };
                return dto;
            }
        }
    }
}
