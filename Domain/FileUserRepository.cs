using System;
using System.IO;
using Newtonsoft.Json;

namespace Domain
{
    public class FileUserRepository : IUserRepository
    {
        private string _contentFilePath;

        public FileUserRepository(string filePath)
        {
            if (filePath == null)
                throw new ArgumentNullException(nameof(filePath));
            _contentFilePath = filePath;
        }
        public User GetUser(string username)
        {
            var data = JsonConvert.DeserializeObject<JsonData>(
                File.ReadAllText(_contentFilePath));
            return data.Users.Find(x => string.Equals(x.UserName, username));
        }

        public bool DeleteUser(User user)
        {
            var data = JsonConvert.DeserializeObject<JsonData>(
                File.ReadAllText(_contentFilePath));
            data.Users.Remove(user);
            File.WriteAllText(_contentFilePath, JsonConvert.SerializeObject(data));
            return true;
        }

        public bool AddUser(User user)
        {
            var data = JsonConvert.DeserializeObject<JsonData>(
                File.ReadAllText(_contentFilePath));
            data.Users.Add(user);
            File.WriteAllText(_contentFilePath, JsonConvert.SerializeObject(data));
            return true;
        }

        public bool SaveChanges()
        {
            return true;
        }
    }
}