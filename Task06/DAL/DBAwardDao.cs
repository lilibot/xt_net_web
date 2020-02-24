using DAL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBAwardDao : IAwardDao
    {
        private string _connectionString = "Data Source=DESKTOP-DC73STR\\SQLEXPRESS;Initial Catalog=UsersAndAwards;Integrated Security=True";
        public Award Add(Award award)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.AddAward";
                command.Parameters.AddWithValue("@title", award.Title);
                command.Parameters.AddWithValue("@image", award.Image == null ? (object)DBNull.Value : Convert.ToBase64String(award.Image));
                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@id",
                    Value = award.Id,
                    Direction = ParameterDirection.Output,
                };
                command.Parameters.Add(idParameter);
                connection.Open();
                command.ExecuteNonQuery();
                award.Id = (int)idParameter.Value;
                return award;
            }
        }

        public IEnumerable<Award> GetAll()
        {
            var awards = new List<Award>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "select [id],[title],[image] from [UsersAndAwards].[dbo].[Award]";
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    awards.Add(new Award
                    {
                        Id = (int)reader["id"],
                        Title = reader["title"] as string,
                        Image = reader["image"]== DBNull.Value?null:Convert.FromBase64String((string)reader["image"])
                    });
                }

            }
            return awards;
        }

        public Award GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAwardById";
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return new Award
                    {
                        Id = (int)reader["id"],
                        Title = reader["title"] as string,
                        Image = reader["image"] == DBNull.Value ? null : Convert.FromBase64String((string)reader["image"])
                    };
                }
                return null;

            }
        }

        public bool RemoveById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.RemoveAwardById";
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                int result = command.ExecuteNonQuery();
                return result == 0;
            }
        }
        public bool Update(int id, Award award)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "UpdateAward";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@title", award.Title);
                command.Parameters.AddWithValue("@image", award.Image == null ? (object)DBNull.Value : Convert.ToBase64String(award.Image));

                connection.Open();

                int result = command.ExecuteNonQuery();
                return result == 0;
            }
        }
        public bool IsAwarded(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "select count([id_Award]) as countId from [UsersAndAwards].[dbo].[Users_Awards] where id_Award=@idAward";
                command.Parameters.AddWithValue("@idAward", id);
                connection.Open();
                var reader = command.ExecuteReader();
                int countId = 0;
                while (reader.Read())
                {
                    countId = (int)reader["countId"];
                }
                return countId > 0;
            }
        }
    }
}
