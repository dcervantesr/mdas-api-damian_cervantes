using System.Collections.Generic;

namespace Pokemon.Type.Infrastructure
{
    public class PokeApiPokemonDto
    {
        public PokeApiPokemonDto()
        {
            Types = new List<PokeApiTypesDto>();
        }
        public PokeApiPokemonDto(int id, string name, string url) : this()
        {
            Id = id;
            Name = name;
            Url = url;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public List<PokeApiTypesDto> Types { get; set; }
    }
}
