using System;
using Users.User.Domain;
using Users.User.Infrastructure;

namespace UsersTest.Domain
{
    public class UserIdMother
    {
        public static UserId Random()
        {
            return new UserId(GuidCreator.Execute());
        }

        public static UserId Random(Guid userId)
        {
            return new UserId(userId);
        }
    }

}
