using Pokemon.Type.Domain;

namespace Pokemon.Type.Application
{
    public class GetTypesByPokemonNameQuery
    {
        private string _name;
        
        public GetTypesByPokemonNameQuery(string name)
        {
            _name = name;
        }

        public PokemonName Name()
        {
            return new PokemonName(_name);
        }
    }
}
