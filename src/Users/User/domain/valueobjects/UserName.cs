namespace Users.User.Domain
{
    public class UserName
    {
        public string Value { get; } 
        
        public UserName(string name)
        {
            Value = name;
        }
    }
}
