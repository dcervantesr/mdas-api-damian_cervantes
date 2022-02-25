using Pokemon.Type.Domain;
using System.Collections.Generic;

namespace Pokemon.Type.Infrastructure
{
    internal static class HttpAdapter
    {
        private static Domain.Type PokeApiTypeDtoToType(PokeApiTypeDto pokeApiTypeDto)
        {
            Domain.Type type = Domain.Type.Create(new TypeName(pokeApiTypeDto.Name));
            return type;
        }

        public static List<Domain.Type> PokeApiTypeDtoListToTypesList(List<PokeApiTypeDto> pokeApiTypeDtos)
        {
            List<Domain.Type> types = new List<Domain.Type>();
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
            PokeApiTypeDto pokeApiTypeDto = new PokeApiTypeDto
            {
                Name = pokeApiTypesDto.Type.Name,
                Url = pokeApiTypesDto.Type.Url
            };
            return pokeApiTypeDto;
        }
    }
}
