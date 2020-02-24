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
    public class AwardLogic : IAwardLogic
    {
        private IAwardDao _awardDao;

        public AwardLogic(IAwardDao awardDao)
        {
            _awardDao = awardDao;
        }
        public Award Add(Award award)
        {
            return _awardDao.Add(award);
        }

        public IEnumerable<Award> GetAll()
        {
            return _awardDao.GetAll();
        }


        public Award GetById(int id)
        {
            return _awardDao.GetById(id);
        }

        public bool IsAwarded(int id)
        {
            return _awardDao.IsAwarded(id);
        }

        public bool RemoveById(int id)
        {
            return _awardDao.RemoveById(id);
        }
        public bool Update(int id, Award award)
        {
            return _awardDao.Update(id, award);
        }
    }
}
