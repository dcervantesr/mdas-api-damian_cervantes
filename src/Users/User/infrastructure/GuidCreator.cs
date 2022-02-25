namespace Users.User.Infrastructure
{
    public class GuidCreator
    {
        public static Guid Execute()
        {
            return Guid.NewGuid();
        }
    }
}
