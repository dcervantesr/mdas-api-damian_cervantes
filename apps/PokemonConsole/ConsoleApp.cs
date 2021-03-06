using Pokemon.Type.Application;
using Pokemon.Type.Domain;
using System;
using System.Threading.Tasks;

namespace PokemonConsole
{
    public class ConsoleApp
    {
        private readonly GetTypesByPokemonNameUseCase _getTypesByPokemonNameUseCase;
        public ConsoleApp(GetTypesByPokemonNameUseCase getTypesByPokemonNameUseCasey)
        {
            _getTypesByPokemonNameUseCase = getTypesByPokemonNameUseCasey;
        }
        public async Task RunAsync()
        {
            try
            {
                string pokemonName = string.Empty;
                do
                {
                    Console.WriteLine("Enter the name of the pokemon");
                    pokemonName = Console.ReadLine();
                    if (pokemonName == string.Empty)
                    {
                        Console.WriteLine("Name is required");
                    }
                } while (pokemonName == string.Empty);
                Types result = _getTypesByPokemonNameUseCase.Execute(pokemonName);
                string resultString = "";
                foreach (var type in result)
                {
                    resultString += type.Name.Value + (type.Name.Value == result[result.Count - 1].Name.Value ? "" : ", ");
                }
                Console.WriteLine(resultString);
                return;
            }
            catch (Exception e)
            {
                if (e is PokemonNotFound || (e.InnerException != null && e.InnerException is PokemonNotFound))
                {
                    Console.WriteLine(e.InnerException is null ? e.Message : e.InnerException.Message);
                    return;
                }
                if (e is TypeRepositoryIsNotResponding || (e.InnerException != null && e.InnerException is TypeRepositoryIsNotResponding))
                {
                    Console.WriteLine(e.InnerException is null ? e.Message : e.InnerException.Message);
                    return;
                }
                Console.WriteLine("Oops, something has gone wrong. Try again later.");
            }
            await Task.Delay(0);
        }
    }
}
