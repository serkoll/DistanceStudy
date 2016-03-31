using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DbRepository.Classes.Entities;

namespace DbRepository.Classes.Context
{
    public class SubthemaDb
    {
        // Строка подключения к бд
        private readonly string _connectionString;

        public SubthemaDb()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DistanceStudyDB"].ConnectionString;
        }

        #region ADO.NET

        public void AddSubthema(Subthema item)
        {
            try
            {
                using (var connect = new SqlConnection(_connectionString))
                {
                    using (var cmd = new SqlCommand("[Subthema_Add]", connect))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Id_Thema", SqlDbType.Int)).Value = item.Id_Thema;
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
                throw new Exception("AddSubthema method failed.", ex);
            }
        }

        public Subthema GetSubthema(string subthemaName)
        {
            try
            {
                using (var connect = new SqlConnection(_connectionString))
                {
                    using (var cmd = new SqlCommand("[Subthema_GetSubthema]", connect))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar, 512)).Value = subthemaName;
                        connect.Open();
                        using (var reader = cmd.ExecuteReader(CommandBehavior.SingleRow))
                        {
                            return reader.Read() ? reader.ToSubthema() : null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("GetSubThema method failed.", ex);
            }
        }

        public IEnumerable<Subthema> GetAllSubthemas()
        {
            try
            {
                using (var connect = new SqlConnection(_connectionString))
                {
                    using (var cmd = new SqlCommand("[Subthema_GetAllSubthemas]", connect))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        connect.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            var list = new List<Subthema>();
                            while (reader.Read())
                            {
                                list.Add(reader.ToSubthema());
                            }
                            return list;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("GetAllSubthemas method failed.", ex);
            }
        }

        #endregion

    }
}