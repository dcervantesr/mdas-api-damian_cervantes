namespace Pokemon.Type.Domain
{
    public class Type
    {
        private TypeName _name;

        private Type(TypeName name)
        {
            _name = name;
        }

        public static Type Create(TypeName name) {
            return new Type(name);
        }

        public TypeName Name => _name;
    }
}
