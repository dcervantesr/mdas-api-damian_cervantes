namespace Users.User.Domain
{
    public class UserAlreadyExists : Exception
    {
        public UserAlreadyExists() 
            : base("User already exists")
        {
        }
    }
}