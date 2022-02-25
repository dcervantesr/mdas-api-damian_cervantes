using System.Net.Http;
using System.Net.Http.Headers;
using Xunit;

namespace TypeTests.Infrastructure
{
    public class TypeGetTest
    {

        [Fact, Trait("Type", "Acceptance")]
        public void Should_Get_Type_Pokemon()
        {
            //Given
            HttpClient httpClient = new HttpClient();
            string url = "http://pokemon:80/api/v1/type/charizard";
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);

            //When
            var response = httpClient.SendAsync(request).GetAwaiter().GetResult();

            //Then
            Assert.True(response.IsSuccessStatusCode);
        }
    }
}

