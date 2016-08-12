using DbRepository.Classes.Context;
using DbRepository.Context;

namespace Service.Services
{
    public class SubthemaService
    {
        // Репозиторий для добавление в БД тем
        private readonly SubthemaRepository _subthemaRep = new SubthemaRepository();

        /// <summary>
        /// Добавление новой подтемы
        /// </summary>
        /// <param name="name">Название</param>
        /// <param name="description">Описание</param>
        /// <param name="id">ИД [0] - тема ИД, [1] - подтема ИД</param>
        public void Add(string name, string description, params int[] id)
        {
            _subthemaRep.Add(new SubThema
            {
                ThemaId = id[0],
                Name = name,
                Description = description
            });
        }

        /// <summary>
        /// Редактирование существующей подтемы
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="desc">Описание</param>
        /// <param name="id">ИД [0] - тема ИД, [1] - подтема ИД</param>
        public void Update(string name, string desc, params int[] id)
        {
            _subthemaRep.Update(new SubThema
            {
                SubthemaId = id[1],
                ThemaId = id[0],
                Name = name,
                Description = desc
            });
        }

        /// <summary>
        /// Удаление подтемы
        /// </summary>
        /// <param name="id">ИД подтемы</param>
        public void Delete(int id)
        {
            _subthemaRep.Delete(id);
        }
    }
}
