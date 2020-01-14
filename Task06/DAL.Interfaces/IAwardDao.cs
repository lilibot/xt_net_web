using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL.Interfaces
{
    public interface IAwardDao
    {
        Award Add(Award award);
        Award GetById(int id);
        IEnumerable<Award> GetAll();
        bool RemoveById(int id);

    }
}
