using DAL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MemoryAwardDao : IAwardDao
    {
        private readonly IDictionary<int, Award> _awards;
        public MemoryAwardDao()
        {
            _awards = new Dictionary<int, Award>();
        }
        public Award Add(Award award)
        {
            var lastId = _awards.Keys.Count > 0 ? _awards.Keys.Max() : 0;

            award.Id = lastId + 1;

            _awards.Add(award.Id, award);

            return award;
        }


        public IEnumerable<Award> GetAll()
        {
            return _awards.Values;
        }

        public Award GetById(int id)
        {
            _awards.TryGetValue(id, out var award);
            return award;
        }

        public bool RemoveById(int id)
        {
            return _awards.Remove(id);
        }

    }
}
