namespace Users.User.Domain
{
    public interface IUserRepository
    {
        void Save(User user);
        User Find(UserId userId);
        bool Exists(UserId userId);
    }
}
