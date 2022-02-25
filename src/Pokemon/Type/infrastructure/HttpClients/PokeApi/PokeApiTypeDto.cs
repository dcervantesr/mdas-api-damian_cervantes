namespace Pokemon.Type.Infrastructure
{
    public class PokeApiTypeDto
    {
        public PokeApiTypeDto()
        {

        }
        public PokeApiTypeDto(string name, string url) : this()
        {
            Name = name;
            Url = url;
        }
        public string Name { get; set; }
        public string Url { get; set; }
    }

}
