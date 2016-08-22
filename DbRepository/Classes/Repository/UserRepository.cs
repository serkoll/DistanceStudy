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
        public User GetUserByLoginPassword(string login, string password)
        {
            using (var db = new DistanceStudyEntities())
            {
                var selected = db.Set<User>().Where(c => c.Login.Equals(login))
                    .Where(c => c.Password.Equals(password));
                return selected.FirstOrDefault();
            }
        }

        /// <summary>
        /// Вернуть права пользователя
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <returns>Его права</returns>
        public Permission GetUserPermission(User user)
        {
            using (var db = new DistanceStudyEntities())
            {
                var selected = db.Set<User>().FirstOrDefault(c => c.UserId.Equals(user.UserId));
                if(selected != null)
                {
                    return db.Set<Permission>().FirstOrDefault(c => c.PermissionId.Equals(user.PermissionId));
                }
            }
            return null;
        }
    }
}