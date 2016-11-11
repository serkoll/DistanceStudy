namespace DbRepository.Classes.Repository
{
    public class ErrorMessagesDb
    {
        /// <summary>
        /// Метод возвращает сообщение об ошибке по коду из бд
        /// </summary>
        /// <param name="codeError">Код ошибки</param>
        /// <returns>Текст ошибки ошибке</returns>
        public string GetErrorMessageByCode(string codeError)
        {
            //throw new NotImplementedException();
            return codeError;
        }
    }
}
