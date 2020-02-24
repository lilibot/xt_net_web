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
    public class DBUserDao : IUserDao
    {
        private string _connectionString = "Data Source=DESKTOP-DC73STR\\SQLEXPRESS;Initial Catalog=UsersAndAwards;Integrated Security=True";
        public User Add(User user)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.AddUser";
                command.Parameters.AddWithValue("@name", user.Name);
                command.Parameters.AddWithValue("@dateOfBirth", user.DateOfBirth);
                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@id",
                    Value = user.Id,
                    Direction = ParameterDirection.Output,
                };
                command.Parameters.Add(idParameter);
                connection.Open();
                command.ExecuteNonQuery();
                user.Id = (int)idParameter.Value;
                return user;
            }
        }

        public bool AddAward(int userId, int awardId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "AddUsersAwards";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@awardId", awardId);

                connection.Open();

                int result = command.ExecuteNonQuery();
                return result == 0;
            }
        }

        public IEnumerable<User> GetAll()
        {
            var users = new List<User>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "select [id],[name],[dateOfBirth] from [UsersAndAwards].[dbo].[User]";
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(new User
                    {
                        Id = (int)reader["id"],
                        Name = reader["name"] as string,
                        DateOfBirth = (DateTime)reader["dateOfBirth"]
                    });
                }

            }
            return users;
        }

        public User GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetUserById";
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return new User
                    {
                        Id = (int)reader["id"],
                        Name = reader["name"] as string,
                        DateOfBirth = (DateTime)reader["dateOfBirth"]
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
                command.CommandText = "dbo.RemoveUserById";
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                int result = command.ExecuteNonQuery();
                return result == 0;
            }
        }

        public bool RemoveUsersAward(int userId, int awardId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "RemoveUsersAwards";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@awardId", awardId);

                connection.Open();

                int result = command.ExecuteNonQuery();
                return result == 0;
            }
        }

        public bool Update(int id, User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "UpdateUser";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@name", user.Name);
                command.Parameters.AddWithValue("@dateOfBirth", user.DateOfBirth);

                connection.Open();

                int result = command.ExecuteNonQuery();
                return result == 0;
            }
        }
        public IEnumerable<int> GetUsersAwardsIds(int userId)
        {
            var awardsIds = new List<int>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "select [id_Award] from [UsersAndAwards].[dbo].[Users_Awards] where id_User=@idUser";
                command.Parameters.AddWithValue("@idUser", userId);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    awardsIds.Add( (int)reader["id_Award"]);
                }
            }
            return awardsIds;
        }
    }
}
