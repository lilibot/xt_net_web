using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using static System.Net.Mime.MediaTypeNames;

namespace DAL.Interfaces
{
    public interface IAwardDao
    {
        Award Add(Award award);
        Award GetById(int id);
        IEnumerable<Award> GetAll();
        bool RemoveById(int id);
        bool Update(int id, Award award);
        bool IsAwarded(int id);
    }
}
