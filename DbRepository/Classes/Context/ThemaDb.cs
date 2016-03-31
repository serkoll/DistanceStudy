using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DbRepository.Classes.Entities;

namespace DbRepository.Classes.Context
{
    /// <summary>
    /// Класс, отвечающий за темы в БД
    /// </summary>
    public class ThemaDb
    {
        // Строка подключения к бд
        private readonly string _connectionString;

        public ThemaDb()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DistanceStudyDB"].ConnectionString;
        }

        /// <summary>
        ///     Добавление темы в бд
        /// </summary>
        /// <param name="item">Объект текущей темы</param>
        public void AddThema(Thema item)
        {
            try
            {
                using (var connect = new SqlConnection(_connectionString))
                {
                    using (var cmd = new SqlCommand("[Thema_Add]", connect))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 512)).Value = item.Name;
                        cmd.Parameters.Add(new SqlParameter("@Description", SqlDbType.NVarChar, 512)).Value =
                            item.Description;
                        connect.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("AddThema method failed.", ex);
            }
        }

        /// <summary>
        /// Удаление темы из бд
        /// </summary>
        /// <param name="themaName">Название темы</param>
        /// <returns></returns>
        public void DeleteThema(string themaName)
        {
            try
            {
                using (var connect = new SqlConnection(_connectionString))
                {
                    using (var cmd = new SqlCommand("[Thema_DeleteThema]", connect))
                    {
                        var thema = GetThema(themaName);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Id_Thema", SqlDbType.Int)).Value = thema.Id;
                        cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 512)).Value = themaName;
                        connect.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("DeleteThema method failed.", ex);
            }
        }

        public Thema GetThema(string themaName)
        {
            try
            {
                using (var connect = new SqlConnection(_connectionString))
                {
                    using (var cmd = new SqlCommand("[Thema_GetThema]", connect))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar, 512)).Value = themaName;
                        connect.Open();
                        using (var reader = cmd.ExecuteReader(CommandBehavior.SingleRow))
                        {
                            return reader.Read() ? reader.ToThema() : null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("GetThema method failed.", ex);
            }
        }

        public IEnumerable<Thema> GetAllThemas()
        {
            try
            {
                using (var connect = new SqlConnection(_connectionString))
                {
                    using (var cmd = new SqlCommand("[Thema_GetAllThemas]", connect))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        connect.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            var list = new List<Thema>();
                            while (reader.Read())
                            {
                                list.Add(reader.ToThema());
                            }
                            return list;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("GetAllThemas method failed.", ex);
            }
        }

        public int CountThemas()
        {
            throw new NotImplementedException();
        }
    }
}