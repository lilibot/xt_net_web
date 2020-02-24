using BLL.Interfaces;
using DAL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserDao _userDao;
        public UserLogic(IUserDao userDao)
        {
            _userDao = userDao;
        }
        public User Add(User user)
        {
            return _userDao.Add(user);
        }

        public bool AddAward(int userId, int awardId)
        {
            return _userDao.AddAward(userId, awardId);
        }

        public IEnumerable<User> GetAll()
        {
            return _userDao.GetAll();
        }

        public User GetById(int id)
        {
            return _userDao.GetById(id);
        }

        public IEnumerable<int> GetUsersAwardsIds(int userId)
        {
            return _userDao.GetUsersAwardsIds(userId);
        }

        public bool RemoveById(int id)
        {
            return _userDao.RemoveById(id);
        }

        public bool RemoveUsersAward(int userId, int awardId)
        {
            return _userDao.RemoveUsersAward(userId, awardId);
        }

        public bool Update(int id, User user)
        {
            return _userDao.Update(id, user);
        }
    }
}
