using Pokemon.Type.Domain;
using System.Collections.Generic;

namespace Pokemon.Type.Infrastructure
{
    internal static class HttpAdapter
    {
        private static Domain.Type PokeApiTypeDtoToType(PokeApiTypeDto pokeApiTypeDto)
        {
            return Domain.Type.Create(new TypeName(pokeApiTypeDto.Name));
        }

        public static Types PokeApiTypeDtoListToTypesList(List<PokeApiTypeDto> pokeApiTypeDtos)
        {
            Types types = new Types();
            pokeApiTypeDtos.ForEach(pokeApiTypeDto => types.Add(PokeApiTypeDtoToType(pokeApiTypeDto)));
            return types;
        }

        public static List<PokeApiTypeDto> PokeApiTypesDtoListToPokeApiTypeDtoList(List<PokeApiTypesDto> pokeApiTypeWrapDtos)
        {
            List<PokeApiTypeDto> types = new List<PokeApiTypeDto>();
            pokeApiTypeWrapDtos.ForEach(pokeApiTypeWrapDto => types.Add(PokeApiTypesDtoToPokeApiTypeDto(pokeApiTypeWrapDto)));
            return types;
        }

        private static PokeApiTypeDto PokeApiTypesDtoToPokeApiTypeDto(PokeApiTypesDto pokeApiTypesDto)
        {
            return new PokeApiTypeDto
            {
                Name = pokeApiTypesDto.Type.Name,
                Url = pokeApiTypesDto.Type.Url
            };
        }
    }
}
