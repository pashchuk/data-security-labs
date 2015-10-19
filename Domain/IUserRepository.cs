namespace Domain
{
    public interface IUserRepository
    {
        User GetUser(string username);
        bool DeleteUser(User user);
        bool AddUser(User user);
        bool SaveChanges();
    }
}