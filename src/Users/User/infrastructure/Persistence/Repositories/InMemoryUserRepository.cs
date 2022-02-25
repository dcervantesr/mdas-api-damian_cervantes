using Users.User.Domain;

namespace Users.User.Infrastructure;

public class InMemoryUserRepository : IUserRepository
{
    private readonly List<Domain.User> _users;

    public InMemoryUserRepository(UserContext context)
    {
        _users = context.Set<Domain.User>();
    }

    public void Save(Domain.User user)
    {
        Upsert(user);
    }

    public Domain.User Find(UserId userId)
    {
        Domain.User user = FindById(userId.Value);

        if (user == null)
        {
            throw new UserDoesNotExistException();
        }

        return user;
    }

    public bool Exists(UserId userId)
    {
        return _users.Where(u => u.Id.Value == userId.Value).Any();
    }

    #region Metodos privados

    private void Insert(Domain.User user)
    {
        _users.Add(user);
    }

    private void Delete(Domain.User user)
    {
        int index = FindIndex(user.Id);
        Domain.User userToDeleted = _users[index];
        _users.Remove(userToDeleted);
    }

    private void Update(Domain.User user)
    {
        int index = FindIndex(user.Id);
        _users[index] = user;
    }

    private Domain.User FindById(Guid userId)
    {
        return _users.FirstOrDefault(u => u.Id.Value == userId)!;
    }

    private int FindIndex(UserId userId)
    {
        int index = _users.FindIndex(u => u.Id.Value == userId.Value);
        return index;
    }
    private void Upsert(Domain.User user)
    {
        int index = FindIndex(user.Id);

        if (index == -1)
        {
            Insert(user);
        }
        else
        {
            Update(user);
        }
    }

    #endregion
}