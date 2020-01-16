using DAL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DAL
{
    public class FileAwardDao : IAwardDao
    {
        private readonly string _fileAwards = @".\awards.txt";
        public FileAwardDao()
        {
            if (!File.Exists(_fileAwards))
            {
                File.Create(_fileAwards);
            }
        }
        public Award Add(Award award)
        {
            award.Id = GetMaxId() + 1;
            File.AppendAllLines(_fileAwards, new[] { $"{award.Id}|{award.Title}" });
            return award;
        }

        public IEnumerable<Award> GetAll()
        {
            if (!File.Exists(_fileAwards) || File.ReadAllLines(_fileAwards).Length == 0)
            {
                throw new InvalidOperationException("Awards not found");
            }
            try
            {
                return File.ReadAllLines(_fileAwards)
                    .Select(str => str.Split('|'))
                    .Select(arr => new Award
                    {
                        Id = int.Parse(arr[0]),
                        Title = arr[1]
                    });
            }
            catch
            {
                throw new InvalidOperationException("Award creation is failed");
            }
        }

        public Award GetById(int id)
        {
            return GetAll().FirstOrDefault(user => user.Id == id);
        }

        public bool RemoveById(int id)
        {
            var lines = File.ReadAllLines(_fileAwards).ToList();
            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].Split('|')[0] == id.ToString())
                {
                    lines.RemoveAt(i);
                    break;
                }
            }

            File.WriteAllLines(_fileAwards, lines.ToArray(), Encoding.Default);
            return true;
        }
        public int GetMaxId()
        {
            if (!File.Exists(_fileAwards) || File.ReadAllLines(_fileAwards).Length == 0)
            {
                return 0;
            }
            string maxId = File.ReadAllLines(_fileAwards).Select(str => str.Split('|')[0]).Max();
            return int.Parse(maxId);
        }
    }
}
