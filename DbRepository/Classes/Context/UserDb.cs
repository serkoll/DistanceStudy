using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DbRepository.Classes.Entities;

namespace DbRepository.Classes.Context
{
    public class UserDb
    {
        private readonly string _connectionString;

        /// <summary>
        /// Заполнение _connectionString в конструкторе
        /// </summary>
        public UserDb()
        {
            // строка подключения к базе данных
            _connectionString = ConfigurationManager.ConnectionStrings["DistanceStudyDB"].ConnectionString;
        }

        /// <summary>
        ///     Проверка на валидность введенных данных
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="password">Пароль</param>
        /// <returns>Вернет объект пользователя</returns>
        public User CheckUser(string login, string password)
        {
            using (var connect = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand("[Sign_User]", connect))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Login", SqlDbType.VarChar, 512)).Value = login;
                    cmd.Parameters.Add(new SqlParameter("@Password", SqlDbType.VarChar, 512)).Value = password;
                    connect.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.SingleRow))
                    {
                        return reader.Read() ? ToUser(reader) : null;
                    }
                }
            }
        }

        /// <summary>
        ///     добавить нового пользователя
        /// </summary>
        /// <param name="item">новый пользователь</param>
        /// <returns>если добавлен, то true</returns>
        public bool AddUser(User item)
        {
            try
            {
                using (var connect = new SqlConnection(_connectionString))
                {
                    using (var cmd = new SqlCommand("[User_Add]", connect))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar, 512)).Value = item.Name;
                        cmd.Parameters.Add(new SqlParameter("@Surname", SqlDbType.VarChar, 512)).Value = item.Surname;
                        cmd.Parameters.Add(new SqlParameter("@Login", SqlDbType.VarChar, 512)).Value = item.Login;
                        cmd.Parameters.Add(new SqlParameter("@Password", SqlDbType.VarChar, 512)).Value = item.Password;
                        cmd.Parameters.Add(new SqlParameter("@Description", SqlDbType.VarChar, 512)).Value =
                            item.Description;
                        cmd.Parameters.Add(new SqlParameter("@GroupPermission", SqlDbType.VarChar, 512)).Value =
                            item.GroupPermission;
                        cmd.Parameters.Add(new SqlParameter("@GroupIn", SqlDbType.VarChar, 512)).Value = item.GroupIn;
                        cmd.Parameters.Add(new SqlParameter("@return_value", SqlDbType.Int)).Direction =
                            ParameterDirection.ReturnValue;
                        connect.Open();
                        var result = cmd.ExecuteNonQuery();
                        var value = cmd.Parameters["@return_value"].Value;
                        if (value != null)
                            item.Id = (int)value;
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("UserAdd method failed.", ex);
            }
        }

        /// <summary>
        ///  Обновление пользователя
        /// </summary>
        /// <param name="item">текущий пользователь</param>
        /// <returns>если успешно, то true</returns>
        public bool UpdateUser(User item)
        {
            try
            {
                using (var connect = new SqlConnection(_connectionString))
                {
                    using (var cmd = new SqlCommand("[User_Update]", connect))
                    {
                        cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar, 512)).Value = item.Name;
                        cmd.Parameters.Add(new SqlParameter("@Surname", SqlDbType.VarChar, 512)).Value = item.Surname;
                        cmd.Parameters.Add(new SqlParameter("@Login", SqlDbType.VarChar, 512)).Value = item.Login;
                        cmd.Parameters.Add(new SqlParameter("@Description", SqlDbType.Text)).Value = item.Description;
                        cmd.Parameters.Add(new SqlParameter("@return_value", SqlDbType.Int)).Direction =
                            ParameterDirection.ReturnValue;
                        connect.Open();
                        var result = cmd.ExecuteNonQuery();
                        var value = cmd.Parameters["@return_value"].Value;
                        if (value != null)
                            item.Id = (int)value;
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("UpdateUser method failed.", ex);
            }
        }

        /// <summary>
        /// Удаление заданного пользователя
        /// </summary>
        /// <param name="userId">код пользователя для удаления</param>
        /// <returns></returns>
        public bool DeleteUser(int userId)
        {
            try
            {
                using (var connect = new SqlConnection(_connectionString))
                {
                    using (var cmd = new SqlCommand("[User_DeleteUser]", connect))
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("DeleteUser method failed.", ex);
            }
        }

        /// <summary>
        /// Возвращает полную информацию о пользователе
        /// </summary>
        /// <param name="userId">код пользователя в БД</param>
        /// <returns></returns>
        public User GetUser(int userId)
        {
            return null;
        }

        /// <summary>
        /// Список пользователей одной группы
        /// </summary>
        /// <param name="groupId">код группы</param>
        /// <returns></returns>
        public IEnumerable<User> GetUsers(int groupId)
        {
            return null;
        }

        /// <summary>
        /// Создание объекта пользователя
        /// </summary>
        /// <param name="reader">reader для текущего соединения с бд</param>
        /// <returns></returns>
        public static User ToUser(SqlDataReader reader)
        {
            return new User
            {
                Id = reader["Id_User"] != DBNull.Value ? (int)reader["Id_User"] : 0,
                Surname = reader["Surname"] != DBNull.Value ? reader["Surname"].ToString() : string.Empty,
                Name = reader["Name"] != DBNull.Value ? reader["Name"].ToString() : string.Empty,
                Description = reader["Description"].ToString(),
                GroupPermission = reader["Permission"] != DBNull.Value ? reader["Permission"].ToString() : string.Empty,
                GroupIn = reader["Subgroup"] != DBNull.Value ? reader["Subgroup"].ToString() : string.Empty,
                Login = reader["Login"] != DBNull.Value ? reader["Login"].ToString() : string.Empty,
                Password = reader["Password"] != DBNull.Value ? reader["Password"].ToString() : string.Empty
            };
        }
    }
}