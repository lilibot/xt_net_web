using DAL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FileUserDao : IUserDao
    {
        public User Add(User user)
        {
            throw new NotImplementedException();
        }

        public bool AddAward(int userId, int awardId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveById(int id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveUsersAward(int userId, int awardId)
        {
            throw new NotImplementedException();
        }
    }
}
