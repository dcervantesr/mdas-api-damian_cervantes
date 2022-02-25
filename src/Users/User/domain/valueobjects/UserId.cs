namespace Users.User.Domain
{
    public class UserId: IEquatable<UserId>
    {
        public Guid Value { get; }

        public UserId(Guid id)
        {
            Value = id;
        }

        public override bool Equals(object? obj) =>
            obj is PokemonId o && this.Equals(o);

        public bool Equals(UserId other) => this.Value == other.Value;

        public override int GetHashCode() =>
            HashCode.Combine(this.Value);

        public static bool operator ==(UserId left, UserId right) => left.Equals(right);

        public static bool operator !=(UserId left, UserId right) => !(left == right);

        public override string ToString() => this.Value.ToString();
    }
}
