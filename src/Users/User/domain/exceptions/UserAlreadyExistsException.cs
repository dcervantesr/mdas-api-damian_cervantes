namespace Users.User.Domain
{
    public class UserAlreadyExistsException : Exception
    {
        public UserAlreadyExistsException() 
            : base("User already exists")
        {
        }
    }
}