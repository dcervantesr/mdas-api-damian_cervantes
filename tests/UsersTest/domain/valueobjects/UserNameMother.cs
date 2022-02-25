using Users.User.Domain;

namespace UsersTest.Domain
{
    public class UserNameMother 
    {
        public static UserName Random()
        {
            return new UserName(Faker.Name.First());
        }
    }
}
