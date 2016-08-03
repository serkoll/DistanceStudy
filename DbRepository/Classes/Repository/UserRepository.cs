using DbRepository.Context;
using System.Data;
using System.Linq;

namespace DbRepository.Classes.Context
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

        /// <summary>
        /// Вернуть права доступа для текущего юзера
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <returns>Права доступа</returns>
        public Permission GetPermissionForUser(User user)
        {
            using (var db = new DistanceStudyEntities())
            {
                return db.Set<Permission>().FirstOrDefault(c => c.PermissionId == user.PermissionId);
            }
        }
    }
}