namespace UserApi.Dto
{
    public class AddPokemonFavoriteDto
    {
        public Guid UserId { get; set; }
        public int PokemonId { get; set; }
    }
}
