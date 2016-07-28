using System;
using System.Configuration;

namespace DbRepository.Classes.Context
{
    public class ErrorMessagesDb
    {
        private readonly string _connectionString;

        public ErrorMessagesDb()
        {
            //_connectionString = ConfigurationManager.ConnectionStrings["DistanceStudyDB"].ConnectionString;
        }

        /// <summary>
        /// Метод возвращает сообщение об ошибке по коду из бд
        /// </summary>
        /// <param name="codeError">Код ошибки</param>
        /// <returns>Текст ошибки ошибке</returns>
        public string GetErrorMessageByCode(int codeError)
        {
            //throw new NotImplementedException();
            return "Error!";
        }
    }
}
