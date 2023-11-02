using ECommerce.Web.Models;
using ECommerce.Web.Service.IService;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ECommerce.Web.Service
{
    public class BaseService : IBaseService
    {
        private IHttpClientFactory _httpClientFactory;
        public BaseService(IHttpClientFactory httpClientFactory)
        {

            _httpClientFactory = httpClientFactory;

        }
        public async Task<ResponseDto?> SendAsync(RequestDto requestDto)
        {
            HttpClient httpClient = _httpClientFactory.CreateClient("ECommerceAPI");
            HttpRequestMessage httpRequestMessage = new();
            httpRequestMessage.Headers.Add("Accept", "application/json");

            httpRequestMessage.RequestUri = new Uri(requestDto.ApiUrl);
            if(requestDto.Data != null)
            {
                httpRequestMessage.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data),System.Text.Encoding.UTF8,"application/json");
            }

            HttpResponseMessage? httpResponseMessage = null;

            switch (requestDto.ApiType)
            {
                case Utility.SD.ApiType.POST:
                    httpRequestMessage.Method = HttpMethod.Post;
                    break;

                case Utility.SD.ApiType.PUT:
                    httpRequestMessage.Method = HttpMethod.Put;
                    break;

                case Utility.SD.ApiType.DELETE:
                    httpRequestMessage.Method = HttpMethod.Delete;
                    break;

                default:
                    httpRequestMessage.Method = HttpMethod.Get;
                    break;

            }

            httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            switch (httpResponseMessage.StatusCode)
            {
                case System.Net.HttpStatusCode.NotFound:
                    return new() { Success = false, Message = "Not Found" };
                case System.Net.HttpStatusCode.Forbidden:
                    return new() { Success = false, Message = "Access Denied" };
                case System.Net.HttpStatusCode.Unauthorized:
                    return new() { Success = false, Message = "Unauthorized" };
                case System.Net.HttpStatusCode.InternalServerError:
                    return new() { Success = false, Message = "Internal Server Error" };
                default:
                    var apiContent = await httpResponseMessage.Content.ReadAsStringAsync();
                    var apiResponse = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
                    return apiResponse;
            }
        }
    }
}
