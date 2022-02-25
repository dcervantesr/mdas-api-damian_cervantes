namespace Users.User.Domain
{
    public class UserDoesNotExistException : Exception
    {
        public UserDoesNotExistException() 
            : base("User does not exists")
        {
        }
    }
}
