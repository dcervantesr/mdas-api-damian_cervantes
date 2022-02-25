using System.Collections.Generic;
using Pokemon.Type.Domain;

namespace Pokemon.Type.Application
{
    public class GetTypesByPokemonNameUseCase
    {
        private readonly FindByPokemonName _findByPokemonName;

        public GetTypesByPokemonNameUseCase(FindByPokemonName findByPokemonName)
        {
            _findByPokemonName = findByPokemonName;
        }

        public List<Domain.Type> Execute(GetTypesByPokemonNameQuery getTypesByPokemonNameQuery)
        {
            return _findByPokemonName.Execute(getTypesByPokemonNameQuery.Name());
        }
    }
}
