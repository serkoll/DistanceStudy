using System.Collections.Generic;
using System.Windows.Forms;
using DbRepository.Classes.Repository;
using DbRepository.Context;

namespace Authentication
{
    // Модуль отвчающий за аутентификацию пользователей в приложении
    public class AuthenticationModule
    {
        private readonly User _loggedUser;
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
                _loggedUser = _db.ValidateUserByLoginPassword(login, password);
            }
        }
        /// <summary>
        /// Метод возвращает форму для работы с пользователем опрделенной группы
        /// </summary>
        /// <returns>Форма для работы пользователя</returns>
        public Form CreateUserForm()
        {
            if (_loggedUser != null)
            {
                var permission = _db.GetPermissionForUser(_loggedUser);
                return _dictionaryUsers[permission.GroupName];
            }
            return null;
        }
    }
}
