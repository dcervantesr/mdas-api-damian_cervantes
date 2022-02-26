using System;
namespace Pokemon.Type.Domain
{
    public class TypeRepositoryIsNotResponding : Exception
    {
        public TypeRepositoryIsNotResponding()
            : base("Api Not Response")
        { }
    }
}
