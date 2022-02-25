using System;
using System.Net.Http;
using System.Text;
using UsersTest.Domain;
using Xunit;

namespace UsersTest.Infrastructure
{
    public class AddPokemonFavoriteTest
    {

        private static HttpClient client = new HttpClient();

        private CreateUserTest createUserTest = new CreateUserTest();

        [Fact, Trait("Type", "Acceptance")]
        private void Should_Add_Pokemon_Favorite()
        {
            // Given
            HttpClient httpClient = new HttpClient();
            var userTest = createUserTest.Create_New_User();

            string postUrlFavorite = "http://userfavorite:80/api/v1/users/pokemonfavorite";
            HttpRequestMessage requestFavorite = new HttpRequestMessage(HttpMethod.Post, postUrlFavorite);
            var pokemonId = PokemonIdMother.Random();
            requestFavorite.Content = new StringContent("{\"userId\":\"" + userTest.Item2.Value + "\",\"pokemonId\":\"" + pokemonId.Value + "\"}",
                                                        Encoding.UTF8,
                                                        "application/json");

            //When
            var response = httpClient.SendAsync(requestFavorite).GetAwaiter().GetResult();

            //Then
            Assert.True(response.IsSuccessStatusCode);
        }


    }
}

