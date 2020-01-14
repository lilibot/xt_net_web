using DAL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MemoryUserDao : IUserDao
    {
        private readonly IDictionary<int, User> _users;

        public MemoryUserDao()
        {
            _users = new Dictionary<int, User>();
        }
        public User Add(User user)
        {
            var lastId = _users.Keys.Count > 0 ? _users.Keys.Max() : 0;

            user.Id = lastId + 1;

            _users.Add(user.Id, user);

            return user;
        }

        public bool AddAward(int userId, int awardId)
        {
            if (_users[userId].Awards.Contains(awardId))
            {
                return false;
            }

            _users[userId].Awards.Add(awardId);
            return true;
        }

        public IEnumerable<User> GetAll()
        {
            return _users.Values;
        }

        public User GetById(int id)
        {
            _users.TryGetValue(id, out var user);
            return user;
        }

        public bool RemoveById(int id)
        {
            bool removeResult = _users.Remove(id);

            return removeResult;
        }

        public bool RemoveUsersAward(int userId, int awardId)
        {
            return _users[userId].Awards.Remove(awardId);
        }
    }
}
