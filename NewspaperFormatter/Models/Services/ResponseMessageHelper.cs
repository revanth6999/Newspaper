using System.Net;
using System.Net.Http;
using System.Text.Json;

namespace NewspaperFormatter.Models.Services
{
    public static class ResponseMessageHelper
    {
        public static HttpResponseMessage CreateResponse<T>(this HttpRequestMessage requestMessage, HttpStatusCode statusCode, T content)
        {
            StringContent con = new StringContent(JsonSerializer.Serialize(content));
            return new HttpResponseMessage()
            {
                StatusCode = statusCode,
                Content = con
            };
        }
    }
}
