namespace lab1.Models
{
    public interface IUserRepository
    {
        User GetUser(string username);
        bool DeleteUser(User user);
        bool AddUser(User user);
        bool SaveChanges();
    }
}