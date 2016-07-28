using DbRepository.Context;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DbRepository.Classes.Context
{
    public class UserRepository
    {
        private readonly string _connectionString;

        /// <summary>
        /// Заполнение _connectionString в конструкторе
        /// </summary>
        public UserRepository()
        {
            // строка подключения к базе данных
            _connectionString = ConfigurationManager.ConnectionStrings["DistanceStudyDB"].ConnectionString;
        }

        /// <summary>
        /// Проверка на совпадение логина и пароля
        /// </summary>
        /// <param name="login">Логин пользователя</param>
        /// <param name="password">Пароль польователя</param>
        /// <returns>Объект пользователя (null если такого пользователя не найдено)</returns>
        public User ValidateUserByLoginPassword(string login, string password)
        {
            using (var db = new DistanceStudyEntities())
            {
                var users = db.Set<User>().ToList();
                var selected = users.Where(c => c.Login.Equals(login))
                    .Where(c => c.Password.Equals(password));
                return selected.FirstOrDefault();
            }
        }

    }
}