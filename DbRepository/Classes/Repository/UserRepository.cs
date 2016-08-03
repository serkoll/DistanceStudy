using System.Linq;
using DbRepository.Context;

namespace DbRepository.Classes.Repository
{
    public class UserRepository
    {
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