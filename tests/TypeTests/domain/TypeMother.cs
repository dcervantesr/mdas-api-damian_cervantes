using Moq;
using Pokemon.Type.Domain;

namespace TypeTest.Domain
{

    public class TypeMother 
    {
        public static Type Random()
        {
            return Type.Create(It.IsAny<TypeName>()); 
        }

        public static Type Random(TypeName typeName)
        {
            return Type.Create(typeName);
        }
    }
}
