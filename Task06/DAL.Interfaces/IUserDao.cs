using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserDao
    {
        User Add(User user);
        User GetById(int id);
        IEnumerable<User> GetAll();
        bool RemoveById(int id);

        bool AddAward(int userId, int awardId);

        bool RemoveUsersAward(int userId, int awardId);
    }
}
