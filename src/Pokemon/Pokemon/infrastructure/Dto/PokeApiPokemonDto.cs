
namespace Pokemon.Pokemon.Infrastructure
{
    public class PokeApiPokemonDto
    {
        public PokeApiPokemonDto()
        {

        }

        public PokeApiPokemonDto(int id, string name, int height, int weight) : this()
        {
            Id = id;
            Name = name;
            Height = height;
            Weight = weight;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
    }
}
