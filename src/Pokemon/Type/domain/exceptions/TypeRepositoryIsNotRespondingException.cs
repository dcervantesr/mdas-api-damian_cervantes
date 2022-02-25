using System;
namespace Pokemon.Type.Domain
{
    public class TypeRepositoryIsNotRespondingException : Exception
    {
        public TypeRepositoryIsNotRespondingException()
            : base("Api Not Response")
        { }
    }
}
