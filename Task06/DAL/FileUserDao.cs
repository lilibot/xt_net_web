using DAL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace DAL
{
    public class FileUserDao : IUserDao
    {
        private readonly string _fileUsers = @".\users.txt";
        private readonly string _fileUsersAwards = @".\usersAwards.txt";
        private const string DateFormat = "dd.MM.yyyy";

        public FileUserDao()
        {
            if (!File.Exists(_fileUsers))
            {
                var stream = File.Create(_fileUsers);
                stream.Close();
            }
            if (!File.Exists(_fileUsersAwards))
            {
                var stream = File.Create(_fileUsersAwards);
                stream.Close();
            }
        }
        public User Add(User user)
        {
            user.Id = GetMaxId() + 1;
            File.AppendAllLines(_fileUsers, new[] { $"{user.Id}|{user.Name}|{user.DateOfBirth:dd.MM.yyyy}" });
            return user;
        }

        public bool AddAward(int userId, int awardId)
        {
            File.AppendAllLines(_fileUsersAwards, new[] { $"{userId}|{awardId}" });
            return true;
        }

        public IEnumerable<User> GetAll()
        {
            try
            {
                var lines = File.ReadAllLines(_fileUsers).Select(str => str.Split('|'));
                IDictionary<int, User> users = new Dictionary<int, User>();
                foreach (var line in lines)
                {
                    users.Add(int.Parse(line[0]), new User
                    {
                        Id = int.Parse(line[0]),
                        Name = line[1],
                        DateOfBirth = DateTime.ParseExact(line[2], DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None)
                    });
                }
                lines = File.ReadAllLines(_fileUsersAwards).Select(str => str.Split('|'));
                foreach (var line in lines)
                {
                    int userId = int.Parse(line[0]);
                    int awardId = int.Parse(line[1]);
                    if (!users[userId].Awards.Contains(awardId))
                    {
                        users[userId].Awards.Add(awardId);
                    }
                }
                return users.Values;

            }
            catch
            {
                throw new InvalidOperationException("User creation is failed");
            }
        }

        public User GetById(int id)
        {
            return GetAll().FirstOrDefault(user => user.Id == id);
        }

        public bool RemoveById(int id)
        {
            var lines = File.ReadAllLines(_fileUsers).ToList();
            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].Split('|')[0] == id.ToString())
                {
                    lines.RemoveAt(i);
                    break;
                }
            }

            File.WriteAllLines(_fileUsers, lines.ToArray(), Encoding.Default);
            return true;
        }

        public bool RemoveUsersAward(int userId, int awardId)
        {
            var lines = File.ReadAllLines(_fileUsersAwards).ToList();
            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].Split('|')[0] == userId.ToString())
                {
                    lines.RemoveAt(i);
                    break;
                }
            }

            File.WriteAllLines(_fileUsersAwards, lines.ToArray(), Encoding.Default);
            return true;
        }
        public int GetMaxId()
        {
            if (!File.Exists(_fileUsers) || File.ReadAllLines(_fileUsers).Length == 0)
            {
                return 0;
            }
            string maxId = File.ReadAllLines(_fileUsers).Select(str => str.Split('|')[0]).Max();
            return int.Parse(maxId);
        }
    }
}
