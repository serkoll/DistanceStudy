using System.Collections.Generic;
using System.Windows.Forms;
using DbRepository.Classes.Repository;
using DbRepository.Context;

namespace Service.Authentication
{
    // Модуль отвчающий за аутентификацию пользователей в приложении
    public class AuthenticationModule
    {
        public static User LoggedUser { get; private set; }
        private readonly Dictionary<string, Form> _dictionaryUsers;
        private readonly UserRepository _db;

        /// <summary>
        /// Конструктор для проверки логина и пароля + предоставления прав доступа
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="password">Пароль</param>
        /// <param name="dictionaryForms">Список форм для соответствущей группы пользователя</param>
        public AuthenticationModule(string login, string password, Dictionary<string, Form> dictionaryForms)
        {
            // доступ к репозиторию
            _db = new UserRepository();
            // словарь всех разрешений пользователя (роль <-> форма для роли)
            _dictionaryUsers = new Dictionary<string, Form>();
            foreach (var item in dictionaryForms)
            {
                _dictionaryUsers[item.Key] = dictionaryForms[item.Key];
            }
            if (login != null && password != null)
            {
                // Возвращает пользователя с таким логином и паролем
                LoggedUser = _db.GetUserByLoginPassword(login, password);
            }
        }
        /// <summary>
        /// Метод возвращает форму для работы с пользователем опрделенной группы
        /// </summary>
        /// <returns>Форма для работы пользователя</returns>
        public Form CreateUserForm()
        {
            if (LoggedUser != null)
            {
                LoggedUser.Permission = _db.GetUserPermission(LoggedUser);
                return _dictionaryUsers[LoggedUser.Permission.GroupName];
            }
            return null;
        }

        /// <summary>
        /// Получить права пользователя по объекту пользователя
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <returns>Права польователя user</returns>
        //public Permission GetUserPermission(User user)
        //{
        //    return _db.GetUserPermission(LoggedUser);
        //}
    }
}
