namespace Users.User.Domain
{
    public class UserDoesNotExist : Exception
    {
        public UserDoesNotExist() 
            : base("User does not exists")
        {
        }
    }
}
