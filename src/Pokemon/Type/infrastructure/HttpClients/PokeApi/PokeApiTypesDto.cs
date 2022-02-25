namespace Pokemon.Type.Infrastructure
{
    public class PokeApiTypesDto
    {
        public PokeApiTypesDto()
        {

        }
        public PokeApiTypesDto(PokeApiTypeDto type) : this()
        {
            Type = type;
        }
        public PokeApiTypeDto Type { get; set; }
    }
}
