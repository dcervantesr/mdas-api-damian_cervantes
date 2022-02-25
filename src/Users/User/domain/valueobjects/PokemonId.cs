namespace Users.User.Domain
{
    public readonly struct PokemonId : IEquatable<PokemonId>
    {
        public int Value { get; }

        public PokemonId(int id)
        {
            Value = id;
        }

        public override bool Equals(object? obj) =>
        obj is PokemonId o && this.Equals(o);

        public bool Equals(PokemonId other) => this.Value == other.Value;

        public override int GetHashCode() =>
            HashCode.Combine(this.Value);

        public static bool operator ==(PokemonId left, PokemonId right) => left.Equals(right);

        public static bool operator !=(PokemonId left, PokemonId right) => !(left == right);

        public override string ToString() => this.Value.ToString();
    }
}
