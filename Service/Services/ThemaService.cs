using DbRepository.Classes.Repository;
using DbRepository.Context;

namespace Service.Services
{
    public class ThemaService
    {
        // Репозиторий для добавление в БД тем
        private readonly ThemaRepository _themaRep = new ThemaRepository();

        /// <summary>
        /// Добавление новой темы
        /// </summary>
        /// <param name="id">ИД [0] - ThemaId, [1] - SubThemaId</param>
        /// <param name="name">Название</param>
        /// <param name="description">Описание</param>
        public void Add(string name, string description, params int[] id)
        {
            _themaRep.Add(new Thema
            {
                Name = name,
                Description = description
            });
        }

        /// <summary>
        /// Редактирование существующей темы
        /// </summary>
        /// <param name="id">ИД</param>
        /// <param name="name">Имя</param>
        /// <param name="desc">Описание</param>
        public void Update(string name, string desc, params int[] id)
        {
            _themaRep.Update(new Thema
            {
                ThemaId = id[0],
                Name = name,
                Description = desc
            });
        }

        /// <summary>
        /// Удаление темы
        /// </summary>
        /// <param name="id">ИД темы</param>
        public void Delete(int id)
        {
            _themaRep.Delete(id);
        }
    }
}
